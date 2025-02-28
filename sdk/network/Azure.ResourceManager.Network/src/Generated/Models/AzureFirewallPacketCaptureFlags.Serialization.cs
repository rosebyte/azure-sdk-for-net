// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class AzureFirewallPacketCaptureFlags : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(FlagsType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(FlagsType.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static AzureFirewallPacketCaptureFlags DeserializeAzureFirewallPacketCaptureFlags(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AzureFirewallPacketCaptureFlagsType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new AzureFirewallPacketCaptureFlagsType(property.Value.GetString());
                    continue;
                }
            }
            return new AzureFirewallPacketCaptureFlags(Optional.ToNullable(type));
        }
    }
}
