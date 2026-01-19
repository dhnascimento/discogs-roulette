using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscogsRoulette.Models;

/// <summary>
/// Custom JSON converter to handle label IDs that can be either integers or strings
/// (Discogs API returns empty strings or non-numeric values for self-released/bootleg albums)
/// </summary>
public class FlexibleIntConverter : JsonConverter<int?>
{
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                return reader.GetInt32();

            case JsonTokenType.String:
                var stringValue = reader.GetString();
                if (string.IsNullOrWhiteSpace(stringValue))
                    return null;

                if (int.TryParse(stringValue, out var intValue))
                    return intValue;

                // Return null for non-numeric strings like "Not On Label"
                return null;

            case JsonTokenType.Null:
                return null;

            default:
                throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }
    }

    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteNumberValue(value.Value);
        else
            writer.WriteNullValue();
    }
}

/// <summary>
/// Response from the Discogs collection endpoint
/// </summary>
public class CollectionResponse
{
    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; }
    
    [JsonPropertyName("releases")]
    public List<CollectionRelease> Releases { get; set; } = [];
}

/// <summary>
/// Pagination information from Discogs API
/// </summary>
public class Pagination
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("pages")]
    public int Pages { get; set; }
    
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
    
    [JsonPropertyName("items")]
    public int Items { get; set; }

    [JsonPropertyName("urls")]
    public URLs? URLs { get; set; }

}

/// <summary>
/// URLs for pagination requests
/// </summary>
public class URLs
{
    [JsonPropertyName("last")]
    public string? Last { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("prev")]
    public string? Prev { get; set; }
}
/// <summary>
/// A release in the user's collection
/// </summary>
public class CollectionRelease
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("instance_id")]
    public int InstanceId { get; set; }
    
    [JsonPropertyName("date_added")]
    public DateTime DateAdded { get; set; }
    
    [JsonPropertyName("basic_information")]
    public BasicInformation? BasicInformation { get; set; }
}

/// <summary>
/// Basic information about a release
/// </summary>
public class BasicInformation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("thumb")]
    public string? Thumb { get; set; }
    
    [JsonPropertyName("cover_image")]
    public string? CoverImage { get; set; }
    
    [JsonPropertyName("artists")]
    public List<Artist> Artists { get; set; } = [];
    
    [JsonPropertyName("labels")]
    public List<Label> Labels { get; set; } = [];
    
    [JsonPropertyName("formats")]
    public List<Format> Formats { get; set; } = [];
    
    [JsonPropertyName("genres")]
    public List<string> Genres { get; set; } = [];
    
    [JsonPropertyName("styles")]
    public List<string> Styles { get; set; } = [];
    
    /// <summary>
    /// Helper property to get a formatted artist string
    /// </summary>
    [JsonIgnore]
    public string ArtistDisplay => Artists.Count > 0 
        ? string.Join(", ", Artists.Select(a => a.Name)) 
        : "Unknown Artist";
}

/// <summary>
/// Artist information
/// </summary>
public class Artist
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>
/// Record label information
/// </summary>
public class Label
{
    [JsonPropertyName("id")]
    [JsonConverter(typeof(FlexibleIntConverter))]
    public int? Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("catno")]
    public string? CatalogNumber { get; set; }
}

/// <summary>
/// Format information (vinyl, CD, etc.)
/// </summary>
public class Format
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("qty")]
    public string? Quantity { get; set; }
    
    [JsonPropertyName("descriptions")]
    public List<string>? Descriptions { get; set; }
}
