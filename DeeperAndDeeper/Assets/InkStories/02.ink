// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR end = false

->one
=== one ===
The crew are standing by, What are your orders?

* Send our a sonar pulse.
    Unidentified vessel detected, around 100m from our position, Commander.
    -> two
* Survey the area with the periscope.
    This is the only thing of note, Commander. (Periscope image)
    -> two
* Stay hidden. 
    There doesn’t appear to be anything of note. Time to press on.
    ~ end = true
    -> END
    
=== two ===
* {torpedo > 0} It must be a Kraken vessel. FIRE AT WILL.
    Direct hit, Commander.
    The vessel appears to be be taking no evasive action. It must be completely destroyed. With no other vessels detected, you surface and salvage what you can. 
    ~ torpedo = torpedo - 1
    ~ end = true
    -> END
* Activity report on the unknown vessel.
    The object is stationary, Commander.
    -> three
    
=== three ===
Picked up any sound with the hydrophone?
Negative, Commander.
No sound means that there is no engine running.

* Surface and investigate.
    You find a wreckage of a cargo ship. This must have been the work of a Kraken destroyer. There is nothing left, except some salvageable fuel. 
    You are about to give the order to dive once again, when you spot something moving. You move in closer and find a man frantically waving his arms from atop a piece of wreckage. You bring him aboard and he offers to join your crew.
    ~ fuel = fuel + RANDOM(1, 3)
    ~ crew = crew + 1
    -> four
* There’s no time to investigate, move on.
    ~ end = true
    -> END
    
=== four ===
* Nothing left here, move on.
    ~ end = true
    ->END