# LifeInsurer – Insurance Claims Management System

## Overview

LifeInsurer is an insurance claims management application developed as part of a technical assignment.

The project aims to demonstrate backend development, software architecture, database management, and event-driven communication.

## Technology Stack

- **Backend:** ASP.NET Core Web API (.NET 10)
- **Database:** SQLite
- **ORM:** Entity Framework Core
- **Messaging:** Apache Kafka
- **Frontend:** Angular

## Architecture

The application will follow a Modular Monolith architecture, separating business domains and application responsibilities into logical modules.

## Development Status

- [x] Project initialization
- [x] Initial dependency configuration
- [ ] Domain and database design
- [ ] Claims management API
- [ ] Kafka integration
- [ ] Angular frontend
- [ ] Testing and documentation

## Getting Started

### Prerequisites

- .NET 10 SDK
- Node.js and npm (for the frontend, when implemented)
- Apache Kafka (for messaging, when implemented)

### Run the backend

```bash
dotnet restore
dotnet build
dotnet run --project LifeInsurer.Api
```

## Project Status

This project is currently under active development.
