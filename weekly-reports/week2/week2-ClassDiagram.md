# 1. Class Diagram

| **MathGame**    |              |           |
| --------------- | ------------ | --------- |
| **Attributes:** | currentLevel |           |
| **Methods:**    | StartGame()  | EndGame() |

| **Player**      |                    |               |
| --------------- | ------------------ | ------------- |
| **Attributes:** | playerName: string | score: int    |
| **Methods:**    | PlayerLogic()      | BulletLogic() |

| **MathChallenge** |                   |               |
| ----------------- | ----------------- | ------------- |
| **Attributes:**   | question: string  | answer: int   |
| **Methods:**      | DisplayQuestion() | CheckAnswer() |

| **Platform**    |              |            |
| --------------- | ------------ | ---------- |
| **Attributes:** | platformType |            |
| **Methods:**    | Display()    | Interact() |

| **Enemy**       |                   |          |
| --------------- | ----------------- | -------- |
| **Attributes:** | enemyType: string |          |
| **Methods:**    | Move()            | Attack() |

| **Reward**      |                    |     |
| --------------- | ------------------ | --- |
| **Attributes:** | rewardType: string |     |
| **Methods:**    | ApplyReward()      |     |
