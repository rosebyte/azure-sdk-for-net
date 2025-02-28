// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> A valid `GeoJSON MultiPolygon` object type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.7) for details. </summary>
    internal partial class GeoJsonMultiPolygon : GeoJsonGeometry
    {
        /// <summary> Initializes a new instance of GeoJsonMultiPolygon. </summary>
        /// <param name="coordinates"> Contains a list of valid `GeoJSON Polygon` objects. **Note** that coordinates in GeoJSON are in x, y order (longitude, latitude). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public GeoJsonMultiPolygon(IEnumerable<IList<IList<IList<double>>>> coordinates)
        {
            Argument.AssertNotNull(coordinates, nameof(coordinates));

            Coordinates = coordinates.ToList();
            Type = GeoJsonObjectType.GeoJsonMultiPolygon;
        }

        /// <summary> Initializes a new instance of GeoJsonMultiPolygon. </summary>
        /// <param name="type"> Specifies the `GeoJSON` type. Must be one of the nine valid GeoJSON object types - Point, MultiPoint, LineString, MultiLineString, Polygon, MultiPolygon, GeometryCollection, Feature and FeatureCollection. </param>
        /// <param name="coordinates"> Contains a list of valid `GeoJSON Polygon` objects. **Note** that coordinates in GeoJSON are in x, y order (longitude, latitude). </param>
        internal GeoJsonMultiPolygon(GeoJsonObjectType type, IList<IList<IList<IList<double>>>> coordinates) : base(type)
        {
            Coordinates = coordinates;
            Type = type;
        }

        /// <summary> Contains a list of valid `GeoJSON Polygon` objects. **Note** that coordinates in GeoJSON are in x, y order (longitude, latitude). </summary>
        public IList<IList<IList<IList<double>>>> Coordinates { get; }
    }
}
