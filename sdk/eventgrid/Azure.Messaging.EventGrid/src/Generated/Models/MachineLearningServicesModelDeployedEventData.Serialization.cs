// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MachineLearningServicesModelDeployedEventDataConverter))]
    public partial class MachineLearningServicesModelDeployedEventData
    {
        internal static MachineLearningServicesModelDeployedEventData DeserializeMachineLearningServicesModelDeployedEventData(JsonElement element)
        {
            Optional<string> serviceName = default;
            Optional<string> serviceComputeType = default;
            Optional<string> modelIds = default;
            Optional<object> serviceTags = default;
            Optional<object> serviceProperties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceName"))
                {
                    serviceName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serviceComputeType"))
                {
                    serviceComputeType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelIds"))
                {
                    modelIds = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serviceTags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    serviceTags = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("serviceProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    serviceProperties = property.Value.GetObject();
                    continue;
                }
            }
            return new MachineLearningServicesModelDeployedEventData(serviceName.Value, serviceComputeType.Value, modelIds.Value, serviceTags.Value, serviceProperties.Value);
        }

        internal partial class MachineLearningServicesModelDeployedEventDataConverter : JsonConverter<MachineLearningServicesModelDeployedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MachineLearningServicesModelDeployedEventData model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override MachineLearningServicesModelDeployedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMachineLearningServicesModelDeployedEventData(document.RootElement);
            }
        }
    }
}
