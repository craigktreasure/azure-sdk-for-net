// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    public partial class AccessToken
    {
        internal static AccessToken DeserializeAccessToken(JsonElement element)
        {
            Optional<string> accessToken = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("access_token"))
                {
                    accessToken = property.Value.GetString();
                    continue;
                }
            }
            return new AccessToken(accessToken.Value);
        }
    }
}
