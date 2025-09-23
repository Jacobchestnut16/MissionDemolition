# MissionDemolition
example remake of Chapter 30 from [Introduction to Game Design, Prototyping, and Developmentby Jeremy Gibson Bond](https://learning.oreilly.com/library/view/introduction-to-game/9780136619918/ch30.xhtml#ch30lev1sec6)

##Game Prototype Concept

In this game, the player uses a slingshot to fire projectiles at a castle, hoping to demolish it. Each castle has a goal area that the projectile must touch for the player to continue to the next level.

This is the desired sequence of events:

1. When the player’s mouse pointer is in range of the slingshot, the slingshot should glow.
2. If the player presses the left mouse button (mouse button 0 in Unity) down while the slingshot is glowing, a projectile will instantiate at the location of the mouse pointer.
3. As the player moves and drags the mouse around with the button held down, the projectile follows it, yet remains within a specific distance of the slingshot.
4. A white line stretches from each arm of the slingshot around the projectile to make it look like the rubber band of an actual slingshot.
5. When the player releases mouse button 0, the projectile fires from the slingshot.
6. The player’s goal is to knock down a castle that is several meters away and hit a target area inside.
7. The player has a total of three shots to hit the goal. The most recent shot will leave a trail so that the player can better judge their next shot.