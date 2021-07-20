// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR end = false

->one
=== one ===
You reach the next marker on your navigation chart. Everything seems still and silent. At least there are no Kraken ambushes to be seen.

* I'm sure there will be many to come.
    -> two
* I can't let the crew see my fear.
    -> two
* We’ll be ready for those bastards.
    -> two
    
=== two ===
Nevertheless, it may be worth investigating the area. As you expected, you find a tiny island, known to be friendly to the UAN.

* You tell them of your mission, and one of the locals offers to join your crew.
    ~ crew = crew + 1
    -> three
* You tell them of your mission, and they offer to give you some valuable torpedoes.
    ~ torpedo = torpedo + 2
    -> three
* You tell them of your mission, and they give you some much-needed fuel.
    ~ fuel = fuel + 2
    -> three
    
=== three ===
* The journey can only get more treacherous from here. I order the crew to take us deeper into enemy waters.
~ end = true
-> END