using System;
using System.Collections.Generic;
using System.Text;
using NumericsVector3 = System.Numerics.Vector3;
using NumericsVector4 = System.Numerics.Vector4;
using NumericsQuaternion = System.Numerics.Quaternion;
using GeneratedVector3 = Azure.MixedReality.ObjectAnchors.Models.Vector3;
using GeneratedVector4 = Azure.MixedReality.ObjectAnchors.Models.Vector4;
using GeneratedQuaternion = Azure.MixedReality.ObjectAnchors.Models.Quaternion;

namespace Azure.MixedReality.ObjectAnchors.Models
{
    internal static class ModelExtensions
    {
        internal static NumericsVector3? ToGeneratedVector3(this GeneratedVector3 vector)
        {
            if (!(vector.X.HasValue && vector.Y.HasValue && vector.Z.HasValue))
            {
                return null;
            }

            return new NumericsVector3(vector.X.Value, vector.Y.Value, vector.Z.Value);
        }

        internal static NumericsVector4? ToGeneratedVector4(this GeneratedVector4 vector)
        {
            if (!(vector.X.HasValue && vector.Y.HasValue && vector.Z.HasValue && vector.W.HasValue))
            {
                return null;
            }

            return new NumericsVector4(vector.X.Value, vector.Y.Value, vector.Z.Value, vector.W.Value);
        }

        internal static NumericsQuaternion? ToGeneratedQuaternion(this GeneratedQuaternion quaternion)
        {
            if (!(quaternion.X.HasValue && quaternion.Y.HasValue && quaternion.Z.HasValue && quaternion.W.HasValue))
            {
                return null;
            }

            return new NumericsQuaternion(quaternion.X.Value, quaternion.Y.Value, quaternion.Z.Value, quaternion.W.Value);
        }
    }
}
