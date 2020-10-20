// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Learn.AppConfig
{
    /// <summary>
    /// The <see cref="ConfigurationSetting"/>.
    /// </summary>
    [CodeGenModel("KeyValue")]
    public partial class ConfigurationSetting
    {
        /// <summary>
        /// The entity-tag of the key-value.
        /// </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }
    }
}
