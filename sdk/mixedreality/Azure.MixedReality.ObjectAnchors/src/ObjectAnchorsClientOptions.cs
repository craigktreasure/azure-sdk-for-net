// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary>
    /// An object representing options for <see cref="ObjectAnchorsClient"/>.
    /// </summary>
    public class ObjectAnchorsClientOptions
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        public string AccountDomain { get; }

        /// <summary>
        /// Gets the auth domain.
        /// </summary>
        public string AuthDomain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClientOptions"/> class.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="accountKey">The account key.</param>
        /// <param name="accountDomain">The account domain.</param>
        /// <param name="authDomain">The auth domain.</param>
        /// <exception cref="ArgumentNullOrWhiteSpaceException"></exception>
        public ObjectAnchorsClientOptions(string accountId, string accountKey, string accountDomain, string authDomain = null)
            : this(new AccountKeyAuthenticationInfo(accountId, accountKey), accountDomain, authDomain)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsClientOptions" /> class.
        /// </summary>
        /// <param name="authenticationInfo">The authentication information.</param>
        /// <param name="accountDomain">The account domain.</param>
        /// <param name="authDomain">The auth domain.</param>
        /// <exception cref="ArgumentNullException">authenticationInfo</exception>
        public ObjectAnchorsClientOptions(IAuthenticationInfo authenticationInfo, string accountDomain, string authDomain = null)
        {
            if (authenticationInfo is null)
            {
                throw new ArgumentNullException(nameof(authenticationInfo));
            }

            if (string.IsNullOrWhiteSpace(accountDomain))
            {
                throw new ArgumentNullOrWhiteSpaceException(nameof(accountDomain));
            }

            this.AuthInfo = authenticationInfo;
            this.AccountDomain = accountDomain;
            this.AuthDomain = authDomain;
        }
    }
}
