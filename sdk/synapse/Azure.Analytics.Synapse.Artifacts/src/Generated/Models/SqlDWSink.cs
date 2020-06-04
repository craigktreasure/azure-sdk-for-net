// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> A copy activity SQL Data Warehouse sink. </summary>
    public partial class SqlDWSink : CopySink
    {
        /// <summary> Initializes a new instance of SqlDWSink. </summary>
        public SqlDWSink()
        {
            Type = "SqlDWSink";
        }

        /// <summary> Initializes a new instance of SqlDWSink. </summary>
        /// <param name="type"> Copy sink type. </param>
        /// <param name="writeBatchSize"> Write batch size. Type: integer (or Expression with resultType integer), minimum: 0. </param>
        /// <param name="writeBatchTimeout"> Write batch timeout. Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). </param>
        /// <param name="sinkRetryCount"> Sink retry count. Type: integer (or Expression with resultType integer). </param>
        /// <param name="sinkRetryWait"> Sink retry wait. Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). </param>
        /// <param name="maxConcurrentConnections"> The maximum concurrent connection count for the sink data store. Type: integer (or Expression with resultType integer). </param>
        /// <param name="additionalProperties"> . </param>
        /// <param name="preCopyScript"> SQL pre-copy script. Type: string (or Expression with resultType string). </param>
        /// <param name="allowPolyBase"> Indicates to use PolyBase to copy data into SQL Data Warehouse when applicable. Type: boolean (or Expression with resultType boolean). </param>
        /// <param name="polyBaseSettings"> Specifies PolyBase-related settings when allowPolyBase is true. </param>
        /// <param name="allowCopyCommand"> Indicates to use Copy Command to copy data into SQL Data Warehouse. Type: boolean (or Expression with resultType boolean). </param>
        /// <param name="copyCommandSettings"> Specifies Copy Command related settings when allowCopyCommand is true. </param>
        /// <param name="tableOption"> The option to handle sink table, such as autoCreate. For now only &apos;autoCreate&apos; value is supported. Type: string (or Expression with resultType string). </param>
        internal SqlDWSink(string type, object writeBatchSize, object writeBatchTimeout, object sinkRetryCount, object sinkRetryWait, object maxConcurrentConnections, IDictionary<string, object> additionalProperties, object preCopyScript, object allowPolyBase, PolybaseSettings polyBaseSettings, object allowCopyCommand, DWCopyCommandSettings copyCommandSettings, object tableOption) : base(type, writeBatchSize, writeBatchTimeout, sinkRetryCount, sinkRetryWait, maxConcurrentConnections, additionalProperties)
        {
            PreCopyScript = preCopyScript;
            AllowPolyBase = allowPolyBase;
            PolyBaseSettings = polyBaseSettings;
            AllowCopyCommand = allowCopyCommand;
            CopyCommandSettings = copyCommandSettings;
            TableOption = tableOption;
            Type = type ?? "SqlDWSink";
        }

        /// <summary> SQL pre-copy script. Type: string (or Expression with resultType string). </summary>
        public object PreCopyScript { get; set; }
        /// <summary> Indicates to use PolyBase to copy data into SQL Data Warehouse when applicable. Type: boolean (or Expression with resultType boolean). </summary>
        public object AllowPolyBase { get; set; }
        /// <summary> Specifies PolyBase-related settings when allowPolyBase is true. </summary>
        public PolybaseSettings PolyBaseSettings { get; set; }
        /// <summary> Indicates to use Copy Command to copy data into SQL Data Warehouse. Type: boolean (or Expression with resultType boolean). </summary>
        public object AllowCopyCommand { get; set; }
        /// <summary> Specifies Copy Command related settings when allowCopyCommand is true. </summary>
        public DWCopyCommandSettings CopyCommandSettings { get; set; }
        /// <summary> The option to handle sink table, such as autoCreate. For now only &apos;autoCreate&apos; value is supported. Type: string (or Expression with resultType string). </summary>
        public object TableOption { get; set; }
    }
}