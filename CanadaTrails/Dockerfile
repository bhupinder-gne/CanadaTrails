# Use the official .NET Core SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file(s) and restore dependencies
COPY ["CanadaTrails.csproj", "./"]
RUN dotnet restore "CanadaTrails.csproj"

# Copy the remaining files and build the application
COPY . .

# Ensure that the /src/Images directory is copied
RUN mkdir -p /src/Images
COPY Images /src/Images

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Ensure that the /app/Images directory is present
RUN mkdir -p /app/Images
COPY --from=build /src/Images /app/Images

# Define entry point
ENTRYPOINT ["dotnet", "CanadaTrails.dll"]