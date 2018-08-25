// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk" />.
    /// </summary>
    internal class ApplicationScopedVolumeCreationParametersServiceFabricVolumeDiskConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk GetFromJsonProperties(JsonReader reader)
        {
            var description = default(string);
            var sizeDisk = default(SizeTypes?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("description", propName, StringComparison.Ordinal) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("sizeDisk", propName, StringComparison.Ordinal) == 0)
                {
                    sizeDisk = SizeTypesConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk(
                description: description,
                sizeDisk: sizeDisk);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.SizeDisk, "sizeDisk", SizeTypesConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "description", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
