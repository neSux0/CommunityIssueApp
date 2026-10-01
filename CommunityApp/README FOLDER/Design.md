# Design Workflow Process

## Updated: October 1, 2026

## 1. Project Scope

The Community Issue Reporting Application is a **C# WinForms learning project** primarily created to practice relational database design and Entity Framework Core.

The application simulates a community issue-reporting system where:

- Community users report local problems.
- Other users can agree with those reports.
- Department users manage reported issues.
- Community users can confirm when work has been completed.

The primary database-learning objectives are now complete. I do not currently plan to significantly expand this project and intend to move on to another project after possibly experimenting with one small AI-related feature.

---

# 2. Technology Stack

The application uses:

- C#
- .NET WinForms
- Entity Framework Core
- SQLite
- LINQ
- Git / GitHub

Basic architecture:

```text
WinForms UI
    ↓
C# Application Logic
    ↓
Entity Framework Core
    ↓
SQLite Database
```

---

# 3. User Workflow

## Community User

A community user can:

- Create an account
- Log in
- View reported issues
- Create an issue
- Add a description, location, and image
- Agree with an issue
- Remove their own issue
- Confirm that an issue has been resolved

## Department User

A department user can:

- Log in
- View reported issues
- Accept an issue
- Change issue status
- Mark work as ready for community verification
- Remove issue posts

---

# 4. Issue Status Workflow

The current issue workflow is:

```text
Submitted
    ↓
In Progress
    ↓
Waiting User Approval
    ↓
Completed
```

### Submitted
The issue has been created and stored in the database.

### In Progress
A department user has accepted the issue and is working on it.

### Waiting User Approval
The department indicates that the work has been completed.

Community users can now confirm whether the issue was actually resolved.

### Completed
The required number of completion confirmations has been reached.

---

# 5. Database Models

## User

```text
User
----
UserId
Username
Password
IsDepartment
```

`UserId` is the primary key.

`Username` has a unique database index.

---

## Issue

```text
Issue
-----
IssueId
UserId
Description
Location
ImagePath
CreatedAt
WorkStatus
```

`IssueId` is the primary key.

`UserId` identifies the user who created the issue.

---

## IssueVote

```text
IssueVote
---------
UserId
IssueId
ConfirmedIssue
ConfirmedComplete
```

`IssueVote` stores voting information for a specific user and issue.

It uses the composite primary key:

```text
(UserId, IssueId)
```

This prevents duplicate voting records for the same user and issue combination.

---

# 6. Database Relationships

## One-to-Many

A user can create many issues.

```text
User 1 ─────────< Many Issues
```

Each issue belongs to one user through:

```text
Issue.UserId → User.UserId
```

---

## Many-to-Many

Voting creates a conceptual many-to-many relationship.

A user can interact with many issues, and an issue can receive interactions from many users.

```text
User >──── IssueVote ────< Issue
```

`IssueVote` acts as the junction entity.

The same record stores:

```text
ConfirmedIssue
ConfirmedComplete
```

for that user/issue combination.

---

# 7. Voting Design

When a user agrees with an issue:

```text
User clicks Agree
      ↓
Find IssueVote using
(UserId, IssueId)
      ↓
Create record if necessary
      ↓
Toggle ConfirmedIssue
      ↓
Save changes
```

This allows a user to add or remove their agreement without creating duplicate rows.

Completion confirmation uses the same `IssueVote` record through:

```text
ConfirmedComplete
```

---

# 8. Issue Ownership and Permissions

Issue ownership is determined using database IDs rather than comparing C# object references.

Example:

```csharp
CurrIssue.User.UserId == AppData.CurrentUser.UserId
```

This is important because two C# objects can represent the same database user while still being separate objects in memory.

Community users can remove their own issues.

Department users have additional issue-management permissions.

---

# 9. Persistence

The application originally stored data only in memory.

It was later converted to use **Entity Framework Core and SQLite**.

The database now persists:

- Users
- Issues
- Issue status
- Agreement votes
- Completion votes

A typical database operation follows:

```text
User action
    ↓
WinForms event handler
    ↓
AppDataContext
    ↓
Entity Framework Core
    ↓
SQLite
    ↓
SaveChanges()
```

The SQLite database is stored in the user's local application-data directory rather than using a relative path.

---

# 10. Main Concepts Learned

This project helped me practice:

- CRUD operations
- Primary keys
- Foreign keys
- One-to-many relationships
- Many-to-many relationships
- Junction entities
- Composite primary keys
- Unique indexes
- Entity Framework Core
- SQLite
- EF Core migrations
- LINQ queries
- Navigation properties
- Persistent vs. in-memory data
- Database identity vs. object reference identity
- Synchronizing database changes with a WinForms UI
- Git branches, commits, pull requests, and merges

---

# 11. Current Limitations

This is a learning project and is not intended to be production ready.

Current limitations include:

- Passwords are not securely hashed
- Authentication is simplified
- Input validation is basic
- Images are stored using local file paths
- No automated test suite
- No cloud deployment
- Some business logic remains inside WinForms event handlers
- The voting model could be strengthened further with explicit database foreign-key constraints

---

# 12. Future Direction

The main database-learning goal of this project has been completed.

I currently plan to move on to another project rather than continue significantly expanding this application.

I may add one small AI-related experiment, such as:

- Categorizing an issue
- Suggesting the responsible department
- Summarizing an issue report
- Detecting potentially similar reports

The AI feature would be a small learning extension rather than a major redesign of the application.