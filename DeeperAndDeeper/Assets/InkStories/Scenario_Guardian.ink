// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

VAR rand = 0

->Guardian

===Guardian===
You encounter a lone civilian ship deep in Kraken waters. They detect your presence and hail you. 
'Mayday, mayday. We are under attack! One more torpedo hit and we are gonners!'
*[Move in to investigate.]
->Part_2


=Part_2
~encounter = true
You detect a torpedo closing in on the side of the civilian ship. There's little chance it will miss this large target. 
* [Instruct them to take evasive action.]
->Death
* [Move in to shield the civilian ship with your vessel.]
->Shield
* {torpedo > 0} [Try to shoot the torpedo.]
->Shoot


=Death
It was a slow and damaged ship, and they couldn't move out the way. The ship was destroyed. You decide to get away before the perpetrator finds you too.
~encounter = false
*It's unfortunate, but there's no time to play heroes.
~end = true
->END

=Shield
It was a risky maneuver. The torpedo stikes your hull.
~ rand = RANDOM(1,6)
{
    - rand < 6:
        ~rand = 1
    - else:
        ~rand = 2
}
{
    - hull <= rand:
        ->Deadly_Hit
    - else:
        ->Survive
}

=Deadly_Hit
As you hear your hull breaching and the water storming in, you at least hope this saved the life of innocent civilians.
~encounter = false
*[...]
~hull = 0
~end = true
->END

=Survive
Despite taking a full hit, your sturdy hull holds out.
 ~hull = hull - rand
 ~encounter = false
->Before_end

=Shoot
~torpedo = torpedo - 1
It was a long shot, but your torpedo missed. The ship was destroyed. You decide to get away before the perpetrator finds you too.
// Collateral + 1
*It's unfortunate, but there's no time to play heroes.
~encounter = false
~end = true
->END

=Before_end
You sweep the area and find no trace of the attacking vessel. The civilian captain thanks you for your assistance. One of his crew even offers to join yours. 
~crew = crew + 1
~end = true
->END