// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.ObjectAnchors
{
    using System;

    internal static class AssetScaleGenerator
    {
        /// <summary>
        /// Gets the asset scale from the unit supplied.
        /// </summary>
        /// <param name="unit">The unit of the asset gravity.</param>
        /// <returns>Returns float.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public static float GetAssetScale(MeasurementUnit unit)
        {
            return unit switch
            {
                MeasurementUnit.Centimeters => 0.01f,
                MeasurementUnit.Decimeters => 0.1f,
                MeasurementUnit.Feet => 0.3048f,
                MeasurementUnit.Inches => 0.0254f,
                MeasurementUnit.Kilometers => 1000,
                MeasurementUnit.Meters => 1,
                MeasurementUnit.Millimeters => 0.001f,
                MeasurementUnit.Yards => 0.9144f,
                _ => throw new NotSupportedException($"Unsupported value for '{nameof(unit)}': '{unit}'."),
            };
        }
    }
}
