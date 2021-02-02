// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.ObjectAnchors.Models;
using Vector3 = System.Numerics.Vector3;
using GeneratedVector3 = Azure.MixedReality.ObjectAnchors.Models.Vector3;
using System.Threading.Tasks;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary>
    /// Represents a client for Azure Object Anchors.
    /// </summary>
    public class ObjectAnchorsClient
    {
        private readonly ObjectAnchorsAccount _account;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly BlobUploadEndpointRestClient _getBlobUploadEndpointRestClient;

        private readonly IngestionJobRestClient _ingestionJobRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Object Anchors account details.</param>
        /// <param name="token">An access token used to access the specified Azure Object Anchors account.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsClient(ObjectAnchorsAccount account, AccessToken token, ObjectAnchorsClientOptions? options = null)
            : this(account, new StaticAccessTokenCredential(token), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Object Anchors account details.</param>
        /// <param name="keyCredential">The Azure Object Anchors account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsClient(ObjectAnchorsAccount account, AzureKeyCredential keyCredential, ObjectAnchorsClientOptions? options = null)
            : this(account, new MixedRealityAccountKeyCredential(account.AccountId.ToString(), keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Object Anchors account details.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsClient(ObjectAnchorsAccount account, TokenCredential credential, ObjectAnchorsClientOptions? options = null)
        {
            Argument.AssertNotNull(account, nameof(account));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new ObjectAnchorsClientOptions();

            Uri authenticationEndpoint = options.AuthenticationEndpoint ?? AuthenticationEndpoint.ConstructFromDomain(account.AccountDomain);
            TokenCredential mrTokenCredential = MixedRealityTokenCredential.GetMixedRealityCredential(account.AccountId.ToString(), authenticationEndpoint, credential);
            Uri serviceEndpoint = options.ServiceEndpoint ?? ConstructObjectAnchorsEndpointUrl(account.AccountDomain);

            _account = account;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(mrTokenCredential, GetDefaultScope(serviceEndpoint)));
            _getBlobUploadEndpointRestClient = new BlobUploadEndpointRestClient(_clientDiagnostics, _pipeline, serviceEndpoint, options.Version);
            _ingestionJobRestClient = new IngestionJobRestClient(_clientDiagnostics, _pipeline, serviceEndpoint, options.Version);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClient"/> class.
        /// </summary>
        /// <remarks>
        /// Required for mocking.
        /// </remarks>
        protected ObjectAnchorsClient()
        {
        }

        public virtual Response<IngestionProperties> CreateJob(IngestionJobRequest request, CancellationToken cancellationToken = default)
        {
            IngestionProperties properties = new IngestionProperties
            {
                AssetFileType = request.AssetFileType,
                IngestionConfiguration = request.AssetConfigurationValues,
                InputAssetUri = request.InputFilePath
            };
            return _ingestionJobRestClient.Create(_account.AccountId, request.JobId, cancellationToken: cancellationToken);
        }

        public virtual async Task<Response<IngestionProperties>> CreateJobAsync(IngestionJobRequest request, CancellationToken cancellationToken = default)
        {
            IngestionProperties properties = new IngestionProperties
            {
                AssetFileType = request.AssetFileType,
                IngestionConfiguration = request.AssetConfigurationValues,
                InputAssetUri = request.InputFilePath
            };
            return await _ingestionJobRestClient.CreateAsync(_account.AccountId, request.JobId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public virtual Response<IngestionProperties> GetJob(Guid JobId, CancellationToken cancellationToken = default)
        {
            return _ingestionJobRestClient.Get(_account.AccountId, JobId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken);
        }

        public virtual async Task<Response<IngestionProperties>> GetJobAsync(Guid JobId, CancellationToken cancellationToken = default)
        {
            return await _ingestionJobRestClient.GetAsync(_account.AccountId, JobId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public virtual Response<Uri> GetUploadUri(CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<UploadLocation, BlobUploadEndpointGetHeaders> response =
                _getBlobUploadEndpointRestClient.Get(_account.AccountId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken);
            return ResponseWithHeaders.FromValue(new Uri(response.Value.InputAssetUri), response.Headers, response.GetRawResponse());
        }

        public virtual async Task<Response<Uri>> GetUploadUriAsync(CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<UploadLocation, BlobUploadEndpointGetHeaders> response =
                await _getBlobUploadEndpointRestClient.GetAsync(_account.AccountId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken).ConfigureAwait(false);
            return ResponseWithHeaders.FromValue(new Uri(response.Value.InputAssetUri), response.Headers, response.GetRawResponse());
        }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');

        private static Uri ConstructObjectAnchorsEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (!Uri.TryCreate($"https://aoa.{accountDomain}", UriKind.Absolute, out Uri result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }
    }
}
