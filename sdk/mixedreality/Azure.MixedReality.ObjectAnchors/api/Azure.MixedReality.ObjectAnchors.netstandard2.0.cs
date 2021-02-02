namespace Azure.MixedReality.ObjectAnchors
{
    public partial class AssetConfiguration : Azure.MixedReality.ObjectAnchors.Models.IngestionConfiguration
    {
        public AssetConfiguration(System.Numerics.Vector3 gravity, float scale) : base (default(System.Numerics.Vector3), default(float)) { }
    }
    public partial class IngestionJobCreationOptions
    {
        public IngestionJobCreationOptions(Azure.MixedReality.ObjectAnchors.AssetConfiguration assetConfiguration, System.Uri inputFilePath) { }
        public IngestionJobCreationOptions(System.Numerics.Vector3 assetGravity, Azure.MixedReality.ObjectAnchors.MeasurementUnit unit, System.Uri inputFilePath) { }
        public IngestionJobCreationOptions(System.Numerics.Vector3 assetGravity, float assetScale, System.Uri inputFilePath) { }
        public Azure.MixedReality.ObjectAnchors.AssetConfiguration AssetConfigurationValues { get { throw null; } }
        public string AssetFileType { get { throw null; } }
        public System.Uri InputFilePath { get { throw null; } }
        public System.Guid JobId { get { throw null; } }
    }
    public enum MeasurementUnit
    {
        Unsupported = 0,
        Centimeters = 1,
        Decimeters = 2,
        Feet = 3,
        Inches = 4,
        Kilometers = 5,
        Meters = 6,
        Millimeters = 7,
        Yards = 8,
    }
    public partial class ObjectAnchorsAccount
    {
        public ObjectAnchorsAccount(System.Guid accountId, string accountDomain) { }
        public string AccountDomain { get { throw null; } }
        public System.Guid AccountId { get { throw null; } }
    }
    public partial class ObjectAnchorsClient
    {
        protected ObjectAnchorsClient() { }
        public ObjectAnchorsClient(Azure.MixedReality.ObjectAnchors.ObjectAnchorsAccount account, Azure.AzureKeyCredential keyCredential, Azure.MixedReality.ObjectAnchors.ObjectAnchorsClientOptions? options = null) { }
        public ObjectAnchorsClient(Azure.MixedReality.ObjectAnchors.ObjectAnchorsAccount account, Azure.Core.AccessToken token, Azure.MixedReality.ObjectAnchors.ObjectAnchorsClientOptions? options = null) { }
        public ObjectAnchorsClient(Azure.MixedReality.ObjectAnchors.ObjectAnchorsAccount account, Azure.Core.TokenCredential credential, Azure.MixedReality.ObjectAnchors.ObjectAnchorsClientOptions? options = null) { }
        public virtual Azure.Response<Azure.MixedReality.ObjectAnchors.Models.IngestionProperties> CreateJob(Azure.MixedReality.ObjectAnchors.IngestionJobCreationOptions creationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.ObjectAnchors.Models.IngestionProperties>> CreateJobAsync(Azure.MixedReality.ObjectAnchors.IngestionJobCreationOptions creationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.MixedReality.ObjectAnchors.Models.IngestionProperties> GetJob(System.Guid JobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.ObjectAnchors.Models.IngestionProperties>> GetJobAsync(System.Guid JobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Uri> GetUploadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Uri>> GetUploadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectAnchorsClientOptions : Azure.Core.ClientOptions
    {
        public ObjectAnchorsClientOptions(Azure.MixedReality.ObjectAnchors.ObjectAnchorsClientOptions.ServiceVersion version = Azure.MixedReality.ObjectAnchors.ObjectAnchorsClientOptions.ServiceVersion.V0_2_preview_0, System.Uri? serviceEndpoint = null, System.Uri? authenticationEndpoint = null) { }
        public enum ServiceVersion
        {
            V0_2_preview_0 = 1,
        }
    }
}
namespace Azure.MixedReality.ObjectAnchors.Models
{
    public partial class IngestionConfiguration
    {
        public IngestionConfiguration(System.Numerics.Vector3 gravity, float scale) { }
        public System.Numerics.Vector3? BoundingBoxCenter { get { throw null; } set { } }
        public System.Numerics.Vector3? Dimensions { get { throw null; } set { } }
        public System.Numerics.Vector3? Gravity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.MixedReality.ObjectAnchors.Models.TrajectoryPose> GtTrajectory { get { throw null; } }
        public System.Collections.Generic.IList<int> KeyFrameIndexes { get { throw null; } }
        public System.Numerics.Quaternion? PrincipalAxis { get { throw null; } set { } }
        public float Scale { get { throw null; } set { } }
        public System.Numerics.Vector4? SupportingPlane { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.MixedReality.ObjectAnchors.Models.TrajectoryPose> TestTrajectory { get { throw null; } }
    }
    public partial class IngestionProperties
    {
        public IngestionProperties() { }
        public System.Guid? AccountId { get { throw null; } }
        public string AssetFileType { get { throw null; } set { } }
        public string ClientErrorDetails { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Models.IngestionConfiguration IngestionConfiguration { get { throw null; } set { } }
        public System.Uri InputAssetUri { get { throw null; } set { } }
        public System.Guid? JobId { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Models.JobStatus? JobStatus { get { throw null; } set { } }
        public System.Uri OutputModelUri { get { throw null; } }
        public string ServerErrorDetails { get { throw null; } }
    }
    public enum JobStatus
    {
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
        Cancelled = 4,
    }
    public partial class TrajectoryPose
    {
        public TrajectoryPose() { }
        public System.Numerics.Quaternion Rotation { get { throw null; } set { } }
        public System.Numerics.Vector3 Translation { get { throw null; } set { } }
    }
}
