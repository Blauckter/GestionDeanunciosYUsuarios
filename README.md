# 🧠 Backend de Gestión de Usuarios, Roles, Permisos y Anuncios

Este proyecto es un sistema backend desarrollado en **.NET 9** con **Clean Architecture**, que permite gestionar usuarios, roles, permisos y anuncios, con autenticación JWT y control de acceso basado en permisos.

---

## 🚀 Tecnologías

- .NET 9 (preview)
- Clean Architecture
- Entity Framework Core + SQLite
- JWT Authentication
- Swagger
- Git

---

## 🏗️ Estructura del Proyecto
- `Application/`: Lógica de aplicación (casos de uso, interfaces)
- `Domain/`: Entidades y contratos.
- `Infrastructure/`: Acceso a datos (EF Core, repositorios, migraciones)
- `WebApi/`: Controladores, configuración de endpoints y seguridad.
- `BackendGestionAnuncios.sln`: Archivo de solución para Visual Studio.

- ## 🛠️ Scripts útiles para ejecutar el proyecto
- `Ejecutar el proyecto/`:	dotnet run --project WebApi

## 📦 Colección Postman

Incluye pruebas de login, anuncios, usuarios, roles y permisos protegidos por JWT.

📁 Archivo: `GestionDeAnuncios.postman_collection.json`


