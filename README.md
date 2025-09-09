
# ToDoApp – .NET ile Basit Görev Yönetimi Uygulaması

Bu proje, .NET platformunda geliştirilmiş kapsamlı bir **To‑Do (Yapılacaklar) Uygulaması**dır. Hem **konsol uygulaması** hem de **Web API** ile görev ekleme, listeleme, güncelleme ve silme gibi işlemleri destekler. Katmanlı mimari sayesinde kolayca genişletilebilir.

---

## 📂 Klasör Yapısı

- **Business** – İş mantığı katmanı, servisler ve kurallar burada bulunur.
- **Core** – Tüm katmanlarda ortak kullanılabilecek altyapılar (JWT, Validation, Utilities vb.).
- **DataAccess** – Veritabanı erişim katmanı (Entity Framework Core ile CRUD işlemleri).
- **Entities** – Veri modelleri (Task, User, Role vb.).
- **ConsoleUI** – Komut satırı üzerinden çalışan To‑Do arayüzü.
- **WebAPI** – RESTful API sağlayan katman.
- **ToDoApp.sln** – Çözüm (solution) dosyası.
- **.gitignore**, **.gitattributes** – Git yapılandırma dosyaları.

---

## 🚀 Başlarken

### Gereksinimler
- [.NET 6 SDK](https://dotnet.microsoft.com/download) veya üzeri
- Visual Studio 2022 / Rider / VS Code (isteğe bağlı IDE)
- SQL Server (veya farklı bir veritabanı uyarlaması yapılabilir)

### Kurulum
1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/Cnrygt11/ToDoApp.git
   cd ToDoApp
   ```

2. `ToDoApp.sln` dosyasını Visual Studio veya `dotnet` CLI ile açın.

3. Veritabanını oluşturmak için:
   ```bash
   dotnet ef database update --project DataAccess
   ```

4. Uygulamayı çalıştırın:
   - Konsol uygulaması için: `ConsoleUI` projesini başlatın.
   - Web API için: `WebAPI` projesini çalıştırın.

---

## 🔑 Örnek API Endpoint’leri

- **GET** `/api/tasks` → Tüm görevleri getirir  
- **GET** `/api/tasks/{id}` → Belirli bir görevi getirir  
- **POST** `/api/tasks` → Yeni görev ekler  
- **PUT** `/api/tasks/{id}` → Görevi günceller  
- **DELETE** `/api/tasks/{id}` → Görevi siler  

JSON örnek (POST):
```json
{
  "title": "Kitap oku",
  "description": "Her gün en az 30 dakika kitap oku",
  "isCompleted": false
}
```

---

## ⚙️ Özellikler

- Görev ekleme, listeleme, güncelleme, silme
- Katmanlı mimari (Business, DataAccess, Entities, Core)
- Konsol arayüzü ve RESTful API desteği
- Kullanıcı rolleri ve JWT tabanlı güvenlik (ilerletilebilir)
- FluentValidation desteği
- Kolay genişletilebilir altyapı

---

# ToDoApp – Simple Task Manager with .NET

This project is a **To‑Do application built on .NET**. It provides both a **Console App** and a **Web API** to manage tasks (create, read, update, delete). Thanks to its layered architecture, it is highly extensible.

---

## 📂 Folder Structure

- **Business** – Business logic layer with services and rules.  
- **Core** – Shared abstractions and utilities (JWT, Validation, etc.).  
- **DataAccess** – Database access layer using Entity Framework Core.  
- **Entities** – Data models (Task, User, Role, etc.).  
- **ConsoleUI** – Command-line interface for task management.  
- **WebAPI** – RESTful API layer.  
- **ToDoApp.sln** – Solution file.  
- **.gitignore**, **.gitattributes** – Git configs.  

---

## 🚀 Getting Started

### Requirements
- [.NET 6 SDK](https://dotnet.microsoft.com/download) or later  
- Visual Studio 2022 / Rider / VS Code  
- SQL Server (or another database provider)  

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Cnrygt11/ToDoApp.git
   cd ToDoApp
   ```

2. Open `ToDoApp.sln` in Visual Studio or run with `dotnet` CLI.

3. Create the database:
   ```bash
   dotnet ef database update --project DataAccess
   ```

4. Run the application:
   - Console App → Run `ConsoleUI` project.  
   - Web API → Run `WebAPI` project.  

---

## 🔑 Example API Endpoints

- **GET** `/api/tasks` → Get all tasks  
- **GET** `/api/tasks/{id}` → Get task by ID  
- **POST** `/api/tasks` → Add new task  
- **PUT** `/api/tasks/{id}` → Update task  
- **DELETE** `/api/tasks/{id}` → Delete task  

Sample JSON (POST):
```json
{
  "title": "Read a book",
  "description": "Read at least 30 minutes every day",
  "isCompleted": false
}
```

---

## ⚙️ Features

- Task CRUD operations  
- Layered architecture (Business, DataAccess, Entities, Core)  
- Console interface and RESTful API  
- User roles & JWT authentication (extensible)  
- FluentValidation support  
- Easy to extend and customize  

---

## 🛠 Contributing

1. Fork this repo.  
2. Create a new feature branch (`git checkout -b feature/new-feature`).  
3. Commit your changes (`git commit -m 'Add new feature'`).  
4. Push to your branch (`git push origin feature/new-feature`).  
5. Open a pull request.  

Contributions are welcome 🚀

---

## 📜 License

This project is licensed under the **MIT License**. See the `LICENSE` file for details.

---
