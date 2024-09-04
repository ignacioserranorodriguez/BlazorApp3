# File: run.ps1

# Navigate to the project directory
Set-Location -Path "$PSScriptRoot"

# Function to stop and remove the containers
function Stop-DockerCompose {
    Write-Host "Stopping and removing Docker containers..."
    docker-compose down
}

# Register an event handler for Ctrl+C (SIGINT)
$eventHandler = {
    Stop-DockerCompose
    exit
}
$null = Register-EngineEvent -SourceIdentifier ConsoleBreak -Action $eventHandler

try {
    # Run docker-compose up command
    docker-compose up -d

    # Update-Database from NuGet Package Manager Console
    Set-Location -Path "$PSScriptRoot\BlazorApp3"
    dotnet ef database update

    # Run the Blazor web app in the foreground
    dotnet run --project BlazorApp3.csproj
}
catch {
    Write-Host "An error occurred: $_"
}
finally {
    # Ensure Docker containers are stopped
    Stop-DockerCompose
    # Navigate back to the original directory
    Set-Location -Path "$PSScriptRoot"
}