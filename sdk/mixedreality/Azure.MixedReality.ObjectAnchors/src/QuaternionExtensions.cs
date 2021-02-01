// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    using System;
    using System.Numerics;
    using Quaternion = System.Numerics.Quaternion;
    using GeneratedQuaternion = Azure.MixedReality.ObjectAnchors.Models.Quaternion;

    internal static class QuaternionExtensions
    {
        internal static GeneratedQuaternion ToGeneratedQuaternion(this Quaternion quaternion)
        {
            return new GeneratedQuaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W, quaternion.IsIdentity);
        }
    }
}
