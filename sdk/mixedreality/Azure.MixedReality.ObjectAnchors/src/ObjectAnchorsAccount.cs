using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors
{
    public class ObjectAnchorsAccount
    {
        /// <summary>
        /// Gets the Azure Spatial Anchors account domain.
        /// </summary>
        public string AccountDomain { get; }

        /// <summary>
        /// Gets the Azure Spatial Anchors account identifier.
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsAccount"/> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account identifier.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        public ObjectAnchorsAccount(string accountId, string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            AccountId = accountId;
            AccountDomain = accountDomain;
        }
    }
}
