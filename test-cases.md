# Test Cases

## Main Menu

| ID | Step Description | Expected Result | 
| -- | ---------------- | --------------- |
|1| run main menu | main menu scene should not be loaded into as a playable level |
|2| run main menu | All scenes begonning with 'Level' should be loaded as a playabe level |
|3| run main menu | All playable levels should be added as buttons to the level select container |
|4| run main menu -> click select level | A drop down menu containing button should appear |
|5| test 4 -> click level button | Level correspondong to button should be loaded

## Levels


### Player

| ID | Step Description | Expected Result | 
|----| ---------------- | --------------- |
|1| Load Level -> Press 'up' key | Player should jump into the air |
|2| test 1 -> Press 'up' key immediately | Player should not be able to jump until hitting the floor |
|3| Load Level -> press 'left' Key | Players orientation vector should be set to positive. Player should move in this direction |
|4| Load Level -> press 'right' Key | Players orientation vector should be set to negative. Player should move in this direction |

### Question Area
| ID | Step Description | Expected Result | 
|----| ---------------- | --------------- |
|1| Load Level | Question and text prompts should be set to invisible |
|2| Load Leve1 | Program throws an error if no answer to question has been loaded |
|3| Load Level -> move to question area | Question and text prompts should appear |
|4| test 2 -> move out of question area | Question and text prompts should disappear |
|5| test 2 -> press E key | A text field for the user should appear |
|6| test 5 | the game time should freeze, stopping all enemy movement |
|7| test 5 -> attempt to move player | the player should be unable to move while inputing an answer |
|8| test 4 -> press 'Enter' key | Answer is regected due to invalid input |
|9| test 4 -> input incorrect answer -> press 'Enter' key | Answer is regected due to incorectness |
|10| test 4 -> input correct answer -> press 'Enter' key | Answer is accepted |

### Bullet

| ID | Step Description | Expected Result | 
|----| ---------------- | --------------- |
|1| Load Level -> press 'space' key| projectile should be should be shot to the right |
|2| Load Level -> Move player left -> press 'space' key| projectile should be should be shot to the Left |
|3| Load Level -> shoot enemy| projectile and enemy should be destroyed on collision |
|4| Load level -> shoot wall / any other object | The object should not be destorued but the bullet should be |







