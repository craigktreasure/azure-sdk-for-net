// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    using Microsoft.Azure.MixedReality.Sts;
    using System;
    using System.IO;
    using System.Numerics;

    /// <summary>
    /// Represents an Object Anchors ingestion job request.
    /// </summary>
    public class IngestionJobRequest
    {
        /// <summary>
        /// Gets the asset configuration values.
        /// </summary>
        public AssetConfiguration AssetConfigurationValues { get; }

        /// <summary>
        /// The file type of the asset.
        /// </summary>
        public string AssetFileType { get; }

        /// <summary>
        /// The path to the Asset to be ingested by the Object Anchors service.
        /// </summary>
        public string InputFilePath { get; }

        /// <summary>
        /// Identifier for the Object Anchors Ingestion ServiceResponse.
        /// </summary>
        public Guid JobId { get; } = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobRequest"/> class.
        /// </summary>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="assetScale">The asset scale.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobRequest(Vector3 assetGravity, float assetScale, string inputFilePath)
            : this(new AssetConfiguration(assetGravity, assetScale), inputFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobRequest"/> class.
        /// </summary>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="unit">The unit of measurement.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobRequest(Vector3 assetGravity, Unit unit, string inputFilePath)
            : this(new AssetConfiguration(assetGravity, AssetScaleGenerator.GetAssetScale(unit)), inputFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobRequest"/> class.
        /// </summary>
        /// <param name="assetConfiguration">The asset configuration.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobRequest(AssetConfiguration assetConfiguration, string inputFilePath)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                throw new ArgumentNullOrWhiteSpaceException(nameof(inputFilePath));
            }

            if (assetConfiguration is null)
            {
                throw new ArgumentNullException(nameof(assetConfiguration));
            }

            if (!assetConfiguration.IsValid(out string assetConfigurationInvalidMessage))
            {
                throw new ArgumentException(assetConfigurationInvalidMessage, nameof(assetConfiguration));
            }

            this.InputFilePath = inputFilePath;
            this.AssetFileType = Path.GetExtension(inputFilePath);
            this.AssetConfigurationValues = assetConfiguration;
        }
    }
}
