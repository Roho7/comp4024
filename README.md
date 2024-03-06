# COMP4024 - Software Engineering Management

```
  ______ ______   _____  _     _ ______      __
 / _____|_____ \ / ___ \| |   | (_____ \    /  |
| /  ___ _____) ) |   | | |   | |_____) )  /_/ |
| | (___|_____ (| |   | | |   | |  ____/     | |
| \____/|     | | |___| | |___| | |          | |
 \_____/      |_|\_____/ \______|_|          |_|
```

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

## The Team

| Name     | Email                    | Role                          |
| -------- | ------------------------ | ----------------------------- |
| Leo      | psylm10@nottingham.ac.uk | Development + testing         |
| Ringo    | alywl40@nottingham.ac.uk | Game Design + Graphic Design  |
| Patwitra | alypk2@nottingham.ac.uk  | Game Design + Graphic Design  |
| Charlie  | alyjx30@nottingham.ac.uk | Level Design + Graphic Design |
| Hemal    | psyhp2@nottingham.ac.uk  | Documentaion + Development    |
| Rohosen  | psxrb10@nottingham.ac.uk | Development + testing         |

## Weekly Sprints

### Week 1 Sprint

**Overview of Weekly Plan:**

- Everyone has access to Unity
- Set up a Git repo (GitHub)
- Decided on an idea for the game
- Make sketches for the game
- Thought about user requirements
- Thought about the game mechanics

**Detailed Plan:**

- On the [Trello Board: Week 1 Sprint](https://trello.com/b/bZQf9yUQ/week-1-sprint)

**Documentation:**

- [Week Overview](weekly-reports/week1/week1-Overview.md)
- [Meeting Minutes](weekly-reports/week1/week1-Meeting.md)
- [Game Requirements](weekly-reports/week1/week1-Requirements.md)
- [Learning Outcomes](weekly-reports/week1/week1-LearningOutcomes.md)
- [Chosen Game Idea](weekly-reports/week1/week1-FinalGameIdea.md)

---

### Week 2 Sprint

**Overview of Weekly Plan:**

- Know the team members better in terms of their skills, experience and personality types
- Set up a Kanban board with tasks
- Allocate team roles
- Decide on the Minimum Viable Product
- Write some simple tests and code
- Create a main menu screen
- Develop the basic game logic.

**Detailed Plan:**

- On the [Trello Board: Week 2 Sprint](https://trello.com/b/bZQf9yUQ/week-2-sprint)

**Documentation:**

- [Week Overview](weekly-reports/week2/week2-Overview.md)
- [Meeting Minutes](weekly-reports/week2/week2-Meeting.md)
- [Personality Types](weekly-reports/week2/week2-Personality.md)
- [Minimum Viable Product](weekly-reports/week2/week2-MVP.md)
- [User Story](weekly-reports/week2/week2-UserStory.md)

---

### Week 3 Sprint

**Overview of Weekly Plan:**

- Complete the first level design.
- Implement the first level design.
- Compete the first level gameplay.
- Complete menu screen with latest design.
- Convert levels to tile map rendering.
- Create a class diagram and a activity diagram.
- Complete level 2 design.

**Detailed Plan:**

- On the [Trello Board: Week 3 Sprint](https://trello.com/b/bZQf9yUQ/week-3-sprint)

**Documentation:**

- [Week Overview](weekly-reports/week3/week3-Overview.md)
- [Meeting Minutes](weekly-reports/week3/week3-Meeting.md)
- [Test Cases](test-cases.md)
- [Diagrams](weekly-reports/week3/week3-Diagrams.md)
---

### Week 4 Sprint

**Overview of Weekly Plan:**

- Animate player sprite
- Finish level 2 development
- Pick up scoring and hearts logic. 

**Detailed Plan:**

- On the [Trello Board: Week 4 Sprint](https://trello.com/b/bZQf9yUQ/week-4-sprint)

**Documentation:**

- [Sprint Plam](weekly-reports/week4/week4-SprintPlan.md)
- [Week Overview](weekly-reports/week4/week4-Overview.md)
- [test-cases](./test-cases.md)
- [Refactor](weekly-reports/week4/refactors.md)
- [End User Guide](weekly-reports/week4/week4-EndUserGuide.md)

---

### Week 5 Sprint

**Overview of Weekly Plan:**

- Example 1
- Example 2
- Example 3

**Detailed Plan:**

- On the [Trello Board: Week 5 Sprint](https://trello.com/b/bZQf9yUQ/week-5-sprint)

**Documentation:**

- [Week Overview](weekly-reports/week5/week5-Overview.md)
- [Meeting Minutes](weekly-reports/week5/week5-Meeting.md)
- [Deployment Diagram](/weekly-reports/week5/week5-DeploymentDiagram.md)

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
```

## Types

|    Type    | Description                         |
| :--------: | ----------------------------------- |
|   `feat`   | for new feature implementing commit |
|  `update`  | for update commit                   |
|   `fix`    | for bug fix commit                  |
| `refactor` | for refactoring commit              |
|   `docs`   | for documentation commit            |
|   `test`   | for testing commit                  |
|   `wip`    | for work in progress commit         |

## Subject

The subject contains a brief description of the change:

- use the past tense: "changed" not "change" nor "changes"
- don't capitalize first letter
- no dot (.) at the end

## Examples

new feature:

```
feat: added 'changeWidth' option
```

bug fix:

```
fix: stoped code breaking when width < 0.1
```
