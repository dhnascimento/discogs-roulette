using DiscogsRoulette.Models;

namespace DiscogsRoulette.Services;

/// <summary>
/// Service for interacting with the Discogs API
/// </summary>
public interface IDiscogsService
{
    /// <summary>
    /// Fetches a user's collection from Discogs
    /// </summary>
    /// <param name="username">The Discogs username</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection response containing the user's releases</returns>
    Task<CollectionResponse?> GetCollectionAsync(string username, CancellationToken cancellationToken = default);
    
    // TODO: Consider adding pagination support for large collections
    // Task<CollectionResponse?> GetCollectionPageAsync(string username, int page, int perPage, CancellationToken cancellationToken = default);
}
