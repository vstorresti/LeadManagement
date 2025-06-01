# Lead Management System

Sistema completo para gerenciamento de Leads, utilizando:

- ✅ Backend: ASP.NET Core (.NET 6) com CQRS e Event Sourcing.
- ✅ Frontend: ReactJS com Axios.
- ✅ Banco de dados: SQL Server 2019.
- ✅ Deploy: Docker e Docker Compose.

---

## ✅ Estrutura do Projeto

- /LeadManagement.API → Backend .NET 6 API
- /LeadManagement.Application → Camada de aplicação
- /LeadManagement.Domain → Entidades, VOs, Enums, Eventos
- /LeadManagement.Infrastructure → Repositórios, Migrations, Serviços
- /frontend/lead-management-frontend → Frontend ReactJS
- /docker-compose.yml → Orquestração com Docker

---

## ✅ Pré-requisitos

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (opcional para desenvolvimento local do backend)
- [Node.js LTS](https://nodejs.org/) (opcional para desenvolvimento local do frontend)

---

## ✅ Como executar o sistema completo com Docker Compose

### ➡️ Build e subir:

docker-compose up --build

| Serviço    | URL                                            |                                   |
| ---------- | ---------------------------------------------- | --------------------------------- |
| Backend    | [http://localhost:5000](http://localhost:5000) |                                   |
| Frontend   | [http://localhost:3000](http://localhost:3000) |                                   |
| SQL Server | localhost:1433                                 | user: sa  pass: Your_password123! |

