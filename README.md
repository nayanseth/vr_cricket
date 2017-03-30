# VR Cricket

A net practice game for Cricket in VR.

# Video

https://www.youtube.com/watch?v=zXA498fVVYE

# Instructions

Download the builds folder and run the EXE file. Ensure that you have HTC Vive plugged in to your PC.

# File Information

Note: All files with suffix 1x or @1x are meant for the pitch with correct dimensions.

1. Ball Launcher - Instantiates ball from the ball launcher device
2. Ball Manager - Manages the functionality of ball which gets instantiated i.e. when it hits the bat, the trail behind it, when should it get destroyed, etc
3. Ball Path - Script is attached to bat and controls the force and direction of ball
4. Boundary - Script to draw the boundary. However, it has not been used and a 3D model was created instead;
5. Bowling Manager - Stores user bowling preference
6. Controller Manager - Grabs information about the controller
7. DestroyMe - Global script to destroy GameObjects in the scene
8. DestroySpin - Because spin has been added to ball using force, the ball continues moving in the direction of the force added and hence causes eccentric behaviour. This script destroys the balls not hit by the user if they go past the stumps.
9. FireworksManager - Adds text like milestones achieved during the game and also generates the fireworks when a six or a milestone is achieved.
10. GameObjectManager - Re-instantiates objects like stumps if they fall down or get hit by bat or ball
11. GetBowlingType - Takes the user input value and passes it to BowlingManager
12. GetName - Grabs users name and passes it to Player Manager
13. GetScene - Grabs user input whether he/she wants to play on @1x pitch or @2x pitch
14. GetUserInput - Calls appropriate script based on scene to grab user input
15. Laser - Generates laser pointer from the controller
16. NameManager - Stores the user name for the main scene
17. PitchTrigger - Adds SpinBall script to the instantiated ball
18. PlayerManager - Stores name and is passed on to the next scene
19. SetBowling - Sets the bowling in the main scene
20. SetBowingText - Changes the text to reflect what type of bowler it is
21. SpeedManager - Computes speed of the ball
22. SpinBall - Spins the ball
23. StumpsManager - If the stump get hit by ball or bat, it sets the score to 0 and calls GameObjectManager
24. TextManager - Contains all methods to change respective in-game text
25. Transparency - Random script. Not used anymore. Was meant for adding transparency to the ball. Ended up using in-built shader from SteamVR
26. VariableManager - Stores information about all the variables
