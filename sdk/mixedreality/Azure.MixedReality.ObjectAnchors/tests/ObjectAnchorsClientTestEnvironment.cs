// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests
{
    public class ObjectAnchorsClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetVariable("ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetVariable("ACCOUNT_ID");

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetVariable("ACCOUNT_KEY");

        /// <summary>
        /// Gets the asset's local file path
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ASSET_LOCAL_FILE_PATH environment variable.
        /// </remarks>
        public string AssetLocalFilePath => GetVariable("ASSET_LOCAL_FILE_PATH");

        /// <summary>
        /// Gets the asset's gravity vector's x component
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ASSET_GRAVITY_X environment variable.
        /// </remarks>
        public float AssetGravityX => float.Parse(GetVariable("ASSET_GRAVITY_X"));

        /// <summary>
        /// Gets the asset's gravity vector's y component
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ASSET_GRAVITY_Y environment variable.
        /// </remarks>
        public float AssetGravityY => float.Parse(GetVariable("ASSET_GRAVITY_Y"));

        /// <summary>
        /// Gets the asset's gravity vector's z component
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ASSET_GRAVITY_Z environment variable.
        /// </remarks>
        public float AssetGravityZ => float.Parse(GetVariable("ASSET_GRAVITY_Z"));

        /// <summary>
        /// Gets the asset's scale
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ASSET_SCALE environment variable.
        /// </remarks>
        public float AssetScale => float.Parse(GetVariable("ASSET_SCALE"));

        /// <summary>
        /// Gets the path to download the model
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_DOWNLOAD_FILE_PATH environment variable.
        /// </remarks>
        public string DownloadFilePath => GetVariable("DOWNLOAD_FILE_PATH");
    }
}
