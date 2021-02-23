﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.SpatialAnchors.Client
{
    /// <summary>
    /// The <see cref="SpatialAnchorsClientOptions"/>.
    /// Implements the <see cref="Azure.Core.ClientOptions" />.
    /// </summary>
    /// <seealso cref="Azure.Core.ClientOptions" />
    public class SpatialAnchorsClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Gets the authentication endpoint.
        /// </summary>
        internal Uri? AuthenticationEndpoint { get; }

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        internal Uri? ServiceEndpoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        /// <param name="authenticationEndpoint">The authentication endpoint.</param>
        public SpatialAnchorsClientOptions(ServiceVersion version = ServiceVersion.V2019_02_28_preview, Uri? serviceEndpoint = null, Uri? authenticationEndpoint = null)
        {
            Version = version switch
            {
                ServiceVersion.V2019_02_28_preview => "2019-02-28-preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };

            ServiceEndpoint = serviceEndpoint;
            AuthenticationEndpoint = authenticationEndpoint;
        }

        /// <summary>
        /// The Azure Spatial Anchors service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2019-02-28-preview of the Azure Spatial Anchors service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2019_02_28_preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
