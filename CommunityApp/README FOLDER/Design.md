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