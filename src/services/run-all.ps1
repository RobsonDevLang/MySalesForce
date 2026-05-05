# Inicia cada serviço em uma nova janela de terminal
# Start-Process powershell "-NoExit", "dotnet watch run --project users-service/services.csproj"
# Start-Process powershell "-NoExit", "dotnet watch run --project sales-service/sales.csproj"

$services = @(
    @{ Name = "Users Service"; Project = "users-service/Users.Api.csproj" }
    # @{ Name = "Sales Service"; Project = "sales-service/Sales.Api.csproj" }
)

$logsDir = "$PSScriptRoot\logs"
New-Item -ItemType Directory -Force -Path $logsDir | Out-Null

foreach ($service in $services) {
    $project = $service.Project
    $name    = $service.Name
    $logFile = "$logsDir\$name.log"

    # Limpa log anterior
    Clear-Content -Path $logFile -ErrorAction SilentlyContinue

    Start-Process powershell -ArgumentList "-NoExit", "-Command", `
        "`$host.UI.RawUI.WindowTitle = '$name'; dotnet watch --project $project | Tee-Object -FilePath '$logFile'" `
        -WindowStyle Normal

    Start-Sleep -Milliseconds 500
}

Write-Host "✅ Todos os serviços foram iniciados! Aguardando URLs..." -ForegroundColor Green

# Fica monitorando os logs até encontrar todas as URLs
$found = @{}
$timeout = 30  # segundos
$elapsed = 0

while ($found.Count -lt $services.Count -and $elapsed -lt $timeout) {
    Start-Sleep -Seconds 1
    $elapsed++

    foreach ($service in $services) {
        $name = $service.Name
        if ($found.ContainsKey($name)) { continue }

        $logFile = "$logsDir\$name.log"
        if (-not (Test-Path $logFile)) { continue }

        $match = Select-String -Path $logFile -Pattern "Now listening on: (https?://\S+)"
        if ($match) {
            $url = $match.Matches[0].Groups[1].Value
            $found[$name] = $url
            Write-Host "🌐 $name → $url" -ForegroundColor Yellow
        }
    }
}

if ($found.Count -lt $services.Count) {
    Write-Host "⚠️  Timeout: alguns serviços não responderam a tempo." -ForegroundColor Red
}