// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.ObjectAnchors
{
    using Azure.Core;
    using System;
    using System.IO;
    using System.Numerics;

    /// <summary>
    /// Represents an Object Anchors ingestion job request's options.
    /// </summary>
    public class IngestionJobCreationOptions
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
        public Uri InputFilePath { get; }

        /// <summary>
        /// Identifier for the Object Anchors Ingestion ServiceResponse.
        /// </summary>
        public Guid JobId { get; } = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobCreationOptions"/> class.
        /// </summary>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="assetScale">The asset scale.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobCreationOptions(Vector3 assetGravity, float assetScale, Uri inputFilePath)
            : this(new AssetConfiguration(assetGravity, assetScale), inputFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobCreationOptions"/> class.
        /// </summary>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="unit">The unit of measurement.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobCreationOptions(Vector3 assetGravity, MeasurementUnit unit, Uri inputFilePath)
            : this(new AssetConfiguration(assetGravity, AssetScaleGenerator.GetAssetScale(unit)), inputFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngestionJobCreationOptions"/> class.
        /// </summary>
        /// <param name="assetConfiguration">The asset configuration.</param>
        /// <param name="inputFilePath">The path to the Asset to be ingested by the Object Anchors service.</param>
        public IngestionJobCreationOptions(AssetConfiguration assetConfiguration, Uri inputFilePath)
        {
            Argument.AssertNotNull(inputFilePath, nameof(inputFilePath));
            Argument.AssertNotNull(assetConfiguration, nameof(assetConfiguration));

            if (!assetConfiguration.IsValid(out string assetConfigurationInvalidMessage))
            {
                throw new ArgumentException(assetConfigurationInvalidMessage, nameof(assetConfiguration));
            }

            this.InputFilePath = inputFilePath;
            this.AssetFileType = Path.GetExtension(inputFilePath.ToString());
            this.AssetConfigurationValues = assetConfiguration;
        }
    }
}
