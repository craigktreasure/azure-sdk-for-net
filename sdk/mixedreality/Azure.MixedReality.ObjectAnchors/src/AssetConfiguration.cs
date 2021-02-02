// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    using System;
    using Azure.MixedReality.ObjectAnchors.Models;
    using Vector3 = System.Numerics.Vector3;

    /// <summary>
    /// An object representing asset configuration values.
    /// </summary>
    public class AssetConfiguration : IngestionConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConfiguration"/> class.
        /// </summary>
        /// <param name="gravity">The asset gravity, which must be normalized.</param>
        /// <param name="scale">The asset scale.</param>
        public AssetConfiguration(Vector3 gravity, float scale) : base(gravity.ToGeneratedVector3(), scale)
        {
            if (!gravity.IsNormalized())
            {
                throw new ArgumentException("The value must be normalized.", nameof(gravity));
            }
        }

        /// <summary>
        /// Returns true if the values of the object contain valid data.
        /// </summary>
        /// <param name="invalidMessage">The invalid message.</param>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        internal bool IsValid(out string invalidMessage)
        {
            invalidMessage = string.Empty;

            if (this.Gravity == null || !this.Gravity.Value.IsNormalized())
            {
                invalidMessage = $"The value for {nameof(AssetConfiguration.Gravity)} must be normalized.";
            }

            return invalidMessage.Length == 0;
        }
    }
}
