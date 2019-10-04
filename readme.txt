this is an open world game engine for use in unity 3d

documentation is necessary 

setup ---------------------------
scripts call each other


genericNPC obj
	NPC object
          MESHES
          weapon
          animator
          npc script
        hitboxcontroller
          hitboxcontrollerscript
          hitboxes
            hitbox scripts with colliders
        npc rotator

npc manager obj w script

weapon manager obj w script

movementmanager obj w script

sunrotator obj w script
    sun
    moon
    dayandnightscript

player obj
   rotator
   maincamera
     look up down
     weapons
       weaponry
     ui
       hud script

npcrendercull obj w script

terrains
   terrain
     sixteenblock9 w script
        block#
          grabbable weapon w pickupvector script

terrainmanager w gridwatcher




        


