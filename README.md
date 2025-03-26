# LeadManager.API
# Lead Manager Backend

O **Lead Manager Backend** é uma API desenvolvida utilizando o framework **ASP.NET Core** e segue a arquitetura **DDD (Design Driven Development)** para gerenciar leads, com funcionalidades como aceitação de leads, recusa e envio de e-mails. O projeto também usa **Entity Framework Core** para interação com o banco de dados.

## Tecnologias

- **Entity Framework Core**
- **SQL Server** (para persistência de dados)
- **C#**
- **MediatR** (para mediar os comandos e consultas)
- **Swagger** (para documentação da API)
- **SMTP/Email Service** (para envio de e-mails)

## Estrutura do Projeto

O projeto está dividido nas seguintes pastas principais:

- **api**: Contém os controladores da API (exemplo: `LeadsController`).
- **application**: Contém a lógica de negócios e serviços, interfaces e implementações de serviços (exemplo: `LeadService`).
- **domain**: Contém as entidades de domínio (exemplo: `Lead`, `Contact`) e as interfaces que representam as operações necessárias (exemplo: `ILeadRepository`).
- **infrastructure**: Contém a implementação dos repositórios, configurações do Entity Framework e serviços de infraestrutura, como envio de e-mails (exemplo: `EmailService`).
  
## Endpoints

### 1. **GET /all**
Obtém todos os leads da plataforma.

**Resposta**:
- Status 200 OK
- Corpo: Lista de todos os leads.

### 2. **GET /inviteds**
Obtém todos os leads da plataforma sem nenhum status.

**Resposta**:
- Status 200 OK
- Corpo: Lista de todos os leads sem nenhum status.

### 3. **GET /accepteds**
Obtém todos os leads da plataforma sem que está marcado como true no banco na coluna isAccepted.

**Resposta**:
- Status 200 OK
- Corpo: Lista de todos os leads.

### 4. **GET /leads/{id}**
Obtém um lead pelo seu ID.

**Resposta**:
- Status 200 OK
- Corpo: Objeto do lead.

### 5. **POST /leads**
Cria um novo lead.

**Resposta**:
- Status 201 Created
- Corpo: O lead recém-criado.

### 6. **PUT /leads/{id}**
Atualiza dados de um Lead

**Resposta**:
- Status 204 No Content

### 7. **PUT /leads/{id}/accept**
Aceita um lead. Este endpoint irá marcar o lead como aceito.

**Resposta**:
- Status 204 No Content

### 8. **PUT /leads/{id}/reject**
Recusa um lead. Este endpoint irá marcar o lead como recusado.

**Resposta**:
- Status 204 No Content

### 9. **DELETE /leads/{id}**
Deleta um novo lead.

**Resposta**:
- Status 204 No Content

## Requisitos

Para rodar este projeto localmente, você precisa de:

- **.NET 6 ou superior**
- **SQL Server** (local ou remoto)
- **SMTP configurado para envio de e-mails** (caso o envio de e-mails seja parte do fluxo)

### Passos para Configuração

1. Clone o repositório para a sua máquina local:

    ```bash
    git clone https://github.com/CristianFnds/LeadManager.API.git
    ```

2. Navegue até a pasta do projeto:

    ```bash
    cd LeadManager.API
    ```

3. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4. Ajuste a connection string no arquivo appsettings

5. Se você ainda não configurou o banco de dados, execute as migrações com seeds:

    ```bash
    dotnet ef database update --startup-project LeadManager.API --project LeadManager.Infrastructure
    ```

6. Para rodar o projeto:

    ```bash
    dotnet run --project LeadManager.API
    ```
7. Acesse o swagger do projeto ajustando a porta correta de acordo com a saida do console:
        http://localhost:5264/swagger/index.html
   