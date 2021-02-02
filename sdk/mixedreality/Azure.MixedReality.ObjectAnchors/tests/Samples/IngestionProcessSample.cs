// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.MixedReality.ObjectAnchors.Models;
using Azure.MixedReality.SpatialAnchors.Client.Tests;
using Microsoft.Azure.Storage.Blob;
using NUnit.Framework;

namespace Azure.MixedReality.ObjectAnchors.Tests.Samples
{
    public class IngestionProcessSample : SamplesBase<ObjectAnchorsClientTestEnvironment>
    {
        private static readonly TimeSpan pollingInterval = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan waitTimeout = TimeSpan.FromMinutes(20);
        private readonly ObjectAnchorsAccount account;
        private readonly string accountKey;

        public IngestionProcessSample()
        {
            this.account = new ObjectAnchorsAccount(new Guid(TestEnvironment.AccountId), TestEnvironment.AccountDomain);
            this.accountKey = TestEnvironment.AccountKey;
        }

        [Test]
        public async void RunIngestion()
        {
            string clientId = TestEnvironment.ClientId;
            string clientSecret = TestEnvironment.ClientSecret;
            string tenantId = TestEnvironment.TenantId;
            string localFilePath = TestEnvironment.AssetLocalFilePath;
            Vector3 assetGravity = new Vector3(TestEnvironment.AssetGravityX, TestEnvironment.AssetGravityY, TestEnvironment.AssetGravityZ);
            float scale = TestEnvironment.AssetScale;
            string downloadFilePath = TestEnvironment.DownloadFilePath;

            TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
            });

            ObjectAnchorsClient client = new ObjectAnchorsClient(account, credential);

            Uri uploadUri = await client.GetUploadUriAsync();

            CloudBlockBlob cloudBlockBlob = new CloudBlockBlob(uploadUri);

            await cloudBlockBlob.UploadFromFileAsync(localFilePath).ConfigureAwait(false);

            AssetConfiguration assetConfiguration = new AssetConfiguration(assetGravity, scale);

            IngestionJobCreationOptions ingestionJobRequest = new IngestionJobCreationOptions(assetConfiguration, uploadUri);

            var jobId = (await client.CreateJobAsync(ingestionJobRequest)).Value.JobId.Value;

            DateTime startTime = DateTime.UtcNow;

            bool hasSucceeded = false;
            IngestionProperties ingestionProperties = null;
            while (hasSucceeded == false)
            {
                if (DateTime.UtcNow - startTime > waitTimeout)
                {
                    throw new TimeoutException($"The maximum timeout has been reached. Job Id: {jobId}");
                }

                ingestionProperties = (await client.GetJobAsync(jobId)).Value;

                if (ingestionProperties.JobStatus == JobStatus.Succeeded)
                {
                    hasSucceeded = true;
                }
                else if (ingestionProperties.JobStatus == JobStatus.Cancelled)
                {
                    throw new OperationCanceledException($"Job unexpectedly cancelled. Job Id: {jobId}");
                }
                else if (ingestionProperties.JobStatus == JobStatus.Failed)
                {
                    throw new Exception($"Job failed. Job Id: {jobId}");
                }
                else
                {
                    await Task.Delay(pollingInterval).ConfigureAwait(false);
                }
            }

            cloudBlockBlob = new CloudBlockBlob(ingestionProperties.OutputModelUri);
            await cloudBlockBlob.DownloadToFileAsync(localFilePath, FileMode.CreateNew).ConfigureAwait(false);
        }
    }
}
