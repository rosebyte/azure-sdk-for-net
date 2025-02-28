// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Azure Data Factory expression definition. </summary>
    public partial class DataFactoryExpression
    {
        /// <summary> Initializes a new instance of DataFactoryExpression. </summary>
        /// <param name="expressionType"> Expression type. </param>
        /// <param name="value"> Expression value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataFactoryExpression(DataFactoryExpressionType expressionType, string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            ExpressionType = expressionType;
            Value = value;
        }

        /// <summary> Expression type. </summary>
        public DataFactoryExpressionType ExpressionType { get; set; }
        /// <summary> Expression value. </summary>
        public string Value { get; set; }
    }
}
