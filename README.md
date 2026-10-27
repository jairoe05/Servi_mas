# Servi+ (Servi_mas): Banca en línea

Aplicación web bancaria hecha con **ASP.NET MVC 5 y Entity Framework 6 sobre SQL Server**. Simula los servicios de un banco: clientes, cuentas, transferencias web y transferencias móviles usando el número de teléfono como identificador.

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![ASP.NET MVC 5](https://img.shields.io/badge/ASP.NET-MVC%205-512BD4)
![Entity Framework 6](https://img.shields.io/badge/ORM-Entity%20Framework%206-68217A)
![SQL Server](https://img.shields.io/badge/DB-SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/UI-Bootstrap%203-7952B3?logo=bootstrap&logoColor=white)

## Funcionalidades

| Módulo | Descripción |
|---|---|
| **Usuarios** | Registro de clientes (cédula, nombre, apellido, teléfono, provincia) |
| **Tipos de cuenta** | Catálogo de tipos de cuenta (ahorro, corriente, etc.) |
| **Cuentas** | Cuentas bancarias asociadas a un cliente, con su saldo |
| **Transferencias** | Movimientos entre cuentas |
| **Transferencias web** | Envío de dinero desde una cuenta a un número de teléfono |
| **Afiliación móvil** | Asociación de un teléfono a una cuenta, con un monto de transacción configurable |
| **Transferencias SM** | Transferencias móviles de teléfono a teléfono |
| **Autenticación** | Login y gestión de cuentas con ASP.NET Identity (OWIN) |

Cada módulo tiene su controlador y vistas CRUD (Index, Create, Details, Edit, Delete) con Razor.

## Arquitectura

```
Navegador
   │
   ▼
Controllers/ (MVC 5) ──► Models/ (EF6 Database First, Model1.edmx)
   │                              │
   ▼                              ▼
Views/ (Razor + Bootstrap)    SQL Server: Banco1
```

## Base de datos

En la carpeta `BD/` hay respaldos de SQL Server:

- `Banco1.bak`: base principal de la aplicación
- `BancoCentral.bak`: base auxiliar del "banco central"

## Requisitos

- Windows + Visual Studio 2015 o posterior
- .NET Framework 4.5.2
- SQL Server (Express o superior) y SQL Server Management Studio

## Ejecución

1. Restaura `BD/Banco1.bak` (y `BancoCentral.bak` si lo necesitas) en tu SQL Server.
2. Abre `Web_Page/Web_Page.sln`.
3. En `Web.config`, actualiza las cadenas `Banco1ConnectionString` y `Banco1Entities` con tu servidor y credenciales.
4. Restaura los paquetes NuGet y ejecuta con IIS Express (F5).

## Estructura

```
Servi_mas/
├── BD/                      # Respaldos .bak de SQL Server
└── Web_Page/
    ├── Web_Page.sln
    └── Web_Page/
        ├── Controllers/     # Cuentas, Usuarios, Tranferencias*, AfiliacionMBs, Account...
        ├── Models/          # Entidades EF + Model1.edmx
        ├── Views/           # Vistas Razor por módulo
        └── App_Start/       # Rutas, bundles, Identity
```
