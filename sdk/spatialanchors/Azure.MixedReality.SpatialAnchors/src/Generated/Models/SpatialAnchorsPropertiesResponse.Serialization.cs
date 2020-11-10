// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.MixedReality.SpatialAnchors.Client.Models
{
    internal partial class SpatialAnchorsPropertiesResponse
    {
        internal static SpatialAnchorsPropertiesResponse DeserializeSpatialAnchorsPropertiesResponse(JsonElement element)
        {
            Optional<IReadOnlyList<SpatialAnchorResponseInfo>> spatialAnchors = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("spatialAnchors"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SpatialAnchorResponseInfo> array = new List<SpatialAnchorResponseInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SpatialAnchorResponseInfo.DeserializeSpatialAnchorResponseInfo(item));
                    }
                    spatialAnchors = array;
                    continue;
                }
            }
            return new SpatialAnchorsPropertiesResponse(Optional.ToList(spatialAnchors));
        }
    }
}
