﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary>
    /// The <see cref="ObjectAnchorsClientOptions"/>.
    /// Implements the <see cref="Azure.Core.ClientOptions" />.
    /// </summary>
    /// <seealso cref="Azure.Core.ClientOptions" />
    public class ObjectAnchorsClientOptions : ClientOptions
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
        /// Initializes a new instance of the <see cref="ObjectAnchorsClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="serviceEndpoint">The service endpoint.</param>
        /// <param name="authenticationEndpoint">The authentication endpoint.</param>
        public ObjectAnchorsClientOptions(ServiceVersion version = ServiceVersion.V0_2_preview_0, Uri? serviceEndpoint = null, Uri? authenticationEndpoint = null)
        {
            Version = version switch
            {
                ServiceVersion.V0_2_preview_0 => "0.2-preview.0",
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
            /// Version 0.2-preview.0 of the Azure Object Anchors service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V0_2_preview_0 = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
