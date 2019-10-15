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

each npc has - an empty child object with a hitbox manager script. this object has child objects with hitbox scripts. 

hitboxmanager refers to location of npc body parts and pushes hitboxes to them. this is called by npcscript, which is called by npcmanager. 

each npc has an enemyrotation script. this spins the npc in a staggered yet fluid manner when alert. it casts ray before spins so that the npc does not overspin past the player. it stays off until enemy is alert or when enemy utilizes turning action. 

npcs have a spine object that moves to adjust line of sight to player height. enemy weapons have an empoty object that links to npcscript as a muzzle, which moves to aim to the player.

inventory works as follows: 
empty menu object has an inventorymanager script. one child object for inventory, and one for the equipment panel. inventory panel has the invenmtory script, and equiptment panel has the equipment panel script. the inventory has a child object with a grid layout plugin (unity ui default package). the grid has child objects numbered to your liking that are empty, or have an image as a background, and then have an itemslots script attached, with references to each available game item. equipmentslots acts the same way. 

quests will utilize a similar system as the inventory.








        


