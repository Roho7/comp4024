# COMP4024 - Software Engineering Management 

```
  ______ ______   _____  _     _ ______      __ 
 / _____|_____ \ / ___ \| |   | (_____ \    /  |
| /  ___ _____) ) |   | | |   | |_____) )  /_/ |
| | (___|_____ (| |   | | |   | |  ____/     | |
| \____/|     | | |___| | |___| | |          | |
 \_____/      |_|\_____/ \______|_|          |_|
```

[Trello Board](https://trello.com/w/userworkspace72299105)

Leo Meyler: psylm10@nottingham.ac.uk

                                

## Documentation
### Week 1: [Documentation](./weekly-reports/week1/week1-Ideas.md)

What will we be looking for in the lab:
- Have you all got access to Unity?
- Have you set up Git (or equivalent)?
- Have you decided on an idea for a game? Is it appropriate?
- Have you got sketches for a game?
- Have you thought about the user?
- Have you thought about the learning outcome(s)?
- Have you thought about the game mechanic?
- Do you have a plan for what you are going to do by next week?

---
### Week 2: 
---
### Week 3:
---

## Assignment
You have formed groups of roughly 6 people each. You need to create an
educational game suitable for children aged 11-14 years. It is up to you what
game you decide to do. The game can be 2D or 3D. It must be developed
using Unity. However, the main assessment criteria are based on how you
work as a group. Thus, it is not the final product that is of concern – though
there must be some final product to get a mark. You will need to learn to use
Git, plan your project, and develop it based on use cases and tests. Make
sure not to spend more time on this project than it deserves for marks. That
means you do a total of 50 hours work each over the period which should
leave you with a simple playable game at a minimum. 


# Git Usage

Making a standardised git commits throughout the whole project.

## Pushing Commits
Before commits are pushed to main from local, remember to do this checklist:
1. Always take the **latest pull** from Main 
2. Describe the **fixes** or **features** added
3. **Code must be compiled on local, do not push buggy code!**


## Commit Message Format
All Commit Messages **MUST** meet this Format:

```
[<Type>: <Subject>]
<<<<BLANK LINE>>>>
[Author: <Firstname> <<University Email>>]
[Date: <Date> @ <Time>]
<<<<BLANK LINE>>>>
[<Message Body>]
```


## Types

| Type          | Description |
|:-------------:|-------------|
| `feat`        | for new feature implementing commit |
| `update`      | for update commit |
| `fix`         | for bug fix commit |
| `refactor`    | for refactoring commit |
| `docs`        | for documentation commit |
| `test`        | for testing commit |
| `wip`         | for work in progress commit |


## Author and Date
The author should be first name with first letter **capitalised** and **university email** next to the name. The date should be the date should be in **DD/MM/YY** format and time be in 24 hour **HH:MM** format.

## Subject
The subject contains a brief description of the change:

* use the past tense: "changed" not "change" nor "changes"
* don't capitalize first letter
* no dot (.) at the end


## Message Body
Just as in the **Subject**, use the past tense: "changed" not "change" nor "changes". The body should include the motivation for the change. This is **optional**, for when more information is needed to explain commit.


## Examples

new feature:
```
feat: added 'changeWidth' option

Author: John <psyjd1@nottingham.ac.uk>
Date: 01/01/24 @ 23:45
```

bug fix:
```
fix: stoped code breaking when width < 0.1

Author: John <psyjd1@nottingham.ac.uk>
Date: 02/01/24 @ 12:34

The default graphite width of 10mm has been made the minimum width.
```


