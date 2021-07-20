// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

VAR fire = false

->Abandoned_Wreckage

===Abandoned_Wreckage===

The crew are standing by, what are your orders?
* Send our a sonar pulse. 
->Sonar
* Move close to the surface and survey the area with the periscope.
->Periscope
* Stay hidden.
->Hide

=Sonar
~ encounter = true
‘Unidentified vessel detected, around 100m from our position, Commander.’
* {torpedo > 1} It must be a Kraken vessel. FIRE AT WILL. (-1 ammo)
~ torpedo = torpedo - 1
->Fire
* Activity report on the unknown vessel.
->Report
* Move close to the surface and survey the area with the periscope.
->Periscope

=Fire
The vessel appears to be be taking no evasive action. It must be destroyed or disabled. With no other vessels detected, you surface and salvage what you can. There's not much, mainly scrap and bodies, but you can't help thinking if using a torpedo was really necessary.
// Collateral + 1
~encounter = false
~fuel = fuel+1
~fire = true
->Before_End

=Report
‘The object is stationary, Commander.’
->Report_2


=Report_2
'Awaiting further orders.'
*Picked up anything with the hydrophone?
'Negative.'
Hmm, no sound means that there is no engine running. They're not expecting anything, or...
->Report_2
+Surface and investigate.
->Investigate
+Move close to the surface and survey the area with the periscope.
->Periscope
+It's best to leave it alone, move on.
->Hide


=Investigate
~encounter = false
You find a wreckage of a cargo ship. This must have been the work of a Kraken destroyer. There is nothing left, except some salvageable fuel. 
~fuel = fuel+2
* {fire==false} Wait...
->Extra_crew 
* {fire==true} Seems like there's nothing else here. 
->Before_End


=Periscope
~ encounter = true
‘This is the only thing of note, Commander.’ 
// Load Periscope Image
It looks like a...
*Wreck
->Periscope_2
*Strange vessel
->Periscope_2
*Good place for an ambush, let's move on.
->Hide


=Periscope_2
What do you want to do?
+ {torpedo > 1} Fire. (-1 ammo)
~ torpedo = torpedo - 1
->Fire_surface
+Wait.
->Nothing
*Move in and investigate.
->Investigate
*It's best to leave it alone, move on. 
->Hide


=Fire_surface
Direct hit. Silence.
// Collateral + 1
~fire=true
->Periscope_2


=Nothing
Nothing happens. 
->Periscope_2


=Hide
~encounter = false
There's no point in taking uncessary risks. Before you get on your way, your crew takes advantage of the calm to make some repairs to the hull.
~hull = hull+1
->Before_End


=Extra_crew
...before you give the order to dive once again, when you spot something moving. You move in closer and find a man frantically waving his arms from atop a piece of wreckage. You bring him aboard and he offers to join your crew. 
*Welcome aboard.
~crew=crew+1
->Before_End

=Before_End
*Time to move on.
~end = true
->END