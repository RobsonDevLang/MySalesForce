## Como Replicar para Novos Serviços

Para criar um novo serviço (ex: `Sales Service`), siga estes passos:

1. **Criar estrutura de pastas:**

   ```
   sales-service/
   ├── Controllers/
   ├── DTO/
   ├── Mappers/
   ├── Models/
   ├── Services/
   ├── Repositories/
   └── Sales.Api.csproj
   ```

2. **Criar o projeto:**

   ```powershell
   EX.:
   dotnet new webapi -n Sales.Api -o sales-service
   ```

3. **Implementar as camadas na ordem:**
   - Model → DTO → Mapper → Service → Controller

4. **Registrar no `run-all.ps1`:**

   ```powershell
   @{ Name = "Sales Service"; Project = "sales-service/Sales.Api.csproj" }
   ```

5. **Registrar no `Program.cs` do serviço:**
   ```csharp
   builder.Services.AddControllers();
   ```
