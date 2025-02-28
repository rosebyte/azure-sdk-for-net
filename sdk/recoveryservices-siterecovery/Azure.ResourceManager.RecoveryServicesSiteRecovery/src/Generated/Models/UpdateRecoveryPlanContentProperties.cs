// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> Recovery plan update properties. </summary>
    internal partial class UpdateRecoveryPlanContentProperties
    {
        /// <summary> Initializes a new instance of UpdateRecoveryPlanContentProperties. </summary>
        public UpdateRecoveryPlanContentProperties()
        {
            Groups = new ChangeTrackingList<SiteRecoveryPlanGroup>();
        }

        /// <summary> The recovery plan groups. </summary>
        public IList<SiteRecoveryPlanGroup> Groups { get; }
    }
}
