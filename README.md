# 🎵 Discogs Roulette

A Blazor Server web application that helps you decide what to listen to from your Discogs collection by randomly selecting an album.

## Features

- Enter your Discogs username to load your collection
- View your record collection
- Let fate decide what you should listen to with the random selector

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A [Discogs](https://www.discogs.com/) account with a public collection

## Getting Started

### Local Development

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/discogs-roulette.git
   cd discogs-roulette
   ```

2. Run the application:
   ```bash
   cd DiscogsRoulette
   dotnet run
   ```

3. Open your browser to `https://localhost:5001` or `http://localhost:5000`

### Using Docker

Build and run with Docker Compose:

```bash
docker-compose up --build
```

Or build manually:

```bash
docker build -t discogs-roulette .
docker run -p 8080:8080 discogs-roulette
```

## Configuration

The application can be configured via environment variables or `appsettings.json`:

| Setting | Description | Required |
|---------|-------------|----------|
| `Discogs:UserAgent` | User-Agent string for Discogs API | Yes |
| `Discogs:PersonalAccessToken` | Discogs API token for higher rate limits | No |

## Development

This project uses:
- **Blazor Server** - For interactive server-rendered UI
- **Bootstrap 5** - For styling
- **Discogs API** - For collection data

### Project Structure

```
DiscogsRoulette/
├── Components/
│   ├── Layout/          # Layout components
│   └── Pages/           # Page components
├── Models/              # Data models
├── Services/            # API services
└── wwwroot/             # Static files
```

## License

MIT

## Acknowledgments

- [Discogs](https://www.discogs.com/) for their excellent API
- The Blazor team at Microsoft
