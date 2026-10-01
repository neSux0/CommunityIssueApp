# Community Issue Reporting Application

A C# WinForms learning project that simulates a community issue-reporting platform where users can report local problems, agree with reports, and track their resolution.

The primary purpose of this project was to learn **relational database design and Entity Framework Core integration** with a desktop application.

## Technologies

- C#
- .NET WinForms
- Entity Framework Core
- SQLite
- LINQ
- Git / GitHub

## Features

### Community Users

- Create an account and log in
- Submit community issues
- Add descriptions, locations, and images
- View issues in a shared feed
- Agree with reported issues
- Remove their own issues
- Confirm when an issue has been resolved

### Department Users

- View submitted issues
- Accept issues for work
- Update issue status
- Mark work as ready for community verification
- Remove issue posts

## Issue Workflow

```text
Submitted
    ↓
In Progress
    ↓
Waiting User Approval
    ↓
Completed
```

## Database Design

The application uses **Entity Framework Core with SQLite** for persistent storage.

### User → Issue

A user can create multiple issues.

```text
User 1 ─────────< Many Issues
```

`Issue.UserId` is a foreign key referencing the user who created the issue.

### User ↔ Issue Voting

Voting is modeled using an `IssueVote` junction entity.

```text
User >──── IssueVote ────< Issue
```

`IssueVote` uses a composite primary key:

```text
(UserId, IssueId)
```

This allows:

- One user to interact with many issues
- One issue to receive interactions from many users
- One voting record per user/issue combination

The voting record stores both issue agreement and completion confirmation.

## What I Learned

This project gave me practical experience with:

- Entity Framework Core
- SQLite
- CRUD operations
- Relational database design
- Primary and foreign keys
- One-to-many relationships
- Many-to-many relationships
- Junction tables/entities
- Composite primary keys
- Unique indexes
- LINQ database queries
- EF Core migrations
- Navigation properties
- Persistent vs. in-memory data
- Synchronizing database changes with a WinForms UI
- Git branches, commits, pull requests, and merges

One important lesson was understanding that **C# object identity and database identity are different**. Two objects can represent the same database record without being the same object in memory, so database primary keys are often used when comparing entities.

## Project Status

This project was primarily created as a **database-learning project**, rather than as a production application.

The main database-learning objectives have been completed, and I currently plan to move on to another project rather than continue significantly expanding this application.

I may add one small AI-related feature as a final experiment, such as:

- Identifying potentially similar reports

## Limitations

Because this is a learning project, several production features are intentionally outside its scope, including:

- Secure production authentication
- Password hashing
- Cloud deployment
- Extensive input validation
- Automated testing
- Production-grade authorization
- Cloud image storage