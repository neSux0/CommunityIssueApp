# Design Workflow Process (The Big Picture)
## Date: August 17, 2026.
### Form 1: The Log In Form.
1. Log in to account page.
2. Create an account pop up. Simple checkbox to see if they are gov official. If the box is not checked, they are just a community user.
3. Logging in should close this form and open main feed form.
### Form 2: The main feed form.
1. A basic design with "ISSUES" text on top.
2. A counter with number of users that agrees.
3. A feed containing issues submitted by users with timestamp.
4. A status bar: Pending/Verfied.
5. A log off button.
#### Form2: Public View
1. There should be an option to attach a picture, make it visible, and a description with the issue.
2. They should be able to "like", "Agree" or add to the counter.
3. Users can vote to change "pending complete" to "completed". A user can only vote once.
#### Form2: Department View
1. They can change the status bar to In Progress/pending complete.
2. They could also delete the post.

### Issue Status Workflow

1. Pending
   - Issue has been submitted.
   - Community users can confirm the issue.

2. Verified
   - Issue has received the required number of confirmations.
   - Government/department can now review it.

3. In Progress
   - Department has accepted the issue and is working on it.

4. Pending Completion
   - Department indicates that the issue has been fixed.
   - Community users can vote to confirm completion.

5. Completed
   - Issue has received the required number of completion votes.

   ### Issue Data

Each issue contains:

- Issue ID
- Description
- Location
- Image
- Date/time reported
- Severity
- WorkStatus
- Number of confirmations
- Number of completion votes
- User who created the issue

### User Data

Each user contains:

- User ID
- Username
- Password
- Account type
    - Community
    - Government

### Voting Rules

- A community user can confirm an issue once. The higher the vote the higher the priorty.
- A community user can vote for completion once.
- Users cannot vote on their own issue more than once.
- Once the required number of completion votes is reached, the issue becomes Completed.
### 
#### Models/
    User.cs
    - Public.cs
    - Department.cs
    Issue.cs
    Vote.cs

#### Forms/
    LoginForm.cs
    MainFeedForm.cs
    CreateIssueForm.cs


## UPDATED as of September 17, 2026.
#### DATA
- Will use persistent database.
- Use Entity Framework Core.SqLite.
- The models to be used will be
    ##### Users & Issues
      - UserId is the primary key of User.
      - Issue contains UserId as a foreign key referencing User.UserId.
        