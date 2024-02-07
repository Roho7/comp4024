# COMP4024 - Group Project
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


# Git Commit Message Convention

Making a standardised git commits throughout the whole project.


## Commit Message Format
All Commit Messages **MUST** meet this Format:

```
[<Type>: <Subject>]
<<<<BLANK LINE>>>>
[Author: <Firstname>]
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
The author should be first name with first letter **capitalised**, the date should be the date should be in **DD/MM/YY** format and time be in 24 hour **HH:MM** format.

## Subject
The subject contains a brief description of the change:

* use the past tense: "changed" not "change" nor "changes"
* don't capitalize first letter
* no dot (.) at the end


## Message Body
Just as in the **Subject**, use the past tense: "changed" not "change" nor "changes". The body should include the motivation for the change. 


## Examples

new feature:
```
feat: added 'changeWidth' option

Author: John
Date: 01/01/24 @ 23:45

Added a new feature where the sprite width can be changed in game.
```

bug fix:
```
fix: stoped code breaking when width < 0.1

Author: John
Date: 02/01/24 @ 12:34

The default graphite width of 10mm has been made the minimum width.
```


