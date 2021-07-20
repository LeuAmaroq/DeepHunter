// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR end = false

->Collision_course

===Collision_course===

‘Commander, we have some bad news. Our C02 scrubbers have malfunctioned. We must have missed it in our checks.’

*What is it?

Before the young submariner can say any more, an alarm starts blaring. You know the sound can only mean that the carbon dioxide levels were dangerously high. 

->Choice_1

=Choice_1

* Emergency surface, NOW!.
->Surface

* We can't risk surfacing.
->Lose_crew

=Surface
The sub finally breaches the surface. However, there’s no time to rest as we are in hostile waters. The lookout spots a ship in the distance. [Ship image]

* It looks like the vessel’s bow. 
->Bow
* It looks like the vessel’s stern. 
->Stern

=Bow
The ship’s bow was indeed pointed directly at us, which meant one thing: we were on a collision course!

* Evasive manoeuvers!
->Evasive

* {torpedo > 0} Fire torpedoes!
~ torpedo = torpedo - 1
->Fire

* Dive!
->Dive

=Evasive
Your submarine turns starboard, but you realise it won't be able to complete the maneuver before being struck. 

*Emergency all-ahead!
-> Ahead



=Fire
Your vessel puts one torpedo 'down the throat' of the oncoming ship. You wait for the horrible sound of a direct hit. 

* ...
->Wait

=Wait
Finally, you receieve confirmation of a confirmed hit. The oncoming vessel is slowed, but not stopped. The torpedo must have only glanced the hull. 
->Further_action

=Further_action
Orders?

* {torpedo > 0} Fire again.
~ torpedo = torpedo - 1
->Fire_2

*Starboard turn.
->Starboard

=Starboard
Orders?
*Port turn, let's have a look at the ship. 
->Ahead

*Starboard turn, let's get out of here. 
->Repair

=Stern
Course of action, Commander?

* Let’s just repair the CO2 scrubbers and get back on track. 
->Collision


=Collision
As the repairs are underway, something doesn’t feel quite right. You look check the distance of the other ship and it has moved closer to your position. What you saw must have been the bow. You are on a collision course!

* Evasive manoeuvers!  
->Hit

* {torpedo > 0} Fire torpedoes!
~ torpedo = torpedo - 1
->Fire

* Dive!
->Dive

=Hit
You begin to move away, but you were too late to act. The bow of the ship strikes the tail of our submarine. 

* {hull >2} After the initial shock subsided, you are amazing to realise you were still in one piece. You assess the damage.  
~hull = hull -1
->Repair

*{hull < 2} That was the last hit you could take.
->Game_Over

=Dive
It seemed for a minute that you had got away with this risky action. However, as you were still just below the surface your vessel is struck by the hull of the unknown ship. You wait a few minutes and surface again in order to repair the damaged CO2 scrubbers. You think better of pursuing the ship.

~hull = hull -1

->Before_End

=Lose_crew
As you retreat to open waters, you notice the air getting unbearably thin. Once you are clear, you order an emergency surface. 

~crew = crew -1

* {crew > 0} Report
->Report

* {crew < 1} There is no answer. Your remaining crew must not have made it. (GAME OVER)
->Game_Over



=Report
Unfortunately we lost a crew member. Your remaining crew manage to get the C02 scrubbers up and running again. There's no time to morn the dead. We still have our mission. 
->Before_End

=Fire_2
This time the torpedo breaches the hull of the ship. The ship collapses in on itself and out spills its cargo and unfortunate crew. You salvage what you can.


~fuel = fuel + 1
~torpedo = torpedo + 2
->Before_End

=Escape
You manage to evade the ship, but you turned away from it. You cannot catch up with it, but at least you're safe for now. You had better hope it wasn't a Kraken scout ship. 
->Repair

=Repair
With the immediate threat gone, your crew manage to get the C02 scrubbers up and running again.
->Before_End

=Ahead
You evade the ship and turn to port to see the profile of the ship. It looks like a Kraken scout ship!

*{torpedo > 0} We cannot allow them to give away our location. Fire!
~ torpedo = torpedo - 1
->Destroy_ship

* We can't do anything with no torpedoes. 
->Repair


=Destroy_ship
The low profile of your sub is hard to spot for even trained scouts. You tail the ship until you can land a direct hit. That's one more enemy ship you don't have to worry about any more. 
~fuel = fuel + 1
~torpedo = torpedo + 2

->Before_End




->Before_End

=Game_Over
GAME OVER
~ crew = 0
~end = true
->END



=Before_End
*We have to keep going.

~end = true

->END