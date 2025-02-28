// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class CompletionsOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            // CUSTOM: only serialize if prompts is non-empty
            if (Optional.IsCollectionDefined(Prompts) && Prompts.Count > 0)
            {
                writer.WritePropertyName("prompt"u8);
                writer.WriteStartArray();
                foreach (var item in Prompts)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(MaxTokens))
            {
                if (MaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(MaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_tokens");
                }
            }
            if (Optional.IsDefined(Temperature))
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature");
                }
            }
            if (Optional.IsDefined(NucleusSamplingFactor))
            {
                if (NucleusSamplingFactor != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(NucleusSamplingFactor.Value);
                }
                else
                {
                    writer.WriteNull("top_p");
                }
            }
            // CUSTOM: serialize <int, int> to <string, int>
            if (Optional.IsCollectionDefined(TokenSelectionBiases))
            {
                writer.WritePropertyName("logit_bias"u8);
                writer.WriteStartObject();
                foreach (var item in TokenSelectionBiases)
                {
                    writer.WritePropertyName($"{item.Key}");
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
            if (Optional.IsDefined(ChoicesPerPrompt))
            {
                if (ChoicesPerPrompt != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(ChoicesPerPrompt.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
            }
            if (Optional.IsDefined(LogProbabilityCount))
            {
                if (LogProbabilityCount != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteNumberValue(LogProbabilityCount.Value);
                }
                else
                {
                    writer.WriteNull("logprobs");
                }
            }
            if (Optional.IsDefined(Echo))
            {
                if (Echo != null)
                {
                    writer.WritePropertyName("echo"u8);
                    writer.WriteBooleanValue(Echo.Value);
                }
                else
                {
                    writer.WriteNull("echo");
                }
            }
            if (Optional.IsCollectionDefined(StopSequences))
            {
                writer.WritePropertyName("stop"u8);
                writer.WriteStartArray();
                foreach (var item in StopSequences)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PresencePenalty))
            {
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presence_penalty");
                }
            }
            if (Optional.IsDefined(FrequencyPenalty))
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequency_penalty");
                }
            }
            if (Optional.IsDefined(GenerationSampleCount))
            {
                if (GenerationSampleCount != null)
                {
                    writer.WritePropertyName("best_of"u8);
                    writer.WriteNumberValue(GenerationSampleCount.Value);
                }
                else
                {
                    writer.WriteNull("best_of");
                }
            }
            if (Optional.IsDefined(InternalShouldStreamResponse))
            {
                if (InternalShouldStreamResponse != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(InternalShouldStreamResponse.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
            if (Optional.IsDefined(InternalNonAzureModelName))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(InternalNonAzureModelName);
            }
            writer.WriteEndObject();
        }
    }
}
