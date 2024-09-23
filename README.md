# Unity Game Design - Apple Picker

Hello, this is the first project for CS382: Game Design Using Unity and C#. The objective of the Apple Picker project is to gain experience with using the Unity Engine and programing in C#. 

## Current Objectives and Issues

## Changelog Quicklook

### 22 September, 2024

- ADDED Score UI
- MODIFIED scripts for score keeping
- MODIFIED scripts to reset Apple objects after failing to catch
- MODIFIED scripts for counting Basket objects as lives
- MODIFIED scripts for reseting game should Basket objects (lives) run out
- ADDED and Modified scripts for HighScore and keeping highscore between play sessions
- MODIFIED Apple object to GoodApple
- ADDED BadApple object
    - Color Purple
    - Collecting results in failing to catch GoodApple object
- ADDED a "Start Screen"
    - First Screen Player sees
    - Start button redirects to Scene "_Scene_0"
- ADDED a "Game Over Screen"
    - Restart button redirects to Scene "_Scene_0"
    - Start Screen button reedirects to Scene "_Scene_1"
- MODIFIED UI_Score to include a round number at center top
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
- ADDED Final Score Display

### 20 September, 2024

- CREATION of the Apple Picker project
- ADDED README
- ADDED Unity Project Apple Picker
- ADDED Prefab/Object Tree
    - ADDED Tree_Leaves
        - Color light green
    - ADDED Tree_Trunk
        - Color dark brown
- ADDED Prefab/Object Apple
    - Color bright red
- ADDED Prefab/Object Basket
    - Color dull yellow
- MODIFIED Camera settings and set aspect ration to 1920x1080
- ADDED script for AppleTree object to move and drop apples
- ADDED script for Apple object to delete itself after falling out of bounds
