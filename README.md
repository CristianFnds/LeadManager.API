# LeadManager.API

// criar migrations do projeto
dotnet ef migrations add InitialCreate --startup-project LeadManager.API --project LeadManager.Infrastructure

//Subi as migrations para o banco
dotnet ef database update --startup-project LeadManager.API --project LeadManager.Infrastructure


//Opcional
//criar seeds
dotnet ef migrations add AddSeedData --startup-project LeadManager.API --project LeadManager.Infrastructure

//Subi as seeds para o banco 
