// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes the connection monitor endpoint filter item. </summary>
    public partial class ConnectionMonitorEndpointFilterItem
    {
        /// <summary> Initializes a new instance of ConnectionMonitorEndpointFilterItem. </summary>
        public ConnectionMonitorEndpointFilterItem()
        {
        }

        /// <summary> Initializes a new instance of ConnectionMonitorEndpointFilterItem. </summary>
        /// <param name="itemType"> The type of item included in the filter. Currently only 'AgentAddress' is supported. </param>
        /// <param name="address"> The address of the filter item. </param>
        internal ConnectionMonitorEndpointFilterItem(ConnectionMonitorEndpointFilterItemType? itemType, string address)
        {
            ItemType = itemType;
            Address = address;
        }

        /// <summary> The type of item included in the filter. Currently only 'AgentAddress' is supported. </summary>
        public ConnectionMonitorEndpointFilterItemType? ItemType { get; set; }
        /// <summary> The address of the filter item. </summary>
        public string Address { get; set; }
    }
}
