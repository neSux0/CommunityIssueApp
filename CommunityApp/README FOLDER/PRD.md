# Product Requirements Document (PRD)

## Product Overview

The Community Issue Reporting Application is a **basic mock community-reporting platform** that allows residents to quickly report local problems and allows department users to track and manage those reports.

Examples of reportable issues include:

- Potholes
- Broken traffic lights
- Damaged roads
- Clogged storm drains
- Dead animals
- Other local infrastructure problems

Community users can create an issue by providing a description, location, and optional image. Submitted issues appear in a shared community feed where other users can agree with the report.

Department users can review reported issues, accept them for work, update their status, and indicate when the issue has been resolved.

Community users can then confirm whether the reported problem was actually fixed.

---

## Problem

Reporting community problems can sometimes be inconvenient or confusing.

Residents may need to:

- Find the correct government website or department
- Navigate multiple forms
- Provide unnecessary information
- Remember to report the problem later

As a result, some community problems may go unreported or may not clearly show how many residents are affected.

This application explores a simpler, social-media-style reporting process where residents can quickly submit an issue and allow other community members to confirm that the problem exists.

---

## Primary Goals

The application should:

- Make reporting community issues quick and simple.
- Allow users to post issues directly to a shared feed.
- Allow other users to agree with reported issues.
- Show which issues have greater community interest.
- Allow department users to review and manage issues.
- Allow departments to update the status of an issue.
- Allow community users to confirm whether completed work actually resolved the issue.
- Maintain issue information between application sessions.

---

## User Types

### Community User

Community users should be able to:

- Create an account
- Log in
- View reported issues
- Create an issue
- Add a description and location
- Attach an image
- Agree with another user's issue
- View the current issue status
- Delete their own issue
- Confirm whether an issue has been resolved

### Department User

Department users should be able to:

- Log in
- View reported issues
- Accept an issue for work
- Update an issue's status
- Indicate when work has been completed
- Remove inappropriate or invalid issue posts

---

## Issue Workflow

The intended issue lifecycle is:

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
A community user has created the issue.

Other community users can agree with the report.

### In Progress
A department user has accepted the issue and is working on it.

### Waiting User Approval
The department indicates that the work has been completed.

Community users can confirm whether the issue was actually resolved.

### Completed
The required number of community completion confirmations has been reached.

---

## Voting and Community Feedback

Community interaction is used to represent how strongly an issue affects the community.

The application should allow:

- A user to agree with an issue.
- A user to remove their agreement.
- One voting record per user and issue.
- Community users to confirm issue completion.
- Agreement counts to help indicate community interest or priority.

---

## Project Scope

This application is primarily a **learning project** rather than a production-ready civic reporting platform.

The main purpose is to practice:

- C# application development
- Persistent data storage
- Relational database concepts
- CRUD operations
- User and issue relationships
- Voting relationships
- Application state management
- Git and GitHub workflow

The primary database-learning objectives for this project are now largely complete.

Major continued development is not currently planned. The next learning focus will move toward **ASP.NET Core Web API development** and other backend concepts.

A small AI-related feature may be added as a final experiment, such as:

- Automatically categorizing an issue
- Suggesting the responsible department
- Summarizing an issue report
- Detecting potentially similar reports

---

## Out of Scope

Because this is a learning project, the following are currently outside the intended scope:

- Production deployment
- Production-grade authentication
- Large-scale government integration
- Real department dispatch systems
- Cloud-scale infrastructure
- Advanced security
- Full mobile support
- Large-scale AI functionality