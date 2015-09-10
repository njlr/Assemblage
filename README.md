# Assemblage
A lightweight entity management framework in pure C#, suitable for game development in MonoGame and XNA. 

# 30 Second Demo 
```
// All entities must inherit IEntity

// Create a manager 
var manager = new EntityManager();

// Spawn some entities
var player = manager.Create(new Hero(new Vector2(100f, 100f)));

manager.Create(new Monster(new Vector2(300f, 400f)));
manager.Create(new Monster(new Vector2(-50f, 200f)));
manager.Create(new Monster(new Vector2(200f, -100f)));

// Update the world
manger.Update(dt);

// Game over!
manager.Destroy(player);
```
