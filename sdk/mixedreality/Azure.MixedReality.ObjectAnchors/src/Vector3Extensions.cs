// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    using System;
    using System.Numerics;
    using Vector3 = System.Numerics.Vector3;
    using GeneratedVector3 = Azure.MixedReality.ObjectAnchors.Models.Vector3;

    internal static class Vector3Extensions
    {
        private const float normalizationAccuracy = 1.0e-4f;

        /// <summary>
        /// Determines whether the specified vector is normalized.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns><c>true</c> if the specified vector is normalized; otherwise, <c>false</c>.</returns>
        public static bool IsNormalized(this Vector3 vector)
        {
            return Math.Abs(vector.LengthSquared() - 1) < normalizationAccuracy;
        }

        internal static GeneratedVector3 ToGeneratedVector3(this Vector3 vector)
        {
            return new GeneratedVector3(vector.X, vector.Y, vector.Z);
        }
    }
}
