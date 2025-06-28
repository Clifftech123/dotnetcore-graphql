# .NET Core GraphQL Demo

This project demonstrates how to use GraphQL with .NET Core, showcasing a complete implementation of a course management system with students, courses, and course modules.

## 🚀 Features

- **GraphQL API** with Hot Chocolate
- **Entity Framework Core** with SQLite database
- **Domain-Driven Design** architecture
- **CRUD Operations** for Courses, Students, and Course Modules
- **Real-time Subscriptions** for course updates
- **Error Handling** with proper GraphQL error responses
- **Filtering, Sorting, and Projections** support

## 🏗️ Project Structure

```
src/
├── Data/                           # Database context and configurations
│   └── ApplicationDbContext.cs
├── Domain/
│   ├── Configurations/             # Entity Framework configurations
│   │   ├── CourseConfiguration.cs
│   │   ├── CourseModuleConfiguration.cs
│   │   └── StudentConfiguration.cs
│   ├── Contracts/                  # DTOs, Inputs, and Payloads
│   │   ├── CourseDTO.cs
│   │   ├── CourseInputs.cs
│   │   └── CoursePayloads.cs
│   ├── Enum/                       # Domain enumerations
│   │   └── ModuleStatus.cs
│   └── Model/                      # Domain entities
│       ├── Course.cs
│       ├── CourseModule.cs
│       └── Student.cs
├── Extensions/                     # Service registration extensions
│   └── ServiceExtensions.cs
└── GraphqlApi/                     # GraphQL schema definitions
    ├── Common/                     # Shared GraphQL components
    │   ├── Payload.cs
    │   ├── StudentsQuery.cs
    │   └── UserError.cs
    ├── Mutations/                  # GraphQL mutations
    │   └── CourseMutations.cs
    └── Subscriptions/              # GraphQL subscriptions
        └── CourseModuleSubscription.cs
```

## 🛠️ Technologies Used

- **.NET 9.0**
- **Hot Chocolate GraphQL** - GraphQL server implementation
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Lightweight database for development
- **C# 12** - Latest language features

## 📋 Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code
- SQLite (included with EF Core)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git https://github.com/Clifftech123/dotnetcore-graphql.git
cd dotnetcore-graphql
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Run Database Migrations

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

### 5. Access GraphQL Playground

Navigate to `https://localhost:5001/graphql` to access the GraphQL playground and explore the API.

## 📊 GraphQL Schema

### Queries

- **courses** - Get all courses with filtering and sorting
- **students** - Get all students with their enrolled courses

### Mutations

- **createCourse** - Create a new course
- **addModuleToCourse** - Add a module to an existing course
- **enrollStudent** - Enroll a student in a course

### Subscriptions

- **onCourseModuleUpdated** - Real-time updates when course modules chang


## 🏛️ Architecture Highlights

### Domain-Driven Design

- **Entities** with proper encapsulation and business logic
- **Value Objects** and **Enumerations** for type safety
- **Domain Services** for complex business operations

### GraphQL Best Practices

- **Payload Pattern** for mutations with error handling
- **DataLoader** pattern for efficient data fetching
- **Filtering and Sorting** capabilities
- **Real-time Subscriptions** for live updates

### Error Handling

- Structured error responses with error codes
- Business rule validation
- Proper exception handling and logging


## 📝 Database Schema

The application uses the following main entities:

- **Course** - Represents a course with title and modules
- **CourseModule** - Individual modules within a course with status tracking
- **Student** - Students who can enroll in courses

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Cliff Tech** - [GitHub Profile](https://github.com/Clifftech123)

## 🙏 Acknowledgments

- Hot Chocolate GraphQL team for the excellent GraphQL implementation
- Microsoft for Entity Framework Core
- The .NET community for continuous inspiration
