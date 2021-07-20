// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

->Intro_Scenario

===Intro_Scenario===
You reach the next marker on your navigation chart. Everything seems still and silent. At least there are no Kraken ambushes to be seen. 
* I’m sure there will be many to come.
->Response
* I can’t show fear in front of my crew.
->Response
* We’ll be ready for those bastards.
->Response


=Response
We are just on the edge of enemy waters. It may be worth investigating the area before moving on. 
* There may be people on these islands willing to join our crew.
->Crew
* We need to be on the look out for opportunities to salvage torpedoes, or we’ll be defenseless.
->Ammo
* Perhaps there will be a friendly cargo vessel that could spare us some fuel. 
->Fuel

=Crew
As you expected, you find a tiny island, known to be friendly to the UAN. You tell them of your mission, and one of the locals offers to join your crew.
~crew=crew+1
->Intro_End

=Ammo
As you expected, you find a tiny island, known to be friendly to the UAN. You tell them of your mission, and they offer to give you some valuable torpedoes.
~temp rand = RANDOM(1,2)
~torpedo=torpedo+rand
->Intro_End

=Fuel
As you expected, you find a tiny island, known to be friendly to the UAN. You tell them of your mission, and they give you some much-needed fuel.
~fuel=10
->Intro_End

=Intro_End
The journey can only get more treacherous from here. 
*[You order the crew to take you deeper into enemy waters.]

~end=true
->END