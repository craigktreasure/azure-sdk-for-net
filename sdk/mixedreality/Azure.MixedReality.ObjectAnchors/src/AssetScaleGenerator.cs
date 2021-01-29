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
        public static float GetAssetScale(Unit unit)
        {
            return unit switch
            {
                Unit.Centimeters => 0.01f,
                Unit.Decimeters => 0.1f,
                Unit.Feet => 0.3048f,
                Unit.Inches => 0.0254f,
                Unit.Kilometers => 1000,
                Unit.Meters => 1,
                Unit.Millimeters => 0.001f,
                Unit.Yards => 0.9144f,
                _ => throw new NotSupportedException($"Unsupported value for '{nameof(unit)}': '{unit}'."),
            };
        }
    }
}
