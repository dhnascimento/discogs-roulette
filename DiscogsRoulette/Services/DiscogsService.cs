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
        if (string.IsNullOrWhiteSpace(username))
            return null;

        try
        {
            var url = $"/users/{username}/collection/folders/0/releases";
            var response = await _httpClient.GetFromJsonAsync<CollectionResponse>(url, cancellationToken);
            return response;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to fetch collection for user {Username}", username);
            return null;
        }
    }
}
