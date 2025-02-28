// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    internal partial class SharePermission : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("permission"u8);
            writer.WriteStringValue(Permission);
            writer.WriteEndObject();
        }

        internal static SharePermission DeserializeSharePermission(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string permission = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("permission"u8))
                {
                    permission = property.Value.GetString();
                    continue;
                }
            }
            return new SharePermission(permission);
        }
    }
}
