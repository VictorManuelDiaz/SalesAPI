# SalesAPI

SalesAPI es una API desarrollada en .NET que implementa la arquitectura hexagonal (también conocida como arquitectura de puertos y adaptadores). Este enfoque permite un desarrollo más flexible y desacoplado, separando la lógica de negocio de las implementaciones específicas de infraestructura.

## Tabla de Contenidos

## Requisitos Previos

- **.NET SDK 6.0 o superior**: Asegúrate de tener instalado el SDK de .NET. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).
- **Visual Studio 2022** o **Visual Studio Code** con la extensión C#.
- **PostgreSQL**: Debes tener un servidor PostgreSQL en funcionamiento.

## Configuración del Proyecto

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/VictorManuelDiaz/SalesAPI.git
   cd SalesAPI
2. **Clonar el repositorio**:
    ```bash
    dotnet restore
## Estructura del Proyecto

El proyecto sigue la arquitectura hexagonal, dividiéndose en las siguientes capas:

- **Domain**: Contiene las entidades de dominio.
- **Application**: Define los casos de uso de la aplicación.
- **Infrastructure**: Implementa detalles técnicos como el uso de repositorios.
- **Adaptadores**: Esta capa interactúa con el contexto de la base de datos para conectar con PostgreSQL y ejecutar las operaciones de lectura y escritura.
- **API**: Controladores y configuraciones de la aplicación web, actuando como punto de entrada.

## Manejo de Migraciones

Para ejecutar las migraciones correctamente, necesitas alternar el proyecto de inicio entre la API y los adaptadores.

- **Establecer como proyecto de inicio: Sales.Adapters.SQLDataAccess.**
- **Aplicar las migraciones.**

## Ejecutar la API


- **Establecer como proyecto de inicio: Sales.Ports.API.**
- **Lanzar la API.**