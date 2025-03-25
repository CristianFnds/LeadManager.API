# LeadManager.API

// criar migrations do projeto
dotnet ef migrations add InitialCreate --startup-project LeadManager.API --project LeadManager.Infrastructure

//Subi as migrations para o banco
dotnet ef database update --startup-project LeadManager.API --project LeadManager.Infrastructure


//Opcional
//criar seeds
dotnet ef migrations add AddSeedData --startup-project LeadManager.API --project LeadManager.Infrastructure

//Subi as seeds para o banco
 dotnet ef database update --startup-project LeadManager.API --project LeadManager.Infrastructure





api
  Controler
    LeadsController
  program.cs
application
    DTO
        LeadDto-- verificar se esta sendo usando
    interfaces
        ILeadService
    Service 
        LeadService
Domain
    Entities
        Lead.cs
        Contact.cs
    Interfaces
        IEmailService
        ILeadrepository
Infrastructure 
    Configurations
        ContactConfigurations
        LeadConfigurations
    Data
    Migration
    Repositories