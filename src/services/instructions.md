# 🛠️ Como Iniciar os Serviços

Existem duas formas de iniciar os serviços da aplicação:

---

## Opção 1: Usando `dotnet watch run`

Esta é a forma mais simples e direta para desenvolvimento local.

### Passos:

1. Navegue até a pasta do serviço desejado:

```powershell
cd src\services\users-service
```

2. Execute o comando:

```powershell
dotnet watch run
```

> **Dica:** O `dotnet watch` monitora alterações nos arquivos e reinicia automaticamente o serviço quando houver mudanças.

### Para outros serviços:

```powershell
# Sales Service (quando existir)
cd src\services\sales-service
dotnet watch run
```

---

## Opção 2: Usando o Script `run-all.ps1`

Este script inicia todos os serviços simultaneamente em terminais separados e exibe as URLs de cada um.

### Passos:

1. Navegue até a pasta `services`:

```powershell
cd src\services
```

2. Execute o script:

```powershell
.\run-all.ps1
```

### O que o script faz:

- Cria a pasta `logs/` para armazenar os logs de cada serviço
- Abre uma nova janela de terminal para cada serviço
- Executa `dotnet watch` em cada projeto
- Monitora os logs e exibe as URLs quando os serviços ficarem disponíveis
- Limpa os logs anteriores a cada execução

### Estrutura de serviços configurados:

```powershell
$services = @(
    @{ Name = "Users Service"; Project = "users-service/Users.Service.csproj" }
    # @{ Name = "Sales Service"; Project = "sales-service/Sales.Api.csproj" }
)
```

Para adicionar novos serviços, basta adicionar uma nova entrada ao array `$services` no script.

---

## 📌 Recomendação

- **Desenvolvimento rápido de um serviço específico:** Use `dotnet watch run`
- **Desenvolvimento completo (múltiplos serviços):** Use `run-all.ps1`
