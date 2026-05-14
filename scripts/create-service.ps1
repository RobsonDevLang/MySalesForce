# Cria um novo microsserviço .NET com estrutura padronizada
# Uso:
# .\scripts\create-service.ps1 [nome da service]-service
# .\scripts\create-service.ps1 product-service
param(
    [string]$ServiceName
)

if (-not $ServiceName) {
    Write-Host ""
    Write-Host "Informe o nome do serviço."
    Write-Host "Exemplo:"
    Write-Host ".\scripts\create-service.ps1 user-service"
    Write-Host ""
    exit
}

if ($ServiceName -match "[\[\]]") {
    Write-Host ""
    Write-Host "Nome de serviço inválido."
    Write-Host "Não utilize colchetes []."
    Write-Host ""
    Write-Host "Exemplo correto:"
    Write-Host ".\scripts\create-service.ps1 product-service"
    Write-Host ""
    exit
}

# =========================================
# Conversão para padrão PascalCase
# product-service -> ProductService
# =========================================

$namespace = ($ServiceName -replace "-service$", "")
$namespace = ($namespace -replace "-", " ")
$namespace = (Get-Culture).TextInfo.ToTitleCase($namespace)
$namespace = $namespace -replace " ", ""

# Nome final do projeto
$projectName = "$namespace.Api"

# Caminho final
$servicePath = "src/services/$ServiceName"

Write-Host ""
Write-Host "========================================="
Write-Host "Criando microsserviço..."
Write-Host "========================================="
Write-Host "Serviço : $ServiceName"
Write-Host "Projeto : $projectName"
Write-Host "Namespace: $namespace"
Write-Host "========================================="
Write-Host ""

# =========================================
# Cria projeto .NET
# =========================================

dotnet new webapi `
-n $projectName `
-o $servicePath

# =========================================
# Entra na pasta
# =========================================

Set-Location $servicePath

# =========================================
# Remove arquivos padrão
# =========================================

Remove-Item WeatherForecast.cs -ErrorAction SilentlyContinue
Remove-Item Controllers\WeatherForecastController.cs -ErrorAction SilentlyContinue

# =========================================
# Estrutura de pastas
# =========================================

mkdir `
Configurations, `
Controllers, `
Data, `
DTO, `
Mappers, `
Middlewares, `
Models, `
Repositories, `
Services, `
Validators

# =========================================
# Subpastas
# =========================================

mkdir `
DTO\Requests, `
DTO\Responses, `
Models\Entities, `
Models\Enums, `
Repositories\Interfaces, `
Services\Interfaces

# =========================================
# Ajusta RootNamespace e AssemblyName
# =========================================

$csprojPath = Join-Path (Get-Location) "$projectName.csproj"

[xml]$csproj = Get-Content $csprojPath

$propertyGroup = $csproj.Project.PropertyGroup

$rootNamespace = $csproj.CreateElement("RootNamespace")
$rootNamespace.InnerText = $namespace

$assemblyName = $csproj.CreateElement("AssemblyName")
$assemblyName.InnerText = $projectName

$propertyGroup.AppendChild($rootNamespace) | Out-Null
$propertyGroup.AppendChild($assemblyName) | Out-Null

$csproj.Save($csprojPath)

# =========================================
# Cria .gitkeep nas pastas vazias
# =========================================

Get-ChildItem -Directory -Recurse | ForEach-Object {
    New-Item `
    -ItemType File `
    -Path "$($_.FullName)\.gitkeep" `
    -Force | Out-Null
}

# =========================================
# Finalização
# =========================================

Write-Host ""
Write-Host "========================================="
Write-Host "Microsserviço criado com sucesso!"
Write-Host "========================================="
Write-Host "Pasta      : $servicePath"
Write-Host "Projeto    : $projectName"
Write-Host "Namespace  : $namespace"
Write-Host "========================================="
Write-Host ""