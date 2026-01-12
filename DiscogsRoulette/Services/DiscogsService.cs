using DiscogsRoulette.Models;

namespace DiscogsRoulette.Services;

/// <summary>
/// Implementation of the Discogs API client
/// </summary>
public class DiscogsService : IDiscogsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DiscogsService> _logger;

    public DiscogsService(HttpClient httpClient, ILogger<DiscogsService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<CollectionResponse?> GetCollectionAsync(string username, CancellationToken cancellationToken = default)
    {
        // TODO: Implement this method
        // 
        // Steps to implement:
        // 1. Validate username is not null/empty
        // 2. Build the API URL: /users/{username}/collection/folders/0/releases
        // 3. Make the HTTP GET request
        // 4. Handle response status codes (404 for user not found, etc.)
        // 5. Deserialize the JSON response to CollectionResponse
        // 6. Handle any exceptions appropriately
        //
        // Discogs API documentation: https://www.discogs.com/developers/#page:user-collection
        
        throw new NotImplementedException("Implement me!");
    }
}
