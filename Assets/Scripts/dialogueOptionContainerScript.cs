using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// STANDARD: #323232ff
// NONDIAL: #0f0f0fff

public class Alternate{
	public string altResp;
	public bool shouldAlter = false;

	public Alternate (){shouldAlter = false;}
	public Alternate(string s, bool b){
		altResp = s;
		shouldAlter = b;
	}
}

public class NextToTrigger{
	public string name;
	public bool shouldTrigger = false;
	public bool isDialogue;

	public NextToTrigger(){shouldTrigger = false;}
	public NextToTrigger(string n, bool a, bool b){
		name = n;
		shouldTrigger = a;
		isDialogue = b;
	}
}

public class Inst {
	public int id;
	public bool disengage = false;
	public string response;
	public string thoughts;
	public float optionDelay = 0f;
	public float responseSpeed = 0.02f;
	public float thoughtsSpeed = 0.03f;
	public float thoughtsDelay = 0;
	public NextToTrigger nextToTrigger = new NextToTrigger();
	public void NextTrigger(string n, bool b){
		nextToTrigger.name = n;
		nextToTrigger.shouldTrigger = true;
		nextToTrigger.isDialogue = b;
	}

	public Alternate altResp = new Alternate();
	public void AlterResp(string n){
		altResp.altResp = n;
		altResp.shouldAlter = true;
	}

	public Alternate altThou = new Alternate();
	public void AlterThoughts(string n){
		altThou.altResp = n;
		altThou.shouldAlter = true;
	}


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
//	public Color talkColor = Color.
	
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
		//momIntroGreet.NextTrigger ("",false);
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
        #endregion

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
        #endregion

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
		exitI.NextTrigger("sageIntro",false);
		dialogueContainer.Add (exitI);

		allDialogues.Add ("IllijIntro", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
        #endregion

		#region shouldTalkToSage
		DialogueInst sTalkNo = new DialogueInst ();
		sTalkNo.id = 0;
		sTalkNo.response = "I glance over at Ceara, who doesn’t seem to know what to do either.";
		sTalkNo.thoughts = "...Don't know if I want to listen to him.";
		sTalkNo.options.Add ("Want to go talk to him?");
		sTalkNo.options.Add ("Let’s just get out of here.");
		sTalkNo.ResponseNrs.Add (1);
		sTalkNo.ResponseNrs.Add (2);
		dialogueContainer.Add (sTalkNo);

		DialogueInst sTalkNo1 = new DialogueInst ();
		sTalkNo1.id = 1;
		sTalkNo1.response = "Not sure, <she says.> Can’t right now anyway. And this air is killing me.      ¤¤<She hesitates, then speaks again.> ¤No, let’s go outside.";;
		sTalkNo1.thoughts = "";
		sTalkNo1.optionDelay = 3f;
		sTalkNo1.options.Add ("Let's");
		sTalkNo1.ResponseNrs.Add (4);
		dialogueContainer.Add (sTalkNo1);

		DialogueInst sTalkNo2 = new DialogueInst ();
		sTalkNo2.id = 2;
		sTalkNo2.response = "Yeah, let’s go outside.";;
		sTalkNo2.thoughts = "";
		sTalkNo2.options.Add ("Let's");
		sTalkNo2.ResponseNrs.Add (4);
		dialogueContainer.Add (sTalkNo2);
		
		DialogueInst sTalkNoExit = new DialogueInst ();
		sTalkNoExit.id = 4;
		sTalkNoExit.disengage = true;
		sTalkNoExit.NextTrigger ("pondIntro", false);
		dialogueContainer.Add (sTalkNoExit);
		
		allDialogues.Add ("shouldTalkToSage", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region treeBet
		DialogueInst treeBet = new DialogueInst ();
		treeBet.id = 0;
		treeBet.response = "What did you think of him?";;
		treeBet.thoughts = "..";
		treeBet.options.Add ("What an idiot");
		treeBet.options.Add ("He didn't seem so bad.");
		treeBet.options.Add ("What about you?");
		treeBet.ResponseNrs.Add (1);
		treeBet.ResponseNrs.Add (2);
		treeBet.ResponseNrs.Add (3);
		dialogueContainer.Add (treeBet);

		DialogueInst treeBet1 = new DialogueInst ();
		treeBet1.id = 1;
		treeBet1.response = "Yeah, right? Damn...     ¤‘I cnan sée you all have qu-estions.’ Man… just his voice alone.";
		treeBet1.thoughts = "Wow, that impression was uncanny";
		treeBet1.thoughtsDelay = 2f;
		treeBet1.options.Add ("[Laugh]");
		treeBet1.ResponseNrs.Add (5);
		dialogueContainer.Add (treeBet1);

		DialogueInst treeBet2 = new DialogueInst ();
		treeBet2.id = 2;
		treeBet2.response = "What are you talking about? He seemed like a huge prick.";
		treeBet2.thoughts = "";
		treeBet2.options.Add ("Sure, but we barely saw him.");
		treeBet2.options.Add ("You're right.");
		treeBet2.ResponseNrs.Add (4);
		treeBet2.ResponseNrs.Add (4);
		dialogueContainer.Add (treeBet2);

		DialogueInst treeBet4 = new DialogueInst ();
		treeBet4.id = 4;
		treeBet4.response = "'I cnan sée you allll have qu-estions.' Man… just his voice alone.";
		treeBet4.thoughts = "Wow, that impression was uncanny";
		treeBet4.thoughtsDelay = 2f;
		treeBet4.options.Add ("[Laugh]");
		treeBet4.ResponseNrs.Add (5);
		dialogueContainer.Add (treeBet4);

		DialogueInst treeBet3 = new DialogueInst ();
		treeBet3.id = 3;
		treeBet3.response = "Oh no, you. I asked first.";
		treeBet3.thoughtsDelay = 0.8f;
		treeBet3.thoughts = "...Alright";
		treeBet3.options.Add ("What an idiot");
		treeBet3.options.Add ("He didn't seem so bad.");
		treeBet3.ResponseNrs.Add (1);
		treeBet3.ResponseNrs.Add (2);
		dialogueContainer.Add (treeBet3);

		DialogueInst treeBet5 = new DialogueInst ();
		treeBet5.id = 5;
		treeBet5.response = "Oh, well. Want to race up the willow?";
		treeBet5.thoughts = "";
		treeBet5.options.Add ("Wanna bet?");
		treeBet5.ResponseNrs.Add (6);
		dialogueContainer.Add (treeBet5);

		DialogueInst treeBet6 = new DialogueInst ();
		treeBet6.id = 6;
		treeBet6.response = "How much?";
		treeBet6.thoughts = "I only have two shillings...";
		treeBet6.options.Add ("Two shillings");
		treeBet6.options.Add ("Three shillings");
		treeBet6.ResponseNrs.Add (7);
		treeBet6.ResponseNrs.Add (7);
		dialogueContainer.Add (treeBet6);

		DialogueInst treeBet7 = new DialogueInst ();
		treeBet7.id = 7;
		treeBet7.response = "You're on.";
		treeBet7.thoughts = "Go!";
		treeBet7.options.Add ("[RACE]");
		treeBet7.ResponseNrs.Add (8);
		dialogueContainer.Add (treeBet7);

		DialogueInst treeBetEx = new DialogueInst ();
		treeBetEx.id = 8;
		treeBetEx.disengage = true;
		treeBetEx.NextTrigger ("race", false);
		dialogueContainer.Add (treeBetEx);
		
		allDialogues.Add ("treeBet", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region raceChoice
		DialogueInst raceChoice = new DialogueInst ();
		raceChoice.id = 0;
		raceChoice.response = "Halfway flustered, I realize that the only way I can win this is by pulling her down, as I can just reach her shoe.";
		raceChoice.thoughts = "Shit.";
		raceChoice.options.Add ("[Pull her down]");
		raceChoice.options.Add ("[Let her win]");
		raceChoice.ResponseNrs.Add (1);
		raceChoice.ResponseNrs.Add (2);
		dialogueContainer.Add (raceChoice);
		
		DialogueInst raceChoiceExit = new DialogueInst ();
		raceChoiceExit.id = 1;
		raceChoiceExit.disengage = true;
		raceChoiceExit.NextTrigger("pullAmbient",false);
		dialogueContainer.Add (raceChoiceExit);

		DialogueInst raceChoiceExit2 = new DialogueInst ();
		raceChoiceExit2.id = 2;
		raceChoiceExit2.disengage = true;
		raceChoiceExit2.NextTrigger("nonPullAmbient",false);
		dialogueContainer.Add (raceChoiceExit2);
		
		allDialogues.Add ("raceChoice", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region cCursed
		DialogueInst cCursed = new DialogueInst ();
		cCursed.id = 0;
		cCursed.response = "I’m fine <she said. It was quick, almost hurried. It didn’t sound fine.>";
		cCursed.thoughts = "..She looks... oh, god, what happened.";
		cCursed.options.Add ("What happened? Are you hurt?");
		cCursed.ResponseNrs.Add (1);
		dialogueContainer.Add (cCursed);

		DialogueInst cCursed1 = new DialogueInst ();
		cCursed1.id = 1;
		cCursed1.response = "No, not really. Not… at all. I just… ugh.";
		cCursed1.thoughts = "...";
		cCursed1.options.Add ("What's wrong?");
		cCursed1.ResponseNrs.Add (2);
		dialogueContainer.Add (cCursed1);

		DialogueInst cCursed2 = new DialogueInst ();
		cCursed2.id = 2;
		cCursed2.response = "Something’s… Don’t look.";
		cCursed2.thoughts = "What's with her skin?";
		cCursed2.options.Add ("Wait, are you hurt? Seriously? We need to get back to the inn.");
		cCursed2.ResponseNrs.Add (3);
		dialogueContainer.Add (cCursed2);

		DialogueInst cCursed3 = new DialogueInst ();
		cCursed3.id = 3;
		cCursed3.response = "No, no. It's nothing.";
		cCursed3.thoughts = "";
		cCursed3.options.Add ("Come on, get up.");
		cCursed3.options.Add ("Let me see.");
		cCursed3.ResponseNrs.Add (4);
		cCursed3.ResponseNrs.Add (4);
		dialogueContainer.Add (cCursed3);

		DialogueInst cCursed4 = new DialogueInst ();
		cCursed4.id = 4;
		cCursed4.response = "<She slowly starts moving, and she does so with strain that seems greater than necessary. Then I see her face.     ¤Across it, in large, dark stripes, there some form of deformation in her face. It’s not exactly a wound, nor a scar, but it looks like…       ¤It looks like her skin has opened and rotten away the meat. There’s an odd smell, of a crass bloom, a raw plant-smell coming from her face, as if we had just cut a flower-stalk open and let it lie in the sun.";
		cCursed4.thoughts = "Wh-- what the hell..";
		cCursed4.options.Add ("What... happened?");
		cCursed4.ResponseNrs.Add (5);
		dialogueContainer.Add (cCursed4);

		DialogueInst cCursed5 = new DialogueInst ();
		cCursed5.id = 5;
		cCursed5.response = "I don’t know <she says.> I… does it look bad?";
		cCursed5.thoughts = "...";
		cCursed5.options.Add ("No, no.. It's fine.");
		cCursed5.options.Add ("Yeah.");
		cCursed5.ResponseNrs.Add (6);
		cCursed5.ResponseNrs.Add (6);
		dialogueContainer.Add (cCursed5);

		DialogueInst cCursed6 = new DialogueInst ();
		cCursed6.id = 6;
		cCursed6.response = "Does it look like this?  ¤<She raises her hand and the same markings cross her hand. The same out-washed purple color, mixed with a bit of green.>";
		cCursed6.thoughts = ".. It does";
		cCursed6.thoughtsDelay = 2f;
		cCursed6.options.Add ("Yes..");
		cCursed6.options.Add ("No, it's.. better.");
		cCursed6.ResponseNrs.Add (7);
		cCursed6.ResponseNrs.Add (8);
		dialogueContainer.Add (cCursed6);

		DialogueInst cCursed7 = new DialogueInst ();
		cCursed7.id = 7;
		cCursed7.response = "Thanks for being honest.";
		cCursed7.thoughts = "";
		cCursed7.options.Add ("Does it hurt?");
		cCursed7.options.Add ("What did this?");
		cCursed7.ResponseNrs.Add (9);
		cCursed7.ResponseNrs.Add (10);
		dialogueContainer.Add (cCursed7);

		DialogueInst cCursed8 = new DialogueInst ();
		cCursed8.id = 8;
		cCursed8.response = "You’re just saying that.. It looks like it right? I can see it in your face. It’s terrible.";
		cCursed8.thoughts = "Dammit";
		cCursed8.options.Add ("Does it hurt?");
		cCursed7.options.Add ("What did this?");
		cCursed8.ResponseNrs.Add (9);
		cCursed8.ResponseNrs.Add (10);
		dialogueContainer.Add (cCursed8);

		DialogueInst cCursed9 = new DialogueInst ();
		cCursed9.id = 9;
		cCursed9.response = "Not really. I can feel something strange. Like it’s… pulsating.";
		cCursed9.thoughts = "..Pulsating?";
		cCursed9.options.Add ("What did this?");
		cCursed9.ResponseNrs.Add (10);
		dialogueContainer.Add (cCursed9);

		DialogueInst cCursed10 = new DialogueInst ();
		cCursed10.id = 10;
		cCursed10.response = "… think it was that.       ¤<She points at a flower just below her. It has… no, the entire flowerbed have the same marks. The same purplish deformation, stricken across them like they were dyed into the very fabric of the petals.>";
		cCursed10.thoughts = "It's everywhere";
		cCursed10.options.Add ("We have to get back.");
		cCursed10.ResponseNrs.Add (11);
		dialogueContainer.Add (cCursed10);

		DialogueInst cCursed11 = new DialogueInst ();
		cCursed11.id = 11;
		cCursed11.response = "I can’t let anyone see this!";
		cCursed11.thoughts = "";
		cCursed11.options.Add ("We have to get back right now!");
		cCursed11.options.Add ("We have to get help! What if it's dangerous?");
		cCursed11.ResponseNrs.Add (12);
		cCursed11.ResponseNrs.Add (13);
		dialogueContainer.Add (cCursed11);

		DialogueInst cCursed12 = new DialogueInst ();
		cCursed12.id = 12;
		cCursed12.response = "I... Look at me! They can't help with this. What are they going to do? ";
		cCursed12.thoughts = "";
		cCursed12.options.Add ("We have to get help! What if it's dangerous?");
		cCursed12.options.Add ("What are <i>you</i> going to do? Just stay here?");
		cCursed12.ResponseNrs.Add (13);
		cCursed12.ResponseNrs.Add (14);
		dialogueContainer.Add (cCursed12);

		DialogueInst cCursed13 = new DialogueInst ();
		cCursed13.id = 13;
		cCursed13.response = "It’s fine. It doesn’t hurt.";
		cCursed13.thoughts = "";
		cCursed13.options.Add ("Stop saying that! What are you going to do? Just stay here!");
		cCursed13.ResponseNrs.Add (14);
		dialogueContainer.Add (cCursed13);

		DialogueInst cCursed14 = new DialogueInst ();
		cCursed14.id = 14;
		cCursed14.response = "..I don't know.";
		cCursed14.thoughts = "God, Ceara... We have to get help here.";
		cCursed14.options.Add ("Come on. We're leaving. Now.");
		cCursed14.ResponseNrs.Add (15);
		dialogueContainer.Add (cCursed14);

		DialogueInst cCursed15 = new DialogueInst ();
		cCursed15.id = 15;
		cCursed15.response = "Don't touch me! <She flinches as I get close.> I touched the plants. It might be contagious.";
		cCursed15.thoughts = "Oh right. Shit.";
		cCursed15.options.Add ("Right. Won't touch you. Just... come on. Please.");
		cCursed15.ResponseNrs.Add (16);
		dialogueContainer.Add (cCursed15);

		DialogueInst cCursedExit = new DialogueInst ();
		cCursedExit.id = 16;
		cCursedExit.NextTrigger("cursedGoBackToInn",false);
		cCursedExit.disengage = true;
		dialogueContainer.Add (cCursedExit);
		
		allDialogues.Add ("cCursed", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region innCurseIntro
		DialogueInst innCurseIntro = new DialogueInst ();
		innCurseIntro.id = 0;
		innCurseIntro.response = "What happened?";
		innCurseIntro.thoughts = "..I don't know.";
		innCurseIntro.options.Add ("She fell");
		innCurseIntro.options.Add ("She.. touched some plants.. they had the same marks.");
		innCurseIntro.ResponseNrs.Add (1);
		innCurseIntro.ResponseNrs.Add (2);
		dialogueContainer.Add (innCurseIntro);

		DialogueInst innCurseIntro1 = new DialogueInst ();
		innCurseIntro1.id = 1;
		innCurseIntro1.response = "Don't give me that bullshit. A fall obviously didn't do this..";
		innCurseIntro1.thoughts = "...";
		innCurseIntro1.options.Add ("I don't know what happened..");
		innCurseIntro1.options.Add ("She.. touched some plants.. they had the same marks.");
		innCurseIntro1.ResponseNrs.Add (3);
		innCurseIntro1.ResponseNrs.Add (2);
		dialogueContainer.Add (innCurseIntro1);

		DialogueInst innCurseIntro2 = new DialogueInst ();
		innCurseIntro2.id = 2;
		innCurseIntro2.response = "Plants? What kind of plants? Where? ¤¤<She was speaking frantically, kept glancing at her daughter, kept beginning to move, then stopping again. Ceara was watching her with a pleading, sorry look.>";
		innCurseIntro2.thoughts = "I can't say we went to the pond..";
		innCurseIntro2.options.Add ("..Just outside the village.");
		innCurseIntro2.ResponseNrs.Add (4);
		dialogueContainer.Add (innCurseIntro2);

		DialogueInst innCurseIntro3 = new DialogueInst ();
		innCurseIntro3.id = 3;
		innCurseIntro3.response = "Let me see that <we heard a voice coming from the other side of the inn.    ¤It was the Sage, I realized.   ¤¤He stood up and walked directly across the inn in a direct motion. His face was determined.>     ¤What happened, you said?";
		innCurseIntro3.thoughts = "..Why does he want to help..";
		innCurseIntro3.options.Add ("I don't know.");
		innCurseIntro3.options.Add ("She touched a plant. With the same marks as she's got now.");
		innCurseIntro3.ResponseNrs.Add (4);
		innCurseIntro3.ResponseNrs.Add (5);
		dialogueContainer.Add (innCurseIntro3);

		DialogueInst innCurseIntro4 = new DialogueInst ();
		innCurseIntro4.id = 4;
		innCurseIntro4.response = "This isn't normal, whatever this is. You have to help me here.";
		innCurseIntro4.thoughts = "";
		innCurseIntro4.options.Add ("Why do I have to help you? You just got here!");
		innCurseIntro4.options.Add ("She touched a plant. With the same marks as she's got now.");
		innCurseIntro4.ResponseNrs.Add (6);
		innCurseIntro4.ResponseNrs.Add (5);
		dialogueContainer.Add (innCurseIntro4);

		DialogueInst innCurseIntro6 = new DialogueInst ();
		innCurseIntro6.id = 6;
		innCurseIntro6.response = "I'm a Sage. I'm a Vraadii Sage. I specialize in curses. I might very well be able to help, if this is in fact what it looks like. 'Cause it looks like a curse.";
		innCurseIntro6.thoughts = "";
		innCurseIntro6.options.Add ("...She touched some plants that had the same marks");
		innCurseIntro6.ResponseNrs.Add (7);
		dialogueContainer.Add (innCurseIntro6);

		DialogueInst innCurseIntro5 = new DialogueInst ();
		innCurseIntro5.id = 5;
		innCurseIntro5.response = "A plant? You sure? And with the same... ¤<He almost came close enough to touch her but she fidgeted away.> Why won't you let us touch you? <he said.>     ¤..That's how it happened. I touched the plant <Ceara said.>";
		innCurseIntro5.thoughts = "";
		innCurseIntro5.options.Add ("Right. We don't know if it'll happen to anything else.");
		innCurseIntro5.ResponseNrs.Add (7);
		dialogueContainer.Add (innCurseIntro5);

		DialogueInst innCurseIntro7 = new DialogueInst ();
		innCurseIntro7.id = 7;
		innCurseIntro7.response = "That's... remarkably clever of you two. Well done. Don't touch her anyone. Not until we know what this is.";
		innCurseIntro7.thoughts = "";
		innCurseIntro7.options.Add ("You can find out?");
		innCurseIntro7.ResponseNrs.Add (8);
		dialogueContainer.Add (innCurseIntro7);

		DialogueInst innCurseIntro8 = new DialogueInst ();
		innCurseIntro8.id = 8;
		innCurseIntro8.response = "No, but if what you say is true, it is definitely a curse. I have never seen its like before, though.      ¤<He paused, staring at Ceara with a scientific curiosity, ruing over her every inch as if she was a piece of equipment.>";
		innCurseIntro8.thoughts = "";
		innCurseIntro8.options.Add ("Is she safe?");
		innCurseIntro8.options.Add ("Will she be okay?");
		innCurseIntro8.ResponseNrs.Add (9);
		innCurseIntro8.ResponseNrs.Add (10);
		dialogueContainer.Add (innCurseIntro8);

		DialogueInst innCurseIntro9 = new DialogueInst ();
		innCurseIntro9.id = 9;
		innCurseIntro9.response = "For now, it seems so.      ¤¤Will she be okay? the mother asked.";
		innCurseIntro9.thoughts = "";
		innCurseIntro9.options.Add ("[Listen]");
		innCurseIntro9.ResponseNrs.Add (10);
		dialogueContainer.Add (innCurseIntro9);

		DialogueInst innCurseIntro10 = new DialogueInst ();
		innCurseIntro10.id = 10;
		innCurseIntro10.response = "I don't know, he said. It was the most honest thing I had ever heard.    ¤It didn't help tear my guilt and worry away, though.";
		innCurseIntro10.thoughts = "";
		innCurseIntro10.options.Add ("Let someone say something");
		innCurseIntro10.ResponseNrs.Add (11);
		dialogueContainer.Add (innCurseIntro10);

		DialogueInst innCurseIntro11 = new DialogueInst ();
		innCurseIntro11.id = 11;
		innCurseIntro11.response = "Does it hurt? <the Sage asked.>  ¤No.  ¤How does it feel when you press it? Soft? Like rubber? Or rough like stone?  ¤It... Kind off a mix. It feel like.. untanned leather.    ¤Does it smell? Can't tell anything from here.   ¤No.";
		innCurseIntro11.thoughts = "It did smell down by the pond.";
		innCurseIntro11.options.Add ("Yes.");
		innCurseIntro11.options.Add ("Say nothing");
		innCurseIntro11.ResponseNrs.Add (12);
		innCurseIntro11.ResponseNrs.Add (13);
		dialogueContainer.Add (innCurseIntro11);

		DialogueInst innCurseIntro12 = new DialogueInst ();
		innCurseIntro12.id = 12;
		innCurseIntro12.response = "When? Now? Or when it happened?";
		innCurseIntro12.thoughts = "";
		innCurseIntro12.options.Add ("When it happened");
		innCurseIntro12.ResponseNrs.Add (13);
		dialogueContainer.Add (innCurseIntro12);

		DialogueInst innCurseIntro13 = new DialogueInst ();
		innCurseIntro13.id = 13;
		innCurseIntro13.response = "I need to see the place where it was found. I need to see these flowers. Where did you find them?        ¤I hesitate.";
		innCurseIntro13.thoughts = "Dammit... I have to tell this.. Ceara needs help.";
		innCurseIntro13.thoughtsDelay = 2f;
		innCurseIntro13.options.Add ("..Down by the pond.");
		innCurseIntro13.ResponseNrs.Add (14);
		dialogueContainer.Add (innCurseIntro13);

		DialogueInst innCurseIntro14 = new DialogueInst ();
		innCurseIntro14.id = 14;
		innCurseIntro14.response = "What? You went to the pond!? <Ceara's mother immediately bursts out. Why didn't you say so?>";
		innCurseIntro14.thoughts = "";
		innCurseIntro14.options.Add ("I...");
		innCurseIntro14.ResponseNrs.Add (15);
		dialogueContainer.Add (innCurseIntro14);

		DialogueInst innCurseIntro15 = new DialogueInst ();
		innCurseIntro15.id = 15;
		innCurseIntro15.response = "That's not important anymore, the Sage did not hesitate to stop the mother's angsty reply. Why aren't you allowed to go down there? Is it dangerous?    ¤¤Not... exactly, no. We don't want the kids to interfere with the fish and the moving flowers.   ¤¤You have moving flowers there? His tone changed for the worse.   ¤¤..Yes? the mother replied, unsure.    ¤¤And these were the flowers that had the marks?";
		innCurseIntro15.thoughts = "Oh.. Shit";
		innCurseIntro15.thoughtsDelay = 9f;
		innCurseIntro15.options.Add ("Yes");
		innCurseIntro15.ResponseNrs.Add (16);
		dialogueContainer.Add (innCurseIntro15);

		DialogueInst innCurseIntro16 = new DialogueInst ();
		innCurseIntro16.id = 16;
		innCurseIntro16.response = "Take me there, right now.";
		innCurseIntro16.thoughts = "I hope he can help..";
		innCurseIntro16.options.Add ("[Start walking]");
		innCurseIntro16.ResponseNrs.Add (17);
		dialogueContainer.Add (innCurseIntro16);

		DialogueInst innCurseIntroExit = new DialogueInst ();
		innCurseIntroExit.id = 17;
		innCurseIntroExit.disengage = true;
		dialogueContainer.Add (innCurseIntroExit);
		
		allDialogues.Add ("innCurseIntro", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region befRitualChoice
		DialogueInst befRitualChoice = new DialogueInst ();
		befRitualChoice.id = 0;
		befRitualChoice.response = "<Ceara starts moving.>";
		befRitualChoice.thoughts = "Man, Ceara looks determined...";
		befRitualChoice.options.Add ("[Go with Ceara]");
		befRitualChoice.options.Add ("[Stay here]");
		befRitualChoice.ResponseNrs.Add (1);
		befRitualChoice.ResponseNrs.Add (2);
		dialogueContainer.Add (befRitualChoice);
		
		DialogueInst befRitualChoice1 = new DialogueInst ();
		befRitualChoice1.id = 1;
		befRitualChoice.response = "I ran after Ceara, expecting the others to take care of the rest. We have some flowers to collect.";
		befRitualChoice.options.Add ("[Go]");
		befRitualChoice.ResponseNrs.Add (3);
		dialogueContainer.Add (befRitualChoice1);

		DialogueInst befRitualChoice2 = new DialogueInst ();
		befRitualChoice2.id = 2;
		befRitualChoice2.disengage = true;
		befRitualChoice2.NextTrigger("stayWithOthers",true);
		dialogueContainer.Add (befRitualChoice2);

		DialogueInst befRitualChoice3 = new DialogueInst ();
		befRitualChoice3.id = 3;
		befRitualChoice3.disengage = true;
		befRitualChoice3.NextTrigger("followCearaToMom",true);
		dialogueContainer.Add (befRitualChoice3);

		allDialogues.Add ("befRitualChoice", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		DialogueInst followCeara = new DialogueInst ();
		followCeara.id = 0;
		followCeara.response = "What are you doing here?";
		followCeara.thoughts = "";
		followCeara.options.Add ("Came to help");
		followCeara.ResponseNrs.Add (1);
		dialogueContainer.Add (followCeara);


		DialogueInst followCearaExit = new DialogueInst ();
		followCearaExit.id = 0;
		followCearaExit.disengage = true;
		dialogueContainer.Add (followCearaExit);
		
		allDialogues.Add ("followCeara", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion





	}


	public List<string> GetOptions(string s,int c){

		Debug.Log(s+" "+allDialogues.Count+" "+c+" "+allDialogues[s][c].options.Count);
		return allDialogues[s][c].options;

	}

}
