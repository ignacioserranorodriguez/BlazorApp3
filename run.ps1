# File: run.ps1

# Navigate to the project directory
Set-Location -Path "$PSScriptRoot"

# Function to stop and remove the containers
function Stop-DockerCompose {
    Write-Host "Stopping and removing Docker containers..."
    docker-compose down
}

# Function to wait for Docker containers to be ready
function Wait-ForDockerContainers {
    Write-Host "Waiting for Docker containers to be ready..."
    $containers = docker-compose ps -q
    foreach ($container in $containers) {
        while ($true) {
            $status = docker inspect -f '{{.State.Status}}' $container
            if ($status -eq 'running') {
                break
            }
        }
    }
    Write-Host "Docker containers are ready."
}

# Function to wait for MySQL service to be healthy
function Wait-ForMySQL {
    Write-Host "Waiting for MySQL service to be healthy..."
    $mysqlContainer = docker-compose ps -q mysql
    while ($true) {
        $healthStatus = docker inspect -f '{{.State.Health.Status}}' $mysqlContainer
        if ($healthStatus -eq 'healthy') {
            break
        }
        Start-Sleep -Seconds 1  # Check every 1 second
    }
    Write-Host "MySQL service is healthy."
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

    # Wait for Docker containers to be ready
    Wait-ForDockerContainers

    # Wait for MySQL service to be healthy
    Wait-ForMySQL

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