// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Azure.MixedReality.ObjectAnchors
{
    using System;
    using System.Numerics;
    using Vector4 = System.Numerics.Vector4;
    using GeneratedVector4 = Azure.MixedReality.ObjectAnchors.Models.Vector4;

    internal static class Vector4Extensions
    {
        internal static GeneratedVector4 ToGeneratedVector4(this Vector4 vector)
        {
            return new GeneratedVector4(vector.X, vector.Y, vector.Z, vector.W);
        }
    }
}
