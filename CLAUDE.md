# Discogs Roulette - Claude Code Context

## Project Overview
A Blazor Server web application that connects to the Discogs API to display a user's record collection and randomly select albums for listening.

## Tech Stack
- **Framework**: Blazor Server (.NET 8)
- **CSS**: Bootstrap 5 (included with Blazor template)
- **API**: Discogs API v2
- **Deployment**: Docker container on home server (Portainer)

## Project Structure
```
DiscogsRoulette/
├── Components/           # Blazor components (.razor files)
│   ├── Layout/          # Layout components (MainLayout, NavMenu)
│   └── Pages/           # Page components (routable)
├── Services/            # Business logic and API clients
│   └── DiscogsService.cs
├── Models/              # Data models/DTOs
├── wwwroot/             # Static files (CSS, JS, images)
├── Program.cs           # Application entry point
└── appsettings.json     # Configuration
```

## Key Conventions
- Use dependency injection for services
- Keep components focused and small
- Models go in `/Models` directory
- API interaction logic goes in `/Services`
- Use `@inject` for service injection in components
- Prefer async/await patterns for API calls

## Discogs API Notes
- Base URL: `https://api.discogs.com`
- Collection endpoint: `/users/{username}/collection/folders/0/releases`
- Requires User-Agent header
- Rate limited: 60 requests/minute for authenticated, 25 for unauthenticated
- Consider pagination for large collections (default 50 per page)

## MVP Features (Current Focus)
1. [ ] Username input form
2. [ ] Fetch and display collection from Discogs
3. [ ] Random album selector button
4. [ ] Display selected album details

## Future Features (Not Yet Implemented)
- Authentication with Discogs OAuth
- Filtering by genre/year/format
- "Recently played" tracking
- Album cover image display
- Integration with music streaming services

## Development Commands
```bash
# Run the application
dotnet run

# Run with hot reload
dotnet watch

# Build for production
dotnet publish -c Release

# Build Docker image
docker build -t discogs-roulette .

# Run Docker container locally
docker run -p 8080:8080 discogs-roulette
```

## Environment Variables
- `Discogs__UserAgent`: User-Agent string for Discogs API (required)
- `Discogs__PersonalAccessToken`: Optional, for higher rate limits

## Common Issues & Solutions
- **CORS errors**: Discogs API should be called server-side only (Blazor Server handles this)
- **Rate limiting**: Implement caching and respect 60 req/min limit
- **Large collections**: Use pagination, load progressively

## Code Style Preferences
- Use file-scoped namespaces
- Prefer primary constructors where appropriate
- Use nullable reference types
- XML documentation for public APIs
