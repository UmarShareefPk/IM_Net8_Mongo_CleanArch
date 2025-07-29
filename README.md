# TaskHub — Task & Incident Management System

TaskHub is a modern, full-stack task and incident management system built using **.NET 8**, **Angular**, and **MongoDB** following **Clean Architecture** principles with **Bounded Contexts**.

It provides a scalable and extensible foundation for real-world enterprise apps with role-based access control, task lifecycle management, live messaging, and detailed activity tracking.

---

## 🚀 Features

- 🛠 **Task/Incident Lifecycle**
  - Create, assign, and track tasks or incidents
  - Status management: `New`, `InProgress`, `Late`, `Closed`
  - Priority levels: `Low`, `Medium`, `High`, `Critical`
  - Due dates, timestamps, attachments

- 💬 **Real-time Messaging**
  - One-on-one or group messaging between users (SignalR-ready)

- 🧵 **Comments**
  - Threaded comments on tasks/incidents
  - Attachment support

- 📦 **Clean Architecture**
  - Domain-driven design
  - Bounded Contexts: TaskManagement, Identity, Messaging
  - CQRS + MediatR
  - MongoDB repositories with strongly typed documents

- 🧑‍💼 **Role-Based Access**
  - Admins, Moderators, and Assignees
  - User management and audit trails

- 🔍 **Paging, Filtering, Sorting**
  - Fully dynamic pagination support with flexible search and sort

---

## 🧱 Tech Stack

| Layer            | Technology                      |
|------------------|----------------------------------|
| Frontend         | Angular 17+     (To be written) |
| Backend API      | .NET 8 Web API                  |
| Database         | MongoDB                         |
| Architecture     | Clean Architecture + CQRS       |
| Communication    | MediatR, AutoMapper, SignalR    |


---

## 📁 Bounded Contexts

Each feature area is isolated into its own bounded context:

- **TaskManagement**  
  Handles all operations related to tasks, comments, attachments, and notifications.

- **Identity**  
  Manages users, roles, and authentication/authorization.

- **Messaging** *(Planned)*  
  Real-time chat and inbox for user communication.

---

## 🗂 Folder Structure (Simplified)

