// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.MixedReality.SpatialAnchors.Client
{
    internal class SpatialAnchorsGetPropertiesByIdHeaders
    {
        private readonly Response _response;
        public SpatialAnchorsGetPropertiesByIdHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> The service response correlation vector, which will be a new value for every response. </summary>
        public string RequestId => _response.Headers.TryGetValue("MS-CV", out string value) ? value : null;
    }
}
