The pixel water fluid system is based on the physics system in the game Noita. It uses basic movements of pixels to simulate physics. The system I have set up isn't the most performant due to 
Unity Raycasting. I could easily make this more performant by simply removing the raycasting from the process and the system should be able to handle a ton of particles at once due to dictionaries. 
The reason I have raycasting implemented is because this system was made for a project and in order to detect the environment as we had it set up, we needed to interact with physics colliders. The only way 
that I know of to detect physics colliders efficiently is with raycasts. The main issue however, is when the system does thousands of raycasts every frame. So again, how do we make this more performant?

1. Utilize the Unity Jobs system. This feature for 2D isn't released yet but, when it is released it should fix the problems. Unity Jobs system will boost the speed of the raycasts by a large percentage. 
2. Stop raycasting every frame. Instead, make the environment part of a grid and use Vector3s rounded to Int's in order to quickly detect collisions. The reason this is faster is because it would happen in constant time.
Raycasting is expensive in bulk.