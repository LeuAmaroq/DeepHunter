// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

-> Prologue 

===Prologue===
=Start
*EMERGENCY ACTION MESSAGE[...]
->Continue

=Continue
From: UAN High Command
To: UAN Hunter
The unthinkable has happened. By the time you receive this message, it will be all over for us. We have detected a massive nuclear launch from Kraken Isle that will overwhelm our defense system.
* Keep on reading
->Continue2

=Continue2
Our whole nation will be destroyed and the surrounding area will be permanently irradiated.
As commander of the UAN Hunter, the first and only nuclear-equipped submarine to be created in the Archipelago, you will do what we trained you to do: 
*Retaliate with full force!
->Prologue_2

===Prologue_2===
Using any means necessary, get close enough to the Kraken home island to launch the retaliatory nuclear payload. 
You may be our last surviving vessel, and our only hope for vengeance. 
Good luck, Commander. 
END TRANSMISSION
*[Start Mission]

~ end = true
->END