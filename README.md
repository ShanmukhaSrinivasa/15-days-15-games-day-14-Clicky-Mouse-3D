15-Days-15-Games-Day-14-Clicky-Crates
This is the fourteenth game from my "15 Days 15 Games" challenge. It is a 3D arcade "clicker" game (similar to Fruit Ninja) that features a dynamic difficulty system and data-driven prefabs.

🚀 About the Game
Objects are launched from the bottom of the screen with random forces and torques. The player must click on "good" items (like crates, barrels) to score points, while avoiding "bad" items (bombs). Clicking a bad item costs a life. Letting any item fall back off the screen (triggering a sensor) costs points. The game's speed is determined by a difficulty level chosen by the player on the start screen.

💡 Technical Highlights
Engine: Unity (3D Physics)

Dynamic Difficulty System: The start menu features buttons with a DifficultyButton.cs script. This script passes an int difficulty to the GameManager.GameStart(difficulty) function. This integer is then used as a divisor for the spawnRate, effectively and simply scaling the game's speed based on player selection.

Data-Driven Target Prefabs: A single, flexible Target.cs script is used for all interactable objects. Public variables in the Inspector (like pointValue, minSpeed, maxSpeed, maxTorque, explosionParticle) allow for diverse object behaviors. The script checks its own tag (CompareTag("Bad")) to determine if it's a hazard, making the system highly extensible without new code.

Physics-Based Spawning: Targets are instantiated with a random upward force (Vector3.up * Random.Range(minSpeed, maxSpeed)) and random rotational torque (AddTorque), creating varied and unpredictable movement arcs for the player to track.

Encapsulated Event Logic: The Target.cs script handles its own OnMouseDown event, triggering particle effects (Instantiate(explosionParticle)) and audio (AudioSource.PlayClipAtPoint) directly. This encapsulates all the object's logic and feedback in one place.

Scalable Spawning: The GameManager uses a List<GameObject> targets and a coroutine (SpawnTargets) to randomly instantiate objects from the list, making it easy to add new object types.

▶️ Play the Game!
You can play the game in your browser on its itch.io page: [https://shanmukha.itch.io/clicky-crates]
