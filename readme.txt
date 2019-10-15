this is an open world game engine for use in unity 3d

implementation is as follows:

a movementmanager script is attached to an empty object: this gets input for player movement

a terrainsmanager script is attached to an empty object: this simply calls all present 16 block scripts, so that only 
one update function occurs for all grids/blocks 

a weaponmanager script is attached to an empty object, and gets inout for player weapons 

an npc manager script is attached to an empty object, and calls objects with NPC scripts. in a larger map, you may utilize multiple 
versions of this attached to terrain pieces (larger than blocks), which will deactivate based on location 

each terrain has an empty child object with a sixteen block script, and this object 16 child objects that are turned on and off by 
the sixteen block script. these child objects hold setpieces.

an empty object named soundbar holds child objects; each child object holds a sound and a oneshot audio script (not present in this build)

an empty object called sunrotator contains the day/night cycle script. this object contains 2 child objects, a sun and a moon. these are to be placed 
a few thousand units away from the (0,0,0) in opposite directions, facing each other. directional lights are best, used with aura2 plugin. 

an empty object called player contains a rotator script, a capsule collider. Its child obejcts are stabspace 1 & 2, and a main stabspace, and a main camera. 

stabspaces1&2 have varying heights. when the player crouches, the actual stabspace changes to either 1 or 2, so that enemies do not clip uder the floor when dragged
by a player stab.

the main camera has child obejcts for each available weapon. optional - aura 2 camera, post processing profile (recommended; implement post processing BEFORE aura 2).

the main camera has a child object titled UI with a HUD script. Three canvases are child objects of this : ammo text, health text, hunger text.

an empty object with a NPCRendercull script. this activates NPCs, checks location, does math, and activates or deactivates based on player location. 
may be called by another script using timers to avoid using Update() function. 

an empty object with animalmanager script, and child objects that are animals with animalscript. similar to NPC setup.








        


