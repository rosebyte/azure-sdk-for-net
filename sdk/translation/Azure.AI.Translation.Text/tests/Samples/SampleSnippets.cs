﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Text.Tests;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class SampleSnippets : SamplesBase<TextTranslationTestEnvironment>
    {
        [Test]
        public TextTranslationClient CreateTextTranslationClient()
        {
            #region Snippet:CreateTextTranslationClient

#if SNIPPET
            string endpoint = "<Text Translator Resource Endpoint>";
            string apiKey = "<Text Translator Resource API Key>";
            string region = "<Text Translator Azure Region>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint), region);
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithKey()
        {
            #region Snippet:CreateTextTranslationClientWithKey

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;

#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey));
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithRegion()
        {
            #region Snippet:CreateTextTranslationClientWithRegion

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
            string region = "<Text Translator Azure Region>";
#else
            string apiKey = TestEnvironment.ApiKey;
            string region = TestEnvironment.Region;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), region);
            #endregion

            return client;
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithEndpoint()
        {
            #region Snippet:CreateTextTranslationClientWithEndpoint

#if SNIPPET
            string endpoint = "<Text Translator Resource Endpoint>";
            string apiKey = "<Text Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            TextTranslationClient client = new TextTranslationClient(new AzureKeyCredential(apiKey), new Uri(endpoint));
            #endregion

            return client;
        }

        public class CustomTokenCredential : TokenCredential
        {
            public CustomTokenCredential(AzureKeyCredential azureKeyCredential): base()
            {
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public TextTranslationClient CreateTextTranslationClientWithToken()
        {
            #region Snippet:CreateTextTranslationClientWithToken

#if SNIPPET
            string apiKey = "<Text Translator Resource API Key>";
#else
            string apiKey = TestEnvironment.ApiKey;
#endif
            TokenCredential credential = new CustomTokenCredential(new AzureKeyCredential(apiKey));
            TextTranslationClient client = new(credential);

            #endregion

            return client;
        }

        [Test]
        public async void GetTextTranslationLanguagesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesAsync
            try
            {
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationLanguagesMetadataAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesMetadataAsync
            try
            {
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync().ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operation: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for transliterate operation: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for dictionary operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationLanguagesByScopeAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesByScopeAsync
            try
            {
                string scope = "translation";
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(scope: scope).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationLanguagesByCultureAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationLanguagesByCultureAsync
            try
            {
                string acceptLanguage = "es";
                Response<GetLanguagesResult> response = await client.GetLanguagesAsync(acceptLanguage: acceptLanguage).ConfigureAwait(false);
                GetLanguagesResult languages = response.Value;

                Console.WriteLine($"Number of supported languages for translate operations: {languages.Translation.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Transliteration.Count}.");
                Console.WriteLine($"Number of supported languages for translate operations: {languages.Dictionary.Count}.");

                Console.WriteLine("Translation Languages:");
                foreach (var translationLanguage in languages.Translation)
                {
                    Console.WriteLine($"{translationLanguage.Key} -- name: {translationLanguage.Value.Name} ({translationLanguage.Value.NativeName})");
                }

                Console.WriteLine("Transliteration Languages:");
                foreach (var transliterationLanguage in languages.Transliteration)
                {
                    Console.WriteLine($"{transliterationLanguage.Key} -- name: {transliterationLanguage.Value.Name}, supported script count: {transliterationLanguage.Value.Scripts.Count}");
                }

                Console.WriteLine("Dictionary Languages:");
                foreach (var dictionaryLanguage in languages.Dictionary)
                {
                    Console.WriteLine($"{dictionaryLanguage.Key} -- name: {dictionaryLanguage.Value.Name}, supported target languages count: {dictionaryLanguage.Value.Translations.Count}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAsync
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationBySourceAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationBySourceAsync
            try
            {
                string from = "en";
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationAutoDetectAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAutoDetectAsync
            try
            {
                string targetLanguage = "cs";
                string inputText = "This is a test.";

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetMultipleTextTranslationsAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetMultipleTextTranslationsAsync
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test.",
                    "Esto es una prueba.",
                    "Dies ist ein Test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationMatrixAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationMatrixAsync
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs", "es", "de" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;

                foreach (TranslatedTextItem translation in translations)
                {
                    Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");

                    Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationFormatAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFormatAsync
            try
            {
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<html><body>This <b>is</b> a test.</body></html>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, textType: TextType.Html).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationFilterAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFilterAsync
            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "<div class=\"notranslate\">This will not be translated.</div><div>This will be translated. </div>"
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, textType: TextType.Html, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationMarkupAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationMarkupAsync
            try
            {
                string from = "en";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The word <mstrans:dictionary translation=\"wordomatic\">wordomatic</mstrans:dictionary> is a dictionary entry."
            };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, sourceLanguage: from).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationProfanityAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationProfanityAsync
            try
            {
                ProfanityAction profanityAction = ProfanityAction.Marked;
                ProfanityMarker profanityMarkers = ProfanityMarker.Asterisk;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is ***."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, profanityAction: profanityAction, profanityMarker: profanityMarkers).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationAlignmentAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationAlignmentAsync
            try
            {
                bool includeAlignment = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, includeAlignment: includeAlignment).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Alignments: {translation?.Translations?.FirstOrDefault()?.Alignment?.Proj}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationSentencesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentencesAsync
            try
            {
                bool includeSentenceLength = true;

                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "The answer lies in machine translation. This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, includeSentenceLength: includeSentenceLength).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Source Sentece length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.SrcSentLen)}");
                Console.WriteLine($"Translated Sentece length: {string.Join(",", translation?.Translations?.FirstOrDefault()?.SentLen?.TransSentLen)}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationFallbackAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationFallbackAsync
            try
            {
                string category = "<<Category ID>>";
                IEnumerable<string> targetLanguages = new[] { "cs" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "This is a test."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, category: category).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {translation?.DetectedLanguage?.Language} with score: {translation?.DetectedLanguage?.Score}.");
                Console.WriteLine($"Text was translated to: '{translation?.Translations?.FirstOrDefault().To}' and the result is: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTextTranslationSentencesSourceAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentencesSourceAsync
            try
            {
                string sourceLanguage = "zh-Hans";
                string sourceScript = "Latn";
                IEnumerable<string> inputTextElements = new[]
                {
                    "zhè shì gè cè shì。"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements, language: sourceLanguage, script: sourceScript).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        public async void GetTextTranslationSentencesAutoAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTextTranslationSentencesAutoAsync
            try
            {
                IEnumerable<string> inputTextElements = new[]
                {
                    "How are you? I am fine. What did you do today?"
                };

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputTextElements).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetTransliteratedTextAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTransliteratedTextAsync
            try
            {
                string language = "zh-Hans";
                string fromScript = "Hans";
                string toScript = "Latn";

                string inputText = "这是个测试。";

                Response<IReadOnlyList<TransliteratedText>> response = await client.TransliterateAsync(language, fromScript, toScript, inputText).ConfigureAwait(false);
                IReadOnlyList<TransliteratedText> transliterations = response.Value;
                TransliteratedText transliteration = transliterations.FirstOrDefault();

                Console.WriteLine($"Input text was transliterated to '{transliteration?.Script}' script. Transliterated text: '{transliteration?.Text}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        public async void GetTranslationTextTransliteratedAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetTranslationTextTransliteratedAsync
            try
            {
                string fromScript = "Latn";
                string fromLanguage = "ar";
                string toScript = "Latn";
                IEnumerable<string> targetLanguages = new[] { "zh-Hans" };
                IEnumerable<string> inputTextElements = new[]
                {
                    "hudha akhtabar."
                };

                Response<IReadOnlyList<TranslatedTextItem>> response = await client.TranslateAsync(targetLanguages, inputTextElements, sourceLanguage: fromLanguage, fromScript: fromScript, toScript: toScript).ConfigureAwait(false);
                IReadOnlyList<TranslatedTextItem> translations = response.Value;
                TranslatedTextItem translation = translations.FirstOrDefault();

                Console.WriteLine($"Source Text: {translation.SourceText.Text}");
                Console.WriteLine($"Translation: '{translation?.Translations?.FirstOrDefault()?.Text}'.");
                Console.WriteLine($"Transliterated text ({translation?.Translations?.FirstOrDefault()?.Transliteration?.Script}): {translation?.Translations?.FirstOrDefault()?.Transliteration?.Text}");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void FindTextSentenceSentenceBoundariesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:FindTextSentenceBoundariesAsync
            try
            {
                string inputText = "How are you? I am fine. What did you do today?";

                Response<IReadOnlyList<BreakSentenceItem>> response = await client.FindSentenceBoundariesAsync(inputText).ConfigureAwait(false);
                IReadOnlyList<BreakSentenceItem> brokenSentences = response.Value;
                BreakSentenceItem brokenSentence = brokenSentences.FirstOrDefault();

                Console.WriteLine($"Detected languages of the input text: {brokenSentence?.DetectedLanguage?.Language} with score: {brokenSentence?.DetectedLanguage?.Score}.");
                Console.WriteLine($"The detected sentece boundaries: '{string.Join(",", brokenSentence?.SentLen)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void LookupDictionaryEntriesAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:LookupDictionaryEntriesAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                string inputText = "fly";

                Response<IReadOnlyList<DictionaryLookupItem>> response = await client.LookupDictionaryEntriesAsync(sourceLanguage, targetLanguage, inputText).ConfigureAwait(false);
                IReadOnlyList<DictionaryLookupItem> dictionaryEntries = response.Value;
                DictionaryLookupItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

                Console.WriteLine($"For the given input {dictionaryEntry?.Translations?.Count} entries were found in the dictionary.");
                Console.WriteLine($"First entry: '{dictionaryEntry?.Translations?.FirstOrDefault()?.DisplayTarget}', confidence: {dictionaryEntry?.Translations?.FirstOrDefault()?.Confidence}.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void GetGrammaticalStructureAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:GetGrammaticalStructureAsync
            try
            {
                string sourceLanguage = "en";
                string targetLanguage = "es";
                IEnumerable<InputTextWithTranslation> inputTextElements = new[]
                {
                    new InputTextWithTranslation("fly", "volar")
                };

                Response<IReadOnlyList<DictionaryExampleItem>> response = await client.LookupDictionaryExamplesAsync(sourceLanguage, targetLanguage, inputTextElements).ConfigureAwait(false);
                IReadOnlyList<DictionaryExampleItem> dictionaryEntries = response.Value;
                DictionaryExampleItem dictionaryEntry = dictionaryEntries.FirstOrDefault();

                Console.WriteLine($"For the given input {dictionaryEntry?.Examples?.Count} examples were found in the dictionary.");
                DictionaryExample firstExample = dictionaryEntry?.Examples?.FirstOrDefault();
                Console.WriteLine($"Example: '{string.Concat(firstExample.TargetPrefix, firstExample.TargetTerm, firstExample.TargetSuffix)}'.");
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        public async void HandleBadRequestAsync()
        {
            TextTranslationClient client = CreateTextTranslationClient();

            #region Snippet:HandleBadRequestAsync
            try
            {
                var translation = await client.TranslateAsync(Array.Empty<string>(), new[] { "This is a Test" }).ConfigureAwait(false);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        public void CreateLoggingMonitor()
        {
            #region Snippet:CreateLoggingMonitor

            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();

            #endregion
        }
    }
}
