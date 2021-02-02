// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary> Identifies an Object Anchors account. </summary>
    public class ObjectAnchorsAccount
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
        /// Initializes a new instance of the <see cref="ObjectAnchorsAccount"/> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account identifier.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        public ObjectAnchorsAccount(Guid accountId, string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            AccountId = accountId;
            AccountDomain = accountDomain;
        }
    }
}
