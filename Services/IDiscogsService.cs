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

    /// <summary>
    /// Fetches a specific page from a user's collection
    /// </summary>
    /// <param name="username">The Discogs username</param>
    /// <param name="page">The page number to fetch (1-indexed)</param>
    /// <param name="perPage">Number of items per page (default 50, max 100)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection response containing the specified page of releases</returns>
    Task<CollectionResponse?> GetCollectionPageAsync(string username, int page, int perPage = 50, CancellationToken cancellationToken = default);
}
