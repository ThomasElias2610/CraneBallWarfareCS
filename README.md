# CraneBallWarfare
**University of haifa CS Project**

[Git Hub Link](https://github.com/ThomasElias2610/CraneBallWarfareCS.git)
## Credits
- Thomas Elias ID: 323088773
- Manar Zoabi ID: 322858150
 
Unity verison we are using, eg  `release/2021.3.11f1`

## General-info
CraneBallWarfare is an engaging and challenging game that combines different warfare concepts to create an exciting and unique gaming experience.
The game is about controlling a crane with the abilities to destroy objects with it’s steel ball and have the ability to catch boxes with it’s magnetic field to heal itself and build defensive walls to protect itself from the bullets, the goal is to stay alive during the clock countdown.

![](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Pic2.png)

The longer you survive, the harder it gets, you will be surrounded with a lot of enemies and needs to be quick and sharp in killing the enemies while staying alive.

![enter image description here](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Pic1.png)

The red boxes are built for healing the crane, grabbing them with the magnetic field and dropping them in the right place in the crane to increase it's health.           
                                           ![https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Health%202.png](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Health%202.png)

Blue boxes are built for stopping the enemies bullets, when dropping them around the crane in the right spot will help to defend the enemies.

![https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Armor.png](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Armor.png)


## How-to-play
To start the game, click the "Play" button. The player will spawn as a crane in the middle of the map with boxes spawning from the sky to reach the ground battle, control the crane using the keys on your keyboard. Use the crane's steel ball to destroy objects and enemies and use the magnetic field to catch boxes to heal and defend yourself.
As you progress through the game, it becomes harder to survive as more enemies surround you, keep an eye on the health bar and grab some armor boxes when you get the opportunity after blowing and gitting rid of a good amount of enemies.


![](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Ex%20of%20HTP.png)


## Controls
- T key: to lift the rope down.
- R key: to lift the rope up.
- Arrow Left/ right: turn the crane left/right.
- Arrow up/down: move the hook forward/ backward.
- F key: change to BigBall/Magnet.
- V key: swing the ball ( when using the BigBall) / Attach the box (when using the magnet).
![https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Controls.png](https://raw.githubusercontent.com/ThomasElias2610/CraneBallWarfareCS/main/Pics/Controls.png) 




## Features
-  Intense gameplay with increasing difficulty as the game progresses.
-   Unique crane-based gameplay mechanics, including a steel ball and magnetic field.
-   Two types of boxes to catch: red boxes to heal the crane and blue boxes to build defensive walls.
- Realistic physics simulation for crane movements and ball impacts.



**Work-Journal**:

1)  Camera control and filter and post processing work (mainly based on a lot of physics).

2) Building the script for the crane mechanic:
-   Controlling the movement of the turret of the crane.
-   Controlling the speed of the turret.
-   Limiting the crane movement.
-   Controlling the rotation and it's speed of the crane.
3)  Building the script for the rope mechanic:
-   Controlling the speed of the upward/donwward of the rope
-   Downsize and upsize the number of the nodes that connected together to single rope
-   Using trail renderer that set the position between all the ropes to view the visual perspective of the rope.
- Putting the inputs of the keyboards to set the controls of the gameplay inside the game
- Building the hook that replaces between magnet prefab and big ball prefab to set a different Uses like:
   -Magnet: to attach the boxes to the magnet.
-Big Ball: To demolish the enemies.

4) The properties of the hook instance, tha magnet, the big ball:
- Attaching the script to control the big ball swing along the rope.
- Define the properties of the physical object such as different mass.
- Using AddForce function to swing the ball acroos the rorarion of the crane.
- Attaching the script to control wich objects that can be attached and magnetized by the magnet, with using raycast that detects them using tags.
5) Boxes that intergrated with the hook instance and the crane:
- Building the main mechanics for the game with three types of the boxes:
-Attackers: The enemies that are firing bullets at the crane wich will lead to loosing health.
-Health: Help to increase the health bar so the crane is able to survive.
-Defend: Boxes that effect the defend shield that is surrounding the crane, to protect it from the enemy bullets.
6) Setting random spawning spots for the boxes and all materials attached:
- Creating a script for the random boxes and random positions around the map.
7) Building all the scripts for the boxes:
- Scripts for all three types of boxes in every affect they have in the game.
- Adding some effects of destruction of the boxes by using unity particle system and materials.
8) Wall defender that surrounds the crane:
- Adding the script for the wall defender that surrounds the crane to protect it againts the bullets.
9) Final touches with th UI and setting the time countdown clock:
- Setting the healt UI inside the cnavas to watch the visual health of the crane.
- Attaching all the UI reference to the game manager for easy configuration in the UI.
- Setting the time countdown script (The time was chosen after an experiment that revolves around 6 people who tried to win the game).
- Setting the restart game.

