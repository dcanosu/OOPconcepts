# STAGE 1: Bulid
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY MySolution/Backend/Backend.csproj ./Backend/
COPY MySolution/Frontend/Frontend.csproj ./Frontend/

RUN dotnet restore Frontend/Frontend.csproj

# Copy everything else and build app
COPY MySolution/Backend/ ./Backend/
COPY MySolution/Frontend/ ./Frontend/

WORKDIR "/src/Frontend"
RUN dotnet publish "Frontend.csproj" -c Release -o /app/publish

# STAGE 2: Runtine
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Add user and group for running the application
RUN groupadd -r appgroup && useradd -r -g appgroup appuser
RUN chown -R appuser:appgroup /app
USER appuser

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Frontend.dll"]