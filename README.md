# 15-Days-15-Games-Day-06-Fruit-Frenzy

This is the sixth game from my "15 Days 15 Games" challenge. It's a 2D arcade "catcher" game where the player collects falling fruits and avoids bombs.

## 🚀 About the Game
The player controls a basket at the bottom of the screen, moving horizontally to catch various fruits that fall from the top. Each fruit caught increases the score. If a fruit is missed, the score is penalized. If the player catches a bomb, the game ends. The objective is to achieve the highest score possible.

## 💡 Technical Highlights
* **Engine:** Unity (2D)
* **GameManager Singleton:** A central `GameManager` script uses the singleton pattern to manage the game state, score, UI, and all spawning logic.
* **Tag-Based Collision System:** The `Player` script handles interactions by using a series of `if` statements to check the `tag` of the colliding object (e.g., "Apple", "Bomb"). This approach directly links object tags to gameplay outcomes.
* **Individual Spawning Logic:** The `GameManager` contains separate variables and `InvokeRepeating` calls for each of the five item types. The spawn rates for each item are randomized at the beginning of each game to ensure varied gameplay sessions.
* **Prefab-Specific Logic:** Each fruit prefab has its own script (e.g., `Watermelon.cs`) which is responsible for detecting when it moves off-screen and applying a score penalty.

## ▶️ Play the Game!
You can play the game in your browser on its itch.io page:
**https://shanmukha.itch.io/fruit-frenzy**
