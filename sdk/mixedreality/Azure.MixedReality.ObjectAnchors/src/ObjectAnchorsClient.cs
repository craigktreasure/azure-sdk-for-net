// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using Azure.MixedReality.Authentication;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary>
    /// Represents a client for Azure Object Anchors.
    /// </summary>
    public class ObjectAnchorsClient
    {
        private MixedRealityStsClient stsClient;

        /// <summary>
        /// Gets the Mixed Reality service account identifier.
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// The Mixed Reality Object Anchors service endpoint.
        /// </summary>
        public Uri Endpoint { get; }

        public ObjectAnchorsClient(Uri endpoint, string accountId, AzureKeyCredential keyCredential, ObjectAnchorsClientOptions? options = null)
        {

        }

        public ObjectAnchorsClient(Uri endpoint, string accountId, MixedRealityStsClient stsClient)
        {

        }


        // public ObjectAnchorsClient(<simple_binding_parameters>, ObjectAnchorsClientOptions options);

        // // 0 or more advanced constructors
        // public ObjectAnchorsClient(<advanced_binding_parameters>, ObjectAnchorsClientOptions options = default);

        // mocking constructor
        protected ObjectAnchorsClient()
        {
        }

        // public async Task<IngestionJobResponse> CreateJobAsync(IngestionJobRequest request, CancellationToken cancellationToken = default)
        // public Task<IngestionJobResponse> CreateJob(IngestionJobRequest request, CancellationToken cancellationToken = default)

        // public async Task<IngestionJobResponse> GetJobAsync(Guid jobId, CancellationToken cancellationToken = default)
        // public Task<IngestionJobResponse> GetJob(Guid jobId, CancellationToken cancellationToken = default)

        // public async Task<BlobUploadResponse> GetUploadUriAsync(BlobUploadParameters uploadParameters, CancellationToken cancellationToken = default)
        // public Task<BlobUploadResponse> GetUploadUri(BlobUploadParameters uploadParameters, CancellationToken cancellationToken = default)

    }
}
