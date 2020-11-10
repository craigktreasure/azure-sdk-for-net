// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.SpatialAnchors.Client
{
    using System;
    using Azure.Core;

    /// <summary>
    /// Represents Azure Spatial Anchors account details.
    /// </summary>
    public class SpatialAnchorsAccount
    {
        /// <summary>
        /// Gets the Azure Spatial Anchors account domain.
        /// </summary>
        public string AccountDomain { get; }

        /// <summary>
        /// Gets the Azure Spatial Anchors account identifier.
        /// </summary>
        public Guid AccountId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsAccount"/> class.
        /// </summary>
        /// <param name="accountId">The Azure Spatial Anchors account identifier.</param>
        /// <param name="accountDomain">The Azure Spatial Anchors account domain.</param>
        public SpatialAnchorsAccount(Guid accountId, string accountDomain)
        {
            Argument.AssertNotDefault(ref accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            AccountId = accountId;
            AccountDomain = accountDomain;
        }
    }
}
