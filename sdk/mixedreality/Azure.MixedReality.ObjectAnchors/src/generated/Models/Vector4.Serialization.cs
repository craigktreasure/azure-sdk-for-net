// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Models
{
    internal partial class Vector4 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(X))
            {
                writer.WritePropertyName("x");
                writer.WriteNumberValue(X.Value);
            }
            if (Optional.IsDefined(Y))
            {
                writer.WritePropertyName("y");
                writer.WriteNumberValue(Y.Value);
            }
            if (Optional.IsDefined(Z))
            {
                writer.WritePropertyName("z");
                writer.WriteNumberValue(Z.Value);
            }
            if (Optional.IsDefined(W))
            {
                writer.WritePropertyName("w");
                writer.WriteNumberValue(W.Value);
            }
            writer.WriteEndObject();
        }

        internal static Vector4 DeserializeVector4(JsonElement element)
        {
            Optional<float> x = default;
            Optional<float> y = default;
            Optional<float> z = default;
            Optional<float> w = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("x"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    x = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("y"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    y = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("z"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    z = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("w"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    w = property.Value.GetSingle();
                    continue;
                }
            }
            return new Vector4(Optional.ToNullable(x), Optional.ToNullable(y), Optional.ToNullable(z), Optional.ToNullable(w));
        }
    }
}
