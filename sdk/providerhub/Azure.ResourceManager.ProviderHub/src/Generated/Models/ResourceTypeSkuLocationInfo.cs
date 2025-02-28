// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceTypeSkuLocationInfo. </summary>
    public partial class ResourceTypeSkuLocationInfo
    {
        /// <summary> Initializes a new instance of ResourceTypeSkuLocationInfo. </summary>
        /// <param name="location"></param>
        public ResourceTypeSkuLocationInfo(AzureLocation location)
        {
            Location = location;
            Zones = new ChangeTrackingList<string>();
            ZoneDetails = new ChangeTrackingList<ResourceTypeSkuZoneDetail>();
            ExtendedLocations = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of ResourceTypeSkuLocationInfo. </summary>
        /// <param name="location"></param>
        /// <param name="zones"></param>
        /// <param name="zoneDetails"></param>
        /// <param name="extendedLocations"></param>
        /// <param name="extendedLocationType"></param>
        internal ResourceTypeSkuLocationInfo(AzureLocation location, IList<string> zones, IList<ResourceTypeSkuZoneDetail> zoneDetails, IList<string> extendedLocations, ProviderHubExtendedLocationType? extendedLocationType)
        {
            Location = location;
            Zones = zones;
            ZoneDetails = zoneDetails;
            ExtendedLocations = extendedLocations;
            ExtendedLocationType = extendedLocationType;
        }

        /// <summary> Gets or sets the location. </summary>
        public AzureLocation Location { get; set; }
        /// <summary> Gets the zones. </summary>
        public IList<string> Zones { get; }
        /// <summary> Gets the zone details. </summary>
        public IList<ResourceTypeSkuZoneDetail> ZoneDetails { get; }
        /// <summary> Gets the extended locations. </summary>
        public IList<string> ExtendedLocations { get; }
        /// <summary> Gets or sets the extended location type. </summary>
        public ProviderHubExtendedLocationType? ExtendedLocationType { get; set; }
    }
}
