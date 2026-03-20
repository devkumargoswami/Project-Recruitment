# 🧑‍💼 Recruitment Management System

![.NET](https://img.shields.io/badge/.NET-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![AngularJS](https://img.shields.io/badge/AngularJS-E23237?style=for-the-badge&logo=angularjs&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-3178C6?style=for-the-badge&logo=typescript&logoColor=white)

A full-stack **Recruitment Management Portal** built with **ASP.NET Core (C#)** for backend and **AngularJS** for frontend. This application streamlines the recruitment process — from job postings to candidate management.

---

## 📌 Features

- 📋 **Job Posting Management** — Create, update, and manage job openings
- 👤 **Candidate Management** — Track applicants and their application status
- 🔍 **Application Tracking** — Monitor recruitment pipeline stages
- 🔐 **User Authentication** — Secure login and role-based access
- 📡 **RESTful API** — Clean API layer connecting frontend and backend
- 🗄️ **Database Integration** — Structured SQL Server schema with CRUD operations

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Frontend | AngularJS, TypeScript, HTML5, CSS3 |
| Backend | ASP.NET Core, C# |
| Database | Microsoft SQL Server |
| Architecture | RESTful API, Layered Architecture |
| Tools | Visual Studio, Git, Swagger |

---

## 🏗️ Project Architecture

```
Project-Recruitment/
├── Controllers/       # API Controllers (HTTP endpoints)
├── Business/          # Business Logic Layer
├── Interface/         # Abstractions / Contracts
├── Entity/            # Database Models / Entities
├── DTOs/              # Data Transfer Objects
├── Properties/        # App Configuration
├── Program.cs         # App Entry Point
└── appsettings.json   # Configuration Settings

Project-Recruitment-Web/
├── src/
│   ├── app/           # Angular Components & Modules
│   ├── services/      # API Service Calls
│   └── environments/  # Environment Config
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (v18+)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

---

### ⚙️ Backend Setup

```bash
# 1. Clone the repository
git clone https://github.com/devkumargoswami/Project-Recruitment.git

# 2. Open in Visual Studio or VS Code

# 3. Update connection string in appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=RecruitmentDB;Trusted_Connection=True;"
}

# 4. Run the project
dotnet run
```

---

### 🌐 Frontend Setup

```bash
# 1. Clone the frontend repository
git clone https://github.com/devkumargoswami/Project-Recruitment-Web.git

# 2. Install dependencies
npm install

# 3. Start the development server
ng serve

# 4. Open in browser
http://localhost:4200
```

---

## 📡 API Endpoints (Sample)

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/jobs` | Get all job postings |
| POST | `/api/jobs` | Create new job |
| GET | `/api/candidates` | Get all candidates |
| POST | `/api/candidates` | Add new candidate |
| PUT | `/api/candidates/{id}` | Update candidate status |
| DELETE | `/api/jobs/{id}` | Delete a job posting |

---

## 👨‍💻 Author

**Devkumar Goswami**
- 🌐 GitHub: [@devkumargoswami](https://github.com/devkumargoswami)
- 💼 LinkedIn: [devkumar-goswami](https://linkedin.com/in/devkumar-goswami-12b940332)
- 📧 Email: goswamidev2106@gmail.com

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

> ⭐ If you found this project helpful, please consider giving it a star!
