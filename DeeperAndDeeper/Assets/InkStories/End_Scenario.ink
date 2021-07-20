// Game variables
VAR fuel = 0
VAR torpedo = 0
VAR crew = 0
VAR hull = 0
VAR encounter = false
VAR gameEnding = 0
VAR end = false

->Final_Confrontation

===Final_Confrontation===
This was it. The heart of the Kraken nation is within your sights. The journey was a long and brutal one. You inflicted many casualties in your battles with enemy vessels, but this number was dwarfed by how many the Kraken inflicted on our nation.
*They have to pay. 
->Part_2

=Part_2
~encounter = true
You are able to sneak past the remnants of the Kraken fleet undeteched. You command your crew to take you into the small gulf made by your enemy's forboding crescent-shaped island.
*Get us into firing position. 
->Part_3

=Part_3
You only have one shot with the nuclear warhead and it has to be fired from the surface
*Take the sho-
->Part_4

=Part_4
Before you can give the order, you hear harsh and unfamiliar voice echoing throughout your submarine's communication system. 
How the hell did they contact us?
->Part_5

=Part_5
The voiced spoke: "Unidentified UAN vessel. We know about your nuclear-equipped submarine and what you are capable of. We have no way to harm you. Please hear us out before you fire, we have some important information for you? 
*What information could you have that's of importance to us?
->Part_6

=Part_6
'We know you received an emergency broadcast claiming that we carried out a nuclear strike on your homeland. This is untrue. This strike was only made to LOOK like our doing to your nation's defence measures. 
*Who could do this? You are the only ones capable of this in the Archipelago.
->Part_7
*Kraken lies. Dishonourable until the end. Fire!
->Ending_1

=Part_7
'This threat comes from outside the Archipelago. We have only known about them for a short time, but yes, it's true, there are other civilisations, hidden away on dry land.'
*I've heard enough of this nonsense. FIRE AT WILL!
->Ending_1
*Dry land? How could there be?
->Part_8

=Part_8
It's true. They've evaded detection by us for some time. But they've been watching us, and plotting to end us. You have a choice. You can either destroy us, and fulfill the wish of these 'Others'.
Or you can join us. 
*Do you have any proof of this? 
->Part_9
*Enough games. FIRE AT WILL!
->Ending_1

=Part_9
These Others are sneaky. They cover their tracks well. But had you ever considered how the nuclear attack that wiped out your UAN got past their defense systems that were ready for anything we could throw at them? 
*Because the attack came from a direction they weren't expecting. 
->Part_10

=Part_10
    Exactly. So you have a choice. You can help us defeat a threat that's bigger than both our nations' enmity, or doom what remains of the Archipelago...
*Nice story, Kraken but it's time for me to complete my mission. FIRE!
->Ending_1
*I cannot order my crew to wipe you out, if you really didn't attack us. But I won't side with the Kraken either.
->Part_11
*I'm not sure if I can trust you, but your story makes sense. We will join you. But I am keeping my vessel as insurance from any tricks you might pull. 
->Ending_3
*There's no way I'm siding with a nation that's been threatening me with destruction my entire life. No good can come of allying ourselves with you. However, I cannot give the order to unleash nuclear hellfire on innocent civilians, even if they are Kraken. 
->Part_12


=Part_11
'Then what will you do?'
We're going to do whatever it takes to re-establish the UAN. We will find willing people across the Archipelago to unite and prepare for this foe you speak of, if it really exists. 
->Ending_2

=Part_12
'Then what will you do?'
I am going to take this submarine and find these 'Others'. I intend to speak with them, find out their motives. Only when I understand both Kraken and Other, I will decide which side I will take. Don't try to stop us. 
->Ending_4


=Ending_1
~encounter = false
The primed warhead is fired directly upwards from your craft. You see the arcing trail of it as it careers towards the heart of the Kraken homeland. It's done. 
You make a quick escape back to the open seas. There were still more Kraken left to hunt.
* THE END
~end = true
~gameEnding = 1
->END

=Ending_2
~encounter = false
You order your crew to take you out of Kraken waters. The journey ahead was long and uncertain, but you knew you couldn't side with your enemy. If what the Kraken voice had said was true, then there may be even darker days ahead.
* THE END
~end = true
~gameEnding = 2
->END

=Ending_3
~encounter = false
Very well. You can't trust us, and we can't trust you. But this is the only way that we can survive. We expect you to meet the Kraken High Command face-to-face. We need to start discussing how we can strike back against this new foe. 
    You prepare to leave for Kraken Isle.
* THE END
~end = true
~gameEnding = 3
->END

=Ending_4
~encounter = false
 With that warning, the Kraken voice went silent. You order your crew to plot a course to the edge of Archipelago waters. It was time to find these Others and learn what they wanted. You knew the UAN Hunter and her crew could take the journey. There was nothing left for any of you in the Archipelago, anyway. 
 
* THE END
~end = true
~gameEnding = 4
->END
