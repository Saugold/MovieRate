# 🎬 MovieRate – Avaliação de Filmes com Angular + .NET API

Projeto fullstack para avaliação de filmes, onde usuários podem buscar filmes, avaliar com nota e comentário, e gerenciar suas reviews (criar, editar, deletar). O sistema também conta com autenticação e cadastro de usuários com JWT.

---

## 🚀 Funcionalidades

- 🔍 Buscar filmes usando a API pública do [TMDb](https://www.themoviedb.org/)
- 📝 Avaliar filmes com nota e comentário
- ✏️ Editar e excluir reviews
- 🔐 Cadastro e login com autenticação JWT
- 👤 Cada usuário vê apenas suas próprias reviews
- 💾 Dados persistidos via Entity Framework e banco SQLite

---

## 🧱 Tecnologias Utilizadas

### Frontend – Angular 19.2
- Angular CLI
- Reactive Forms
- Angular Router + Guards
- Consumo de APIs HTTP
- Interceptors (para autenticação)
- Estilização com CSS

### Backend – ASP.NET Core Web API
- ASP.NET Core
- Entity Framework Core
- SQLite
- FluentValidation
- JWT (Autenticação e Autorização)
- Arquitetura em camadas (Controllers, Services, Repositories, DTOs, Validators)

---

## 🗂️ Estrutura do Projeto

```bash
MovieRateAPI/
├── Controllers/
├── Data/
├── DTO/
├── Migrations/
├── Models/
├── Repositories/
├── Services/
├── Validators/
├── appsettings.json
├── Program.cs
└── MovieRate.db (SQLite)
