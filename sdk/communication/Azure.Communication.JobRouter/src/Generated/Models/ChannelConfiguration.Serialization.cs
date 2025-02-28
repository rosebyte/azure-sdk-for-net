// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ChannelConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("capacityCostPerJob"u8);
            writer.WriteNumberValue(CapacityCostPerJob);
            if (Optional.IsDefined(MaxNumberOfJobs))
            {
                writer.WritePropertyName("maxNumberOfJobs"u8);
                writer.WriteNumberValue(MaxNumberOfJobs.Value);
            }
            writer.WriteEndObject();
        }

        internal static ChannelConfiguration DeserializeChannelConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int capacityCostPerJob = default;
            Optional<int> maxNumberOfJobs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("capacityCostPerJob"u8))
                {
                    capacityCostPerJob = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxNumberOfJobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxNumberOfJobs = property.Value.GetInt32();
                    continue;
                }
            }
            return new ChannelConfiguration(capacityCostPerJob, Optional.ToNullable(maxNumberOfJobs));
        }
    }
}
