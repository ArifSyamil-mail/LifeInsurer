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

## Session 1 – Database Model

**Task:** Design the data model for claims management system.

**AI suggestion:** A claimant reports a motor accident. They have an insurance policy, submit the claim, attach supporting documents, and the claim enters the assessment queue. A claims officer picks it up, requests additional information, and eventually approves or rejects it.
My next step will be to design the Entity Relationship Diagram (ERD), including primary keys, foreign keys, relationships and important attributes.

**Decision:** Added improvement.
 I would also want to include another role called the Approver, in which when after the claim Officer submit the document, a specific Role called Claim Approver is tasked either to approve or disapprove the application. Because the application could be from the Claimant's side or Claim Officer's side. Thus, I can specify which side has made the error when submitting the form.
Secondly, I also want to see what happens if it fails. Just pick 1 scenario which is when claimant forget to put additional documents, so that at least I can see what pathways can be taken from (1) successful or (2) fail.

**Developer Reasoning:** I would like to add the separation of duties for Claim Officer and Approver Officer, because I want to isolate each process, creating a template that I can scale for other insurance products of different premiums. I can also identify in terms of workflow, which side causes unsucessful application from either claimant's side or the claim officer's side.
