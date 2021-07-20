// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

->Mine_layer

===Mine_layer===
Your vessel continues on its course and reaches the next map marker. No activity of any kind is detected so you tentatively decide to rise to just under the surface and survey the area.
There doesn't seem to be anything awry and you decide to prepare to move on. However, just before you give the order, your passive sonar picks up an object you were in a collision course with. 
*Try to go around. 
->Go_around
*{torpedo > 0}Blow it out of the water. 
-> Fire


=Fire
~torpedo = torpedo - 1
You wait for confirmation of a hit from your crew, but none comes. The object must be too small to hit. There's no point in wasting another torpedo. 
*Try to go around.
->Go_around


=Go_around
You realise that the object had been a sea mine - that's how it was overlooked so easily. You breath a sigh of relief as you weigh up your options. 
*Carefully investigate the area. 
->Investigate
*Dive deeper and get clear.
~end = true
->END


=Investigate
~encounter = true
With your sensors calibrated to detect the smaller threat, you see that you have already had numerous near misses. You feel that you are no longer going to blow up at any second. 
You manage to catch up with the culprit - a Kraken ship laying mines. It must be to help with their civilian blockades. 
*{torpedo > 0} Ambush the ship. 
->Ambush
*{torpedo < 1} You don't have any torpedoes left. You give the order to dive deeper before getting caught.
~encounter = false
~end = true
->END
*{torpedo > 0} You can't risk jeopardising your mission on needless battles. Even if it means leaving who knows how many unwitting ships to their fate...
~encounter = false
~end = true
->END


=Ambush
~torpedo = torpedo - 1
The slow and cumbersome mine laying ship is an easy target for your vessel. The ship is destroyed leaving some useful items for you. 
->Salvage


=Salvage
~fuel = fuel + 2
~torpedo = torpedo + 2
Fuel and torpedoes are always useful. Not to mention that you can rest easy knowing that there are fewer active sea mines in these waters. 
* Time to take care of the real mission.
~encounter = false
~end = true
->END