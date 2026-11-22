# AI Working Journal

## Session 1 – Initial Architecture

**Task:** Design the backend architecture for LifeInsurer.

**AI suggestion:** Use a modular monolith instead of microservices.

**Decision:** Accepted.

**Reasoning:** The assessment has a 2–3 hour target and a five-hour hard cap. A modular monolith reduces deployment and infrastructure complexity while preserving separation of business responsibilities.

**AI suggestion:** Use REST for synchronous claim operations and Kafka for asynchronous business events.

**Decision:** Accepted, subject to implementation scope.

**Reasoning:** REST provides immediate feedback to users. Kafka allows independent consumers to process claim lifecycle events.

**AI suggestion:** Use SQLite and Entity Framework Core.

**Decision:** Accepted for the local demonstration.

**Reasoning:** Reduces setup overhead and allows the application to run locally without requiring a separate database server.

**Developer reflection:** Architecture decisions should be justified against the assignment's scope rather than selecting technologies simply because they are available.
