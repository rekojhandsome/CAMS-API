﻿using CAMS_API.Models.DTO.AssetRequestDetailDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.Models.DTO.AssetRequestHeaderDTO
{
    public class AssetRequestHeaderModel
    {
        public DateTime assetRequestDate { get; set; } = DateTime.UtcNow;
        public string? status { get; set; }
        public bool requiresApproval { get; set; }

        
    }
}
