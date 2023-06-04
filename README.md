# TreeNodes

# Requirements

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker](https://docs.docker.com/get-docker)

To start the required app's infrastructure via Docker, type the following command at the solution directory:

`docker compose up -d`

# Datebase commands
## Add migration
`dotnet ef migrations add Init -p TreeNode.Persistence -s TreeNode.Api`

## Update database
`dotnet ef database update -p TreeNode.Persistence -s TreeNode.Api`