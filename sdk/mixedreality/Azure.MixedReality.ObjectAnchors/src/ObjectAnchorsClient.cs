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
        protected SpatialAnchorsClient()
        {
        }

        public virtual void CreateJob(IngestionJobRequest request, CancellationToken cancellationToken = default)
        {
            return _ingestionJobRestClient.Create(_account.AccountId, request.JobId);
        }

        public virtual async Task<> CreateJobAsync(IngestionJobRequest request, CancellationToken cancellationToken = default) { }

        public virtual void GetJob(CancellationToken cancellationToken = default) { }

        public virtual async Task<> GetJobAsync(CancellationToken cancellationToken = default) { }

        public virtual void GetUploadUri(CancellationToken cancellationToken = default) { }

        public virtual async Task<> GetUploadUriAsync(CancellationToken cancellationToken = default) { }

        public virtual Response<IngestionProperties> GetIngestionJob(CancellationToken cancellationToken = default) { }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');

        private static Uri ConstructObjectAnchorsEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (!Uri.TryCreate($"https://{accountDomain}", UriKind.Absolute, out Uri result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }
    }
}
