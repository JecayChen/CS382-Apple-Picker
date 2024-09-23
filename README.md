# Unity Game Design - Apple Picker

Hello, this is the first project for CS382: Game Design Using Unity and C#. The objective of the Apple Picker project is to gain experience with using the Unity Engine and programing in C#. 

## Current Objectives and Issues

## Changelog Quicklook

### 22 September, 2024

- Added: Score UI
- Modified: scripts for score keeping
- Modified: scripts to reset Apple objects after failing to catch
- Modified: scripts for counting Basket objects as lives
- Modified: scripts for reseting game should Basket objects (lives) run out
- Added: and Modified scripts for HighScore and keeping highscore between play sessions
- Modified: Apple object to GoodApple
- Added: BadApple object
    - Color Purple
    - Collecting results in failing to catch GoodApple object
- Added: a "Start Screen"
    - First Screen Player sees
    - Start button redirects to Scene "_Scene_0"
- Added: a "Game Over Screen"
    - Restart button redirects to Scene "_Scene_0"
    - Start Screen button reedirects to Scene "_Scene_1"
- Modified: UI_Score to include a round number at center top
    - 4 Rounds Max
    - Round counter by power of 10
        - Round 1: 0 - <1,000; need to collect 20; Apples worth 50 points
        - Round 2: 1,000 - <10,000; need to collect 45; Apples worth 200 Points
        - Round 3: 10,000 - <100,000; need to collect 100; Apples worth 900 Points
        - Round 4: 100,000+; Apples worth 1,000
    - Round increase results in:
        - Decrease in Drop Delay: (0.5, 0.75), (0.4, 0.6), (0.3, 0.45), (0.2, 0.3)
        - Increase in Points: 50, 200, 900, 1000
        - Increase in BadApple chance: .05, .07, .09, .1
        - Decrease in Basket Width: 4, 3.33, 2.67, 2
        - Increase in Speed: 20, 30, 40, 50
- Added: Final Score Display

### 20 September, 2024

- Start: of the Apple Picker project
- Added: README
- Added: Unity Project Apple Picker
- Added: Prefab/Object Tree
    - Added: Tree_Leaves
        - Color light green
    - Added: Tree_Trunk
        - Color dark brown
- Added: Prefab/Object Apple
    - Color bright red
- Added: Prefab/Object Basket
    - Color dull yellow
- Modified: Camera settings and set aspect ration to 1920x1080
- Added: script for AppleTree object to move and drop apples
- Added: script for Apple object to delete itself after falling out of bounds
