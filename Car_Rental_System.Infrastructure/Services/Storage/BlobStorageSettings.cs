namespace Car_Rental_System.Infrastructure.Services.Storage;
internal class BlobStorageSettings
{
    public const string Section = "BlobStorageSettings";
    public string ConnectionString { get; set; } = null!;
    public string ContainerName { get; set; } = null!;
    public string AccountName { get; set; } = null!;
    public string AccountKey { get; set; } = null!;
}