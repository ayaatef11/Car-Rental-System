﻿using Car_Rental_System.Domain.Constants;

namespace Car_Rental_System.Application.Common.Interfaces;
public interface IBlobStorageService
{
    Task<(string Url, string BlobName)> UploadAsync(string FileName, Stream Data, BlobContainer Container);
    string? GetUrl(string blobName);
    Task DeleteAsync(string blobName);
}

