using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inst {
	public int id;
	public bool disengage = false;
	public string response;
	public string thoughts;
	public float optionDelay = 0f;
	public float responseSpeed = 0.02f;
	public float thoughtsSpeed = 0.03f;
	public float thoughtsDelay = 0;
}


public class DialogueInst : Inst {
	public List<string> options = new List<string>();
	public List<int> ResponseNrs = new List<int> ();
}



public class dialogueOptionContainerScript : MonoBehaviour {
	public static dialogueOptionContainerScript instance { get; private set; }

	public List<DialogueInst> dialogueContainer = new List<DialogueInst>();

	public Dictionary<string, List<DialogueInst>> allDialogues = new Dictionary<string, List<DialogueInst>>();


	public dialogueManager dialMan;
	
	void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		instance = this;
		DontDestroyOnLoad(gameObject);


		#region momIntro
	// ------ MOMINTRO
		DialogueInst momIntroGreet = new DialogueInst ();
		momIntroGreet.id = 0;
		momIntroGreet.response = "'Morning, sleepyhead.                          ¤Tea's still fresh. It's in the kitchen, if you want.";
		momIntroGreet.thoughts = "..What's...";
		momIntroGreet.options.Add ("Hey.");
		momIntroGreet.options.Add("Morning.");
		momIntroGreet.options.Add("[Grab some tea]");
		momIntroGreet.options.Add("[Walk straight out]");
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (3);
		momIntroGreet.ResponseNrs.Add (4);
		momIntroGreet.optionDelay = 4.1f;
		dialogueContainer.Add (momIntroGreet);

		DialogueInst momIntroStraight = new DialogueInst ();
		momIntroStraight.id = 1;
		momIntroStraight.response = "Got no food, though, so you need to head to the market if you want some.";
		momIntroStraight.thoughts = "..Damn...";
		momIntroStraight.options.Add ("Okay.");
		momIntroStraight.options.Add("Really? There's nothing?");
		momIntroStraight.options.Add("[Grab some tea]");
		momIntroStraight.options.Add("[Walk out of the room]");
		momIntroStraight.ResponseNrs.Add (7);
		momIntroStraight.ResponseNrs.Add (5);
		momIntroStraight.ResponseNrs.Add (7);
		momIntroStraight.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroStraight);

		DialogueInst momIntroTea = new DialogueInst ();
		momIntroTea.id = 3;
		momIntroTea.response = "Ran out of bread, unfortunately.  ¤So if you're hungry you need to go pick up some at the market.";
		momIntroTea.thoughts = "Ugh, really?";
		momIntroTea.options.Add ("Okay.");
		momIntroTea.options.Add ("Really? No bread? No other food?");
		momIntroTea.options.Add ("See you, then [Walk out]");
		momIntroTea.options.Add ("[Walk out of the room]");
		momIntroTea.ResponseNrs.Add (7);
		momIntroTea.ResponseNrs.Add (5);
		momIntroTea.ResponseNrs.Add (4);
		momIntroTea.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroTea);

		DialogueInst momIntroTea2 = new DialogueInst ();
		momIntroTea2.id = 7;
		momIntroTea2.response = "You also have school today, right?.";
		momIntroTea2.thoughts = "..right.. I am hungry, though.";
		momIntroTea2.options.Add ("Right. [Exit conversation]");
		momIntroTea2.options.Add("[Walk out of the room]");
		momIntroTea2.ResponseNrs.Add (4);
		momIntroTea2.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroTea2);

		DialogueInst momIntroOk = new DialogueInst ();
		momIntroOk.id = 5;
		momIntroOk.response = "Yes. There's nothing. Trust me.     ¤You still have school today, regardless, no?";
		momIntroOk.thoughts = "I <i>am</i> hungry, though...";
		momIntroOk.options.Add ("Right. [Exit conversation]");
		momIntroOk.options.Add ("[Walk away]");
		momIntroOk.ResponseNrs.Add (4);
		momIntroOk.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroOk);

		DialogueInst momHungry = new DialogueInst ();
		momHungry.id = 6;
		momHungry.response = "You're the hungry one. Besides, you have school, right?";
		momHungry.thoughts = "I <i>am</i> hungry...";
		momHungry.options.Add ("Fine. [Exit conversation]");
		momHungry.options.Add ("[Walk away]");
		momHungry.ResponseNrs.Add (4);
		momHungry.ResponseNrs.Add (4);
		dialogueContainer.Add (momHungry);

		DialogueInst exitConv = new DialogueInst ();
		exitConv.id = 4;
		exitConv.disengage = true;
		dialogueContainer.Add (exitConv);

		allDialogues.Add ("momIntro", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion momIntro

		#region cearaHi
		DialogueInst cearaHi = new DialogueInst ();
		cearaHi.id = 0;
		cearaHi.response = "Hey.";
		cearaHi.thoughts = "Oh, Ceara. Why's she not at school yet?";
		cearaHi.options.Add ("Hey");
		cearaHi.options.Add ("What are you doing here?");
		cearaHi.ResponseNrs.Add (1);
		cearaHi.ResponseNrs.Add (2);
		dialogueContainer.Add (cearaHi);

		DialogueInst crumours = new DialogueInst ();
		crumours.id = 1;
		crumours.response = "You came for the rumours too?";
		crumours.thoughts = "She looks happy, maybe? Hard to tell.";
		crumours.options.Add ("What rumours?");
		crumours.options.Add ("No");
		crumours.ResponseNrs.Add (3);
		crumours.ResponseNrs.Add (3);
		dialogueContainer.Add (crumours);

		DialogueInst c2 = new DialogueInst ();
		c2.id = 2;
		c2.response = "You didn't hear? There's a Sage coming today.";
		c2.thoughts = "...?";
		c2.options.Add ("What? What for?");
		c2.options.Add ("From Caudden?");
		c2.options.Add ("That seems unnecessary");
		c2.ResponseNrs.Add (4);
		c2.ResponseNrs.Add (5);
		c2.ResponseNrs.Add (6);
		dialogueContainer.Add (c2);

		DialogueInst c3 = new DialogueInst ();
		c3.id = 3;
		c3.response = "There's a Sage coming today.";
		c3.thoughts = "...?";
		c3.options.Add ("What for?");
		c3.options.Add ("From Caudden?");
		c3.options.Add ("That seems unnecessary");
		c3.ResponseNrs.Add (4);
		c3.ResponseNrs.Add (5);
		c3.ResponseNrs.Add (6);
		dialogueContainer.Add (c3);

		DialogueInst c4 = new DialogueInst ();
		c4.id = 4;
		c4.response = "Who knows? Just heard it from Illij. Said he knows him too. Apparently it's some expert from the south.";
		c4.thoughts = "..<i>Lovely</i>";
		c4.options.Add ("Hope he doesn't stay long.");
		c4.thoughtsDelay = 1f;
		c4.ResponseNrs.Add (7);
		dialogueContainer.Add (c4);

		DialogueInst c5 = new DialogueInst ();
		c5.id = 5;
		c5.response = "No, not even. It's some southern guy. Illij said he knows him.";
		c5.thoughts = "..<i>Lovely</i>";
		c5.options.Add ("Hope he doesn't stay long.");
		c5.ResponseNrs.Add (7);
		c5.thoughtsDelay = 1f;
		dialogueContainer.Add (c5);

		DialogueInst c6 = new DialogueInst ();
		c6.id = 6;
		c6.response = "Right? Think he's just passing through, though, so it's probably fine.";
		c6.thoughts = "..Wouldn't hold much hope out for that.";
		c6.thoughtsDelay = 1.5f;
		c6.options.Add ("That kind never just passes through.");
		c6.ResponseNrs.Add (9);
		dialogueContainer.Add (c6);

		DialogueInst c9 = new DialogueInst ();
		c9.id = 9;
		c9.response = "I guess not. Maybe he's not so bad, though. Illij apparently he knows him. Helped where he lived before.";
		c9.thoughts = "...not sure what to make of that.";
		c9.thoughtsDelay = 1.0f;
		c9.options.Add ("Still... Hope he doesn't stay long.");
		c9.ResponseNrs.Add (7);
		dialogueContainer.Add (c9);

		DialogueInst c7 = new DialogueInst ();
		c7.id = 7;
		c7.response = "True. Though, I'm afraid all half the town's already lost in their tales about his greatness, though.";
		c7.thoughts = "...Yeah. I can see that..";
		c7.thoughtsDelay = 1.0f;
		c7.options.Add ("They gathering here just to see him coming?");
		c7.options.Add ("Shouldn't we go to school?");
		c7.ResponseNrs.Add (8);
		c7.ResponseNrs.Add (10);
		dialogueContainer.Add (c7);

		DialogueInst c8 = new DialogueInst ();
		c8.id = 8;
		c8.response = "You guessed it. School's out too, because Trenner wants to talk to him apparently. \'Want to ask him about so many things!\' he said.";
		c8.thoughts = ".Oh, wait, what?.";
		c8.thoughtsDelay = 2.0f;
		c8.options.Add ("Haha, really? Wow, would've liked to see that.");
		c8.options.Add ("Trenner finally found someone to share in his excitement about everything?");
		c8.ResponseNrs.Add (11);
		c8.ResponseNrs.Add (12);
		dialogueContainer.Add (c8);

		DialogueInst c10 = new DialogueInst ();
		c10.id = 10;
		c10.response = "School's closed for the day. Trenner wants to talk to the Sage. 'Want to ask him about so many things!' he said.";
		c10.thoughts = ".Oh, wait, what?.";
		c10.thoughtsDelay = 1.5f;
		c10.options.Add ("Haha, really? Wow, would've liked to see that.");
		c10.options.Add ("Trenner finally found someone to share in his excitement about everything?");
		c10.ResponseNrs.Add (11);
		c10.ResponseNrs.Add (12);
		dialogueContainer.Add (c10);

		DialogueInst c11 = new DialogueInst ();
		c11.id = 11;
		c11.response = "Oh, it was pretty good. Laughed all the way out of the school.";
		c11.thoughts = "Dammit..";
		c11.thoughtsDelay = 1.5f;
		c11.options.Add ("Where's Illij?");
		c11.ResponseNrs.Add (13);
		dialogueContainer.Add (c11);

		DialogueInst c12 = new DialogueInst ();
		c12.id = 12;
		c12.response = "He hopes, she says and winks.";
		c12.thoughts = "";
		c12.thoughtsDelay = 1.5f;
		c12.options.Add ("Where's Illij?");
		c12.ResponseNrs.Add (13);
		dialogueContainer.Add (c12);

		DialogueInst c13 = new DialogueInst ();
		c13.id = 13;
		c13.response = "Why? Want to talk to him?";
		c13.thoughts = "Been a while since I saw Illij.";
		c13.thoughtsDelay = 0.5f;
		c13.options.Add ("Maybe");
		c13.ResponseNrs.Add (14);
		dialogueContainer.Add (c13);

		DialogueInst c14 = new DialogueInst ();
		c14.id = 14;
		c14.response = "He's in the inn, with the rest, gathering for the big arrival.";
		c14.thoughts = "Of course.";
		c14.thoughtsDelay = 1.0f;
		c14.options.Add ("Might as well go than bore ourselves out here, no?");
		c14.options.Add ("What do you want to do on our day off then?");
		c14.ResponseNrs.Add (15);
		c14.ResponseNrs.Add (16);
		dialogueContainer.Add (c14);

		DialogueInst c15 = new DialogueInst ();
		c15.id = 15;
		c15.response = "Sure. Was considering sneaking down to the pond or something now that no one's watching, but I guess I'm curious about this fellow, too.";
		c15.thoughts = "Nah, let's go see what's happening.";
		c15.thoughtsDelay = 2.0f;
		c15.options.Add ("[Leave]");
		c15.ResponseNrs.Add (17);
		dialogueContainer.Add (c15);

		DialogueInst c16 = new DialogueInst ();
		c16.id = 16;
		c16.response = "We could go down to the pond or something... but nah, let's go see what's up with this fellow. Say hi to Illij on the way.";
		c16.thoughts = "Nah, let's go see what's happening.";
		c16.thoughtsDelay = 2.0f;
		c16.options.Add ("Let's [Leave]");
		c16.ResponseNrs.Add (17);
		dialogueContainer.Add (c16);

		DialogueInst c17 = new DialogueInst ();
		c17.id = 17;
		c17.disengage = true;
		dialogueContainer.Add (c17);

		allDialogues.Add ("cearaIntro", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion cearaHi

		#region illijIntro
		DialogueInst IllijIntro = new DialogueInst ();
		IllijIntro.id = 0;
		IllijIntro.response = "That's our plan, says Ceara.   ¤Well, you're in for something at least. This guy's the real deal..";
		IllijIntro.thoughts = "He seems more excited than usual.";
		IllijIntro.options.Add ("Who is he?");
		IllijIntro.ResponseNrs.Add (2);
		dialogueContainer.Add (IllijIntro);

		DialogueInst ci2 = new DialogueInst ();
		ci2.id = 2;
		ci2.response = "He's a Vraadii Sage.  ¤Vraadii? Ceara asks.    ¤Sages that deal with curses, ghosts, and demons.";
		ci2.thoughts = "";
		ci2.options.Add ("What's he doing here?");
		ci2.options.Add ("We don't have any of that here?");
		ci2.options.Add ("Ceara said you know him?");
		ci2.ResponseNrs.Add (3);
		ci2.ResponseNrs.Add (4);
		ci2.ResponseNrs.Add (32);
		dialogueContainer.Add (ci2);

		DialogueInst ci4 = new DialogueInst ();
		ci4.id = 4;
		ci4.response = "We don't? You never really know until a Sage arrives. That's their other purpose: Spotting malicious elements in the first place.";
		ci4.thoughts = "";
		ci4.options.Add ("What's he doing here?");
		ci4.options.Add ("Ceara said you know him?");
		ci4.ResponseNrs.Add (3);
		ci4.ResponseNrs.Add (32);
		dialogueContainer.Add (ci4);

		DialogueInst ci32 = new DialogueInst ();
		ci32.id = 32;
		ci32.response = "Ceara talked a little fast again, I see. I said if it's who I think it is. The description matches, but there are other Sages like him in the world.";
		ci32.thoughts = "";
		ci32.options.Add ("Who is he, though. If it is him?");
		ci32.options.Add ("What's he doing here?");
		ci32.ResponseNrs.Add (31);
		ci32.ResponseNrs.Add (3);
		dialogueContainer.Add (ci32);

		DialogueInst ci31 = new DialogueInst ();
		ci31.id = 31;
		ci31.response = "His name is Derec Waith. He... rid my last village of a curse that had the cows eat bad food, producing terrible milk for several months. He came in a whisked it away in seconds.";
		ci31.thoughts = "";
		ci31.options.Add ("What's he doing here?");
		ci31.ResponseNrs.Add (3);
		dialogueContainer.Add (ci31);

		DialogueInst ci3 = new DialogueInst ();
		ci3.id = 3;
		ci3.response = "He's probably heading to Caudden, but Mikal said he'd stay here a few days for some reason. Maybe he wants to see the city from out here. Who knows.     ¤Is he a healer? Can he cure the Withered Pine? Ceara asks.";
		ci3.thoughts = "Always about that Pine...";
		ci3.thoughtsDelay = 3.5f;
		ci3.options.Add ("[Listen]");
		ci3.options.Add ("Why would he do that?");
		ci3.ResponseNrs.Add (5);
		ci3.ResponseNrs.Add (6);
		dialogueContainer.Add (ci3);

		DialogueInst ci5 = new DialogueInst ();
		ci5.id = 5;
		ci5.response = "Maybe, maybe not. Your mother already mentioned she was going to ask about it, but we'll see.";
		ci5.thoughts = "";
		ci5.options.Add ("[Let Ceara ask something again]");
		ci5.options.Add ("What did Mikal say? Did he see him?");
		ci5.ResponseNrs.Add (7);
		ci5.ResponseNrs.Add (8);
		dialogueContainer.Add (ci5);

		DialogueInst ci6 = new DialogueInst ();
		ci6.id = 6;
		ci6.response = "Let her speak, Tari.    ¤Ceara glances at me with a sovereign smile.       ¤He might, but I don't know. Your mother already mentioned she was going to ask about it, but we'll see.";
		ci6.thoughts = "";
		ci6.options.Add ("[Let Ceara ask something]");
		ci6.options.Add ("What did Mikal say? Did he see him?");
		ci6.ResponseNrs.Add (7);
		ci6.ResponseNrs.Add (8);
		dialogueContainer.Add (ci6);

		DialogueInst ci7 = new DialogueInst ();
		ci7.id = 7;
		ci7.response = "My mother's gonna speak to him? Ceara asks.    ¤¤Says she's planning on it. But so's half the town, so don't exactly be surprised by that. You want to speak to him too, don't you?     ¤¤Well... Ceara is hesitating.";
		ci7.thoughts = "";
		ci7.options.Add ("Of course");
		ci7.options.Add ("Maybe");
		ci7.options.Add ("Not really");
		ci7.ResponseNrs.Add (9);
		ci7.ResponseNrs.Add (10);
		ci7.ResponseNrs.Add (11);
		dialogueContainer.Add (ci7);

		DialogueInst ci8 = new DialogueInst ();
		ci8.id = 8;
		ci8.response = "Says he did, yeah. Out by Furrow, on his way back from a Courier trip.         ¤¤My mother's gonna speak to him? Ceara asks.   ¤¤Says she's planning on it. But so's half the town, so don't exactly be surprised by that. You want to speak to him too, don't you?        ¤¤Well... Ceara is hesitating.";
		ci8.thoughts = "Something's happening! Of course I do.";
		ci8.options.Add ("Of course");
		ci8.options.Add ("Maybe");
		ci8.options.Add ("Not really");
		ci8.ResponseNrs.Add (9);
		ci8.ResponseNrs.Add (10);
		ci8.ResponseNrs.Add (11);
		dialogueContainer.Add (ci8);

		DialogueInst ci9 = new DialogueInst ();
		ci9.id = 9;
		ci9.response = "See? I get it, too. It's rare to see anyone like that out here, Illij says.  ¤¤Most of them dart directly into Caudden and never look back, Ceara says.   ¤¤Exactly. Why this one's staying is not clear to any of us, either, which makes it interesting.";
		ci9.thoughtsDelay = 3f;
		ci9.thoughts = "Apropos being excited...";
		ci9.options.Add ("Where's Trenner?");
		ci9.ResponseNrs.Add (12);
		dialogueContainer.Add (ci9);

		DialogueInst ci10 = new DialogueInst ();
		ci10.id = 10;
		ci10.response = "Hah, you know you want to. No reason to hide it from me. I don't care that you act all tough. It's rare to see anyone like that out here. It's only natural to have questions, Illij says.";
		ci10.thoughtsDelay = 3f;
		ci10.thoughts = "Apropos being excited...";
		ci10.options.Add ("Where's Trenner?");
		ci10.ResponseNrs.Add (12);
		dialogueContainer.Add (ci10);

		DialogueInst ci11 = new DialogueInst ();
		ci11.id = 11;
		ci11.response = "Hah, you little liar. Don't try to act tough around me, I can see right through that. No point in being so cross. You the same negativity, Ceara?       ¤¤I don't know, she says. Maybe.         ¤¤He shakes his head. Bunch of girls, you are.";
		ci11.thoughtsDelay = 5f;
		ci11.thoughts = "Let's... change the subject";
		ci11.options.Add ("Where's Trenner?");
		ci11.ResponseNrs.Add (12);
		dialogueContainer.Add (ci11);

		DialogueInst ci12 = new DialogueInst ();
		ci12.id = 12;
		ci12.response = "I don't get to ask that question. Ceara and Illij both look away from me.";
		ci12.thoughtsDelay = 1f;
		ci12.thoughts = "..What's?";
		ci12.options.Add ("[Look over]");
		ci12.ResponseNrs.Add (13);
		dialogueContainer.Add (ci12);

		DialogueInst exitI = new DialogueInst ();
		exitI.id = 13;
		exitI.disengage = true;
		dialogueContainer.Add (exitI);

		allDialogues.Add ("IllijIntro", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion illijIntro



	}


	public List<string> GetOptions(string s,int c){

		Debug.Log(s+" "+allDialogues.Count+" "+c+" "+allDialogues[s][c].options.Count);
		return allDialogues[s][c].options;

	}

}
