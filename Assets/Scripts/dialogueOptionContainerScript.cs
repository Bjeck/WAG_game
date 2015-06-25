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
	public float responseSpeed = 0.015f;
	public float thoughtsSpeed = 0.02f;
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
	}

	public Alternate altThou = new Alternate();
	public void AlterThoughts(string n){
		altThou.altResp = n;
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
		momIntroGreet.thoughtsDelay = 2.0f;
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (3);
		momIntroGreet.optionDelay = 3.1f;
		//momIntroGreet.NextTrigger ("",false);
		dialogueContainer.Add (momIntroGreet);

		DialogueInst momIntroStraight = new DialogueInst ();
		momIntroStraight.id = 1;
		momIntroStraight.response = "Come on, get up. Don't look so sulky. I got up just fine.     ¤<Mom turns away and begins to work.>";
		momIntroStraight.thoughts = "..Damn...";
		momIntroStraight.options.Add ("Fine, fine. I'm up.");
		momIntroStraight.options.Add("Any food?");
		momIntroStraight.options.Add("[Grab some tea]");
		momIntroStraight.options.Add("[Walk out of the room]");
		momIntroStraight.ResponseNrs.Add (8);
		momIntroStraight.ResponseNrs.Add (5);
		momIntroStraight.ResponseNrs.Add (3);
		momIntroStraight.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroStraight);

		DialogueInst momIntroTea = new DialogueInst ();
		momIntroTea.id = 3;
		momIntroTea.response = "It's good? I might have made it a little too strong for your tastes.     ¤<Mom turns away and begins to work.>";
		momIntroTea.thoughts = "Ugh, it is strong..";
		momIntroTea.options.Add ("Yeah, damn.");
		momIntroTea.options.Add ("Any food?");
		momIntroTea.options.Add ("See you, then [Walk out]");
		momIntroTea.options.Add ("[Walk out of the room]");
		momIntroTea.ResponseNrs.Add (7);
		momIntroTea.ResponseNrs.Add (5);
		momIntroTea.ResponseNrs.Add (4);
		momIntroTea.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroTea);

		DialogueInst momIntroTea2 = new DialogueInst ();
		momIntroTea2.id = 7;
		momIntroTea2.response = "It's not that bad. Get over yourself, girl.      ¤You also have school today, right?.";
		momIntroTea2.thoughts = "...I'm hungry...";
		momIntroTea2.options.Add ("Right.. I'm hungry, though");
		momIntroTea2.options.Add ("Right. [Exit conversation]");
		momIntroTea2.options.Add("[Walk out of the room]");
		momIntroTea2.ResponseNrs.Add (5);
		momIntroTea2.ResponseNrs.Add (4);
		momIntroTea2.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroTea2);

		DialogueInst momIntro8 = new DialogueInst ();
		momIntro8.id = 8;
		momIntro8.response = "You also have school today, right?.";
		momIntro8.thoughts = "...I'm hungry...";
		momIntro8.options.Add ("Right.. I'm hungry, though");
		momIntro8.options.Add ("Right. [Exit conversation]");
		momIntro8.options.Add("[Walk out of the room]");
		momIntro8.ResponseNrs.Add (5);
		momIntro8.ResponseNrs.Add (4);
		momIntro8.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntro8);

		DialogueInst momIntroOk = new DialogueInst ();
		momIntroOk.id = 5;
		momIntroOk.response = "Sorry, got nothing here... Deidre might have some, if you're lucky.";
		momIntroOk.thoughts = "<..Sigh..>";
		momIntroOk.options.Add ("Right. [Exit conversation]");
		momIntroOk.options.Add ("[Walk away]");
		momIntroOk.ResponseNrs.Add (4);
		momIntroOk.ResponseNrs.Add (4);
		dialogueContainer.Add (momIntroOk);

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
		c2.thoughtsDelay = 0.5f;
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
		c3.thoughtsDelay = 0.5f;
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
		c7.response = "True. Though, I'm afraid all half the town's already lost in tales about his greatness, though.";
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
		c12.response = "He hopes <she says and winks.>";
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
		c16.thoughts = "Let's go see what's happening.";
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
		IllijIntro.response = "That's our plan <says Ceara.>   ¤Well, you're in for something at least. This guy's the real deal..";
		IllijIntro.thoughts = "He seems more excited than usual.";
		IllijIntro.options.Add ("Who is he?");
		IllijIntro.ResponseNrs.Add (2);
		dialogueContainer.Add (IllijIntro);

		DialogueInst ci2 = new DialogueInst ();
		ci2.id = 2;
		ci2.response = "He's a Vraadii Sage.  ¤Vraadii? <Ceara asks.>    ¤Sages who deal with curses and demons.";
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
		ci4.response = "We don't? You never really know until he's had a look around the place. They tend to spot things like that as the first folk, too.";
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
		ci3.response = "He's probably heading to Caudden, but Mikal said he'd stay here a few days for some reason. Maybe he wants to see the city from out here. Who knows.                         ¤Is he a healer? Can he cure the Withered Pine? <Ceara asks.>";
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
		ci6.response = "Let her speak, Tari.    ¤<Ceara glances at me with a sovereign smile.>       ¤He might, but I don't know. Your mother already mentioned she was going to ask about it, but we'll see.";
		ci6.thoughts = "";
		ci6.options.Add ("[Let Ceara ask something]");
		ci6.options.Add ("What did Mikal say? Did he see him?");
		ci6.ResponseNrs.Add (7);
		ci6.ResponseNrs.Add (8);
		dialogueContainer.Add (ci6);

		DialogueInst ci7 = new DialogueInst ();
		ci7.id = 7;
		ci7.response = "My mother's gonna speak to him? <Ceara asks.>    ¤¤Says she's planning on it. But so's half the town, so don't exactly be surprised by that. You want to speak to him too, don't you?            ¤¤Well... <Ceara is hesitating.>";
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
		ci8.response = "Says he did, yeah. Out by Furrow, on his way back from a Courier trip.         ¤My mother's gonna speak to him? <Ceara asks.>       ¤Says she's planning on it. But so's half the town, so don't exactly be surprised by that. You want to speak to him too, don't you?                  ¤Well... <Ceara is hesitating.>";
		ci8.thoughts = "Well...";
		ci8.options.Add ("Of course");
		ci8.options.Add ("Maybe");
		ci8.options.Add ("Not really");
		ci8.ResponseNrs.Add (9);
		ci8.ResponseNrs.Add (10);
		ci8.ResponseNrs.Add (11);
		dialogueContainer.Add (ci8);

		DialogueInst ci9 = new DialogueInst ();
		ci9.id = 9;
		ci9.response = "See? I get it, too. It's rare to see anyone like that out here <Illij says.>  ¤¤Most of them dart directly into Caudden and never look back, <Ceara says.>   ¤¤Exactly. Why this one's staying is not clear to any of us, either, which makes it interesting.";
		ci9.thoughtsDelay = 3f;
		ci9.thoughts = "Apropos being excited...";
		ci9.options.Add ("Where's Trenner?");
		ci9.ResponseNrs.Add (12);
		dialogueContainer.Add (ci9);

		DialogueInst ci10 = new DialogueInst ();
		ci10.id = 10;
		ci10.response = "Hah, you know you want to. No reason to hide it from me. I don't care that you act all tough. It's rare to see anyone like that out here. It's only natural to have questions <Illij says.>";
		ci10.thoughtsDelay = 3f;
		ci10.thoughts = "Apropos being excited...";
		ci10.options.Add ("Where's Trenner?");
		ci10.ResponseNrs.Add (12);
		dialogueContainer.Add (ci10);

		DialogueInst ci11 = new DialogueInst ();
		ci11.id = 11;
		ci11.response = "Hah, you little liar. Don't try to act tough around me, I can see right through that. No point in being so cross. You the same negativity, Ceara?       ¤¤I don't know <she says.> Maybe.         ¤¤<He shakes his head.> Bunch of girls, you are.";
		ci11.thoughtsDelay = 5f;
		ci11.thoughts = "Whatever";
		ci11.options.Add ("Where's Trenner?");
		ci11.ResponseNrs.Add (12);
		dialogueContainer.Add (ci11);

		DialogueInst ci12 = new DialogueInst ();
		ci12.id = 12;
		ci12.response = "<I don't get to ask that question. Ceara and Illij both look away from me.>"; 
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
		sTalkNo.response = "<I glance over at Ceara, who doesn’t seem to know what to do either.>";
		sTalkNo.thoughts = "...Don't know if I want to listen to him.";
		sTalkNo.options.Add ("Want to go talk to him?");
		sTalkNo.options.Add ("Let’s just get out of here.");
		sTalkNo.ResponseNrs.Add (1);
		sTalkNo.ResponseNrs.Add (2);
		dialogueContainer.Add (sTalkNo);

		DialogueInst sTalkNo1 = new DialogueInst ();
		sTalkNo1.id = 1;
		sTalkNo1.response = "Not sure, <she says.> This air is killing me.      ¤¤<She hesitates, then speaks again.> ¤No, let’s go outside.";;
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
		treeBet3.options.Add ("He seemed like an idiot");
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
		cCursed4.response = "<She slowly starts moving, and she does so with strain that seems greater than necessary. Then I see her face.     ¤Across it, in large, dark-purple stripes, there some form of deformation in her face. It’s not exactly a wound, nor a scar, but it looks like…       ¤It looks like her skin has opened and rotten away the meat. There’s an odd smell, of a crass bloom, a raw plant-smell coming from her face, as if we had just cut a flower-stalk open and let it lie in the sun.";
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
		cCursed6.response = "Does it look like this?  ¤<She raises her hand with the same markings across it. The same out-washed purple color, mixed with a bit of green.>";
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
		cCursed8.options.Add ("What did this?");
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
		cCursed10.response = "… think it was that.       ¤<She points at a flower just below her. It has… no, the entire flowerbed have the same marks. The same purplish deformation, stricken across them like it was dyed into the very fabric of the petals.>";
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
		innCurseIntro14.response = "What? You went to the pond!? <Ceara's mother immediately bursts out.> Why didn't you say so?";
		innCurseIntro14.thoughts = "";
		innCurseIntro14.options.Add ("I...");
		innCurseIntro14.ResponseNrs.Add (15);
		dialogueContainer.Add (innCurseIntro14);

		DialogueInst innCurseIntro15 = new DialogueInst ();
		innCurseIntro15.id = 15;
		innCurseIntro15.response = "That's not important anymore, the Sage did not hesitate to stop the mother's angsty reply. Why aren't you allowed to go down there? Is it dangerous?    ¤¤Not... exactly, no. We don't want the kids to interfere with the fish and the moving flowers.   ¤You have moving flowers there? <His tone changed for the worse.>   ¤..Yes? <the mother replied, hesitant.>    ¤And these were the flowers that had the marks?";
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
		befRitualChoice3.NextTrigger("followCeara",true);
		dialogueContainer.Add (befRitualChoice3);

		allDialogues.Add ("befRitualChoice", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region followCeara
		DialogueInst followCeara = new DialogueInst ();
		followCeara.id = 0;
		followCeara.response = "What are you doing here?";
		followCeara.thoughts = "";
		followCeara.options.Add ("Came to help");
		followCeara.ResponseNrs.Add (1);
		dialogueContainer.Add (followCeara);

		DialogueInst followCeara1 = new DialogueInst ();
		followCeara1.id = 1;
		followCeara1.response = "Why? Best leave me alone before you touch something too.";
		followCeara1.thoughts = "";
		followCeara1.options.Add ("Hey, that's not fair. I want to help, okay?");
		followCeara1.options.Add ("I'm staying. I'm your friend. I want to help.");		
		followCeara1.ResponseNrs.Add (2);
		followCeara1.ResponseNrs.Add (2);
		dialogueContainer.Add (followCeara1);

		DialogueInst followCeara2 = new DialogueInst ();
		followCeara2.id = 2;
		followCeara2.response = "Have it your way. Help me find some gloves, then.";
		followCeara2.thoughts = "";
		followCeara2.options.Add ("Bet my mom's got some.");
		followCeara2.ResponseNrs.Add (3);
		dialogueContainer.Add (followCeara2);

		DialogueInst followCeara3 = new DialogueInst ();
		followCeara3.id = 3;
		followCeara3.response = "Right. Let's go there.";
		followCeara3.thoughts = "";
		followCeara3.options.Add ("[Walk]");
		followCeara3.ResponseNrs.Add (4);
		dialogueContainer.Add (followCeara3);

		DialogueInst followCeara4 = new DialogueInst ();
		followCeara4.id = 4;
		followCeara4.response = "<We arrive at my house and knock the door. Mom’s still in there, working.>      ¤Tari? Already home?";
		followCeara4.thoughts = "";
		followCeara4.options.Add ("Sorry, it's an emergency.");
		followCeara4.options.Add ("We need gloves.");
		followCeara4.ResponseNrs.Add (5);
		followCeara4.ResponseNrs.Add (6);
		dialogueContainer.Add (followCeara4);

		DialogueInst followCeara5 = new DialogueInst ();
		followCeara5.id = 5;
		followCeara5.response = "What’s wrong? Oh, gods, what happened to Ceara? Are you okay, dear?";
		followCeara5.thoughts = "";
		followCeara5.options.Add ("Yes, exactly. We need some gloves.");
		followCeara5.ResponseNrs.Add (7);
		dialogueContainer.Add (followCeara5);

		DialogueInst followCeara6 = new DialogueInst ();
		followCeara6.id = 6;
		followCeara6.response = "What for? Oh, god, what happened to Ceara? Are you okay, dear?";
		followCeara6.thoughts = "";
		followCeara6.options.Add ("Yes, exactly. That's why we need some gloves.");
		followCeara6.ResponseNrs.Add (7);
		dialogueContainer.Add (followCeara6);

		DialogueInst followCeara7 = new DialogueInst ();
		followCeara7.id = 7;
		followCeara7.response = "What are they going to help?    ¤There’s a Sage.. He wants to help Ceara <I say, then pause, looking at Ceara again.>";
		followCeara7.thoughts = "Why’s the Sage here again?";
		followCeara7.thoughtsDelay = 2.5f;
		followCeara7.options.Add ("Wait... Ceara? Don't you think it's a little suspicious that the Sage arrives exactly as this shows up?");
		followCeara7.options.Add ("He needs gloves. To... figure out what it is, I guess.");
		followCeara7.ResponseNrs.Add (8);
		followCeara7.ResponseNrs.Add (9);
		dialogueContainer.Add (followCeara7);

		DialogueInst followCeara8 = new DialogueInst ();
		followCeara8.id = 8;
		followCeara8.response = "Don’t worry about that now! If there’s a small chance he can help, that’s great. If not, then we’ll figure it out on our own.";
		followCeara8.thoughts = "";
		followCeara8.options.Add ("But what if he's...");
		followCeara8.options.Add ("You're right.");
		followCeara8.ResponseNrs.Add (10);
		followCeara8.ResponseNrs.Add (9);
		dialogueContainer.Add (followCeara8);

		DialogueInst followCeara10 = new DialogueInst ();
		followCeara10.id = 10;
		followCeara10.response = "Tari <my mom says>, who’s this Sage?   ¤His name is Derec something <Ceara interrupts>, Illij vouched for him. Said he helped in his previous village.  ¤I see <my mom says.> I would probably trust him, then.";
		followCeara10.thoughts = "";
		followCeara10.options.Add ("You sure?");
		followCeara10.options.Add ("You're right.");
		followCeara10.ResponseNrs.Add (11);
		followCeara10.ResponseNrs.Add (10);
		dialogueContainer.Add (followCeara10);

		DialogueInst followCeara11 = new DialogueInst ();
		followCeara11.id = 11;
		followCeara11.response = "No time to not be. Ceara needs help, right? Here are the gloves.";
		followCeara11.thoughts = "";
		followCeara11.options.Add ("Thanks");
		followCeara11.ResponseNrs.Add (15);
		dialogueContainer.Add (followCeara11);

		DialogueInst followCeara12 = new DialogueInst ();
		followCeara12.id = 12;
		followCeara12.response = "Here are the gloves. No go, get help. I'll try to be there.";
		followCeara12.thoughts = "";
		followCeara12.options.Add ("Thanks");
		followCeara12.ResponseNrs.Add (15);
		dialogueContainer.Add (followCeara12);

		DialogueInst followCeara9 = new DialogueInst ();
		followCeara9.id = 9;
		followCeara9.response = "Who's this Sage?";
		followCeara9.thoughts = "";
		followCeara9.options.Add ("Someone from the south. Illij said he knows him.");
		followCeara9.ResponseNrs.Add (13);
		dialogueContainer.Add (followCeara9);

		DialogueInst followCeara13 = new DialogueInst ();
		followCeara13.id = 12;
		followCeara13.response = "Alright. Two seconds <she says, and searches a bit.> Here are the gloves. No go, get help. I'll try to be there.";
		followCeara13.thoughts = "";
		followCeara13.options.Add ("Thanks");
		followCeara13.ResponseNrs.Add (15);
		dialogueContainer.Add (followCeara13);

		DialogueInst followCearaExit = new DialogueInst ();
		followCearaExit.id = 15;
		followCearaExit.disengage = true;
		dialogueContainer.Add (followCearaExit);
		
		allDialogues.Add ("followCeara", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		#region cearaAgree
		DialogueInst cearaAgree = new DialogueInst ();
		cearaAgree.id = 0;
		cearaAgree.response = "<On the way back, Ceara spoke up.>   ¤Hey, about that thing you said. About the Sage being suspicious… Maybe you’re right. But what else are we going to do?";
		cearaAgree.thoughts = "";
		cearaAgree.options.Add ("You’re right.");
		cearaAgree.options.Add ("I'm not sure this is a good idea.");
		cearaAgree.ResponseNrs.Add (1);
		cearaAgree.ResponseNrs.Add (2);
		dialogueContainer.Add (cearaAgree);

		DialogueInst cearaAgree1 = new DialogueInst ();
		cearaAgree1.id = 1;
		cearaAgree1.response = "Let’s hope it works. But don’t worry, if he tells me to drink horse’s blood or something, I’ll refuse.";
		cearaAgree1.thoughts = "";
		cearaAgree1.options.Add ("You really sure it doesn’t hurt?");
		cearaAgree1.ResponseNrs.Add (3);
		dialogueContainer.Add (cearaAgree1);

		DialogueInst cearaAgree2 = new DialogueInst ();
		cearaAgree2.id = 2;
		cearaAgree2.response = "Maybe not... But don’t worry, if he tells me to drink horse’s blood or something, I’ll refuse.";
		cearaAgree2.thoughts = "";
		cearaAgree2.options.Add ("You really sure it doesn’t hurt?");
		cearaAgree2.ResponseNrs.Add (3);
		dialogueContainer.Add (cearaAgree2);

		DialogueInst cearaAgree3 = new DialogueInst ();
		cearaAgree3.id = 3;
		cearaAgree3.response = "Yeah, it’s weird. My vision is a little jumpy. Like I’m seeing things that aren’t there, but not really.";
		cearaAgree3.thoughts = "";
		cearaAgree3.options.Add ("Man, I really hope this works.");
		cearaAgree3.ResponseNrs.Add (4);
		dialogueContainer.Add (cearaAgree3);

		DialogueInst cearaAgree4 = new DialogueInst ();
		cearaAgree4.id = 4;
		cearaAgree4.response = "Me too. Tari… <she says and stops, looks at me with a wanting look> If it doesn’t… please—";
		cearaAgree4.thoughts = "";
		cearaAgree4.options.Add ("Stop. You don't have to say anything.");
		cearaAgree4.ResponseNrs.Add (5);
		dialogueContainer.Add (cearaAgree4);

		DialogueInst cearaAgree5 = new DialogueInst ();
		cearaAgree5.id = 5;
		cearaAgree5.response = "… Thanks. <she smiles weakly, and begins walking again.>";
		cearaAgree5.thoughts = "";
		cearaAgree5.options.Add ("Follow her.");
		cearaAgree5.ResponseNrs.Add (5);
		dialogueContainer.Add (cearaAgree5);

		DialogueInst cearaAgreeExit = new DialogueInst ();
		cearaAgreeExit.id = 10;
		cearaAgreeExit.disengage = true;
		cearaAgreeExit.NextTrigger("cearaRitIntro",false);
		dialogueContainer.Add (cearaAgreeExit);

		allDialogues.Add ("cearaAgree", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();
		#endregion

		//OH WAIT I AHVE TO GE THE PLANT TOO?????????????????


		#region stayWithOthers

		DialogueInst stayWithOthers = new DialogueInst ();
		stayWithOthers.id = 0;
		stayWithOthers.response = "<I see Ceara wander off. She can do that by herself.>   ¤We need wood! Where does the fire need to be? ¤Outside. It needs to burn the air <the Sage says>. I’m going to get my equipment. Try to start a fire in the meantime.  ¤<Several people begin to gather wood back and forth. But most still stand and do nothing.>";
		stayWithOthers.options.Add ("[Wait and see what happens]");
		stayWithOthers.options.Add ("What can I help with?");
		stayWithOthers.ResponseNrs.Add (1);
		stayWithOthers.ResponseNrs.Add (2);
		dialogueContainer.Add (stayWithOthers);

		DialogueInst stayWithOthers1 = new DialogueInst ();
		stayWithOthers1.id = 1;
		stayWithOthers1.response = "Are we really going to kill a cat, Mauge? <another person said.>   ¤What else are we going to do? Do you have any other animal bones?  ¤No, but why do we need them?  ¤Because the sage said so!";
		stayWithOthers1.options.Add ("Can we trust him?");
		stayWithOthers1.options.Add ("It’s for Ceara. Who knows what’ll happen to her.");
		stayWithOthers1.ResponseNrs.Add (3);
		stayWithOthers1.ResponseNrs.Add (4);
		dialogueContainer.Add (stayWithOthers1);

		DialogueInst stayWithOthers2 = new DialogueInst ();
		stayWithOthers2.id = 2;
		stayWithOthers2.response = "You can help with the fire. Or go find some iron. <Ceara’s mother says.> unless you happen to have some cat’s bones lying around.  ¤Are we really going to kill a cat, Mauge? <another person said.>   ¤What else are we going to do? Do you have any other animal bones?  ¤No, but why do we need them?  ¤Because the sage said so!";
		stayWithOthers2.options.Add ("Can we trust him?");
		stayWithOthers2.options.Add ("It’s for Ceara. Who knows what’ll happen to her.");
		stayWithOthers2.ResponseNrs.Add (3);
		stayWithOthers2.ResponseNrs.Add (4);
		dialogueContainer.Add (stayWithOthers2);

		DialogueInst stayWithOthers3 = new DialogueInst ();
		stayWithOthers3.id = 3;
		stayWithOthers3.response = "Do we have a choice?  ¤No, no. Wait, the girl might be right <Mikal says> The guy just showed up today, right? Just as this stuff starts appearing down south.  ¤Oh please <Mauge says> he’s a Sage, not a sorcerer. ¤So what? ¤Sorcerers can’t even do this if they wanted, much less a Sage <Illij says, the first words from him out here.> ¤What do you know about that? <Mikal says, but it’s obvious that the crowd is already against him there. Everyone knows that Eastern folk know about magic.>";
		stayWithOthers3.options.Add ("[Listen]");
		stayWithOthers3.options.Add ("What cat, then?");
		stayWithOthers3.ResponseNrs.Add (6);
		stayWithOthers3.ResponseNrs.Add (7);
		dialogueContainer.Add (stayWithOthers3);

		DialogueInst stayWithOthers4 = new DialogueInst ();
		stayWithOthers4.id = 4;
		stayWithOthers4.response = "Right! <Mauge says> If the Sage says this helps Ceara, we have to. Please.   ¤But whose cat would we kill? <Mikal says> My wife’s? Gerrec’s? Jean’s? Illij’s? Gods no, we ain’t doing any of that.  ¤We have to. Anyone, please… For Ceara…";
		stayWithOthers4.thoughts = "I don’t have a cat. Mom wouldn’t allow it.";
		stayWithOthers4.options.Add ("[Listen]");
		stayWithOthers4.ResponseNrs.Add (5);
		dialogueContainer.Add (stayWithOthers4);

		DialogueInst stayWithOthers6 = new DialogueInst ();
		stayWithOthers6.id = 6;
		stayWithOthers6.response = "Right. Whose cat would we kill? <Mikal says> My wife’s? Gerrec’s? Jean’s? Gods no, we ain’t doing any of that.  ¤<Mauge looks around at the people> We have to. Anyone, please… For Ceara…";
		stayWithOthers6.options.Add ("[Listen]");
		stayWithOthers6.ResponseNrs.Add (5);
		dialogueContainer.Add (stayWithOthers6);

		DialogueInst stayWithOthers7 = new DialogueInst ();
		stayWithOthers7.id = 7;
		stayWithOthers7.response = "Anyway, whose cat would we kill? <Mikal says> My wife’s? Gerrec’s? Jean’s? Gods no, we ain’t doing any of that.  ¤<Mauge looks around at the people> We have to. Anyone, please… For Ceara…";
		stayWithOthers7.options.Add ("[Listen]");
		stayWithOthers7.ResponseNrs.Add (5);
		dialogueContainer.Add (stayWithOthers7);

		DialogueInst stayWithOthers5 = new DialogueInst ();
		stayWithOthers5.id = 5;
		stayWithOthers5.response = "You can take mine <someone says. We all turn around and see Mikal’s wife Perna standing in the corner looking at the rest of us.>   ¤Perna… <Mikal says> What are you doing?   ¤It’s fine, Mikal. She’s old. Ceara needs it.   ¤<Mikal stares at her for a while, stepping closer, beginning to pull a hand to her wife but stopping again.>     ¤Fine.  ¤Thank you, thank you! <Mauge says, rushing over to hug Perna>.";
		stayWithOthers5.options.Add ("What else did we need?");
		stayWithOthers5.ResponseNrs.Add (8);
		dialogueContainer.Add (stayWithOthers5);

		DialogueInst stayWithOthers8 = new DialogueInst ();
		stayWithOthers8.id = 8;
		stayWithOthers8.response = "A compass, right? And a pan.   ¤Iron pan <Illij corrected. That was apparently important.> I can get the compass.   ¤Just a pan, right? I’ll get that <Mauge says and rushes home after thanking Perna once again>.";
		stayWithOthers8.options.Add ("[Wait]");
		stayWithOthers8.ResponseNrs.Add (9);
		dialogueContainer.Add (stayWithOthers8);

		DialogueInst stayWithOthersEx = new DialogueInst ();
		stayWithOthersEx.id = 9;
		stayWithOthersEx.disengage = true;
		stayWithOthersEx.NextTrigger("stayRitIntro",false);
		dialogueContainer.Add (stayWithOthersEx);

		
		allDialogues.Add ("stayWithOthers", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();

		#endregion

		#region afterRitChoice

		DialogueInst ritChoice = new DialogueInst ();
		ritChoice.id = 0;
		ritChoice.response = "Yeah, I see it too <the Sage says, looking at me staring upwards while people are running away. I’m surprised he hasn’t run too>.";
		ritChoice.options.Add ("Should we go?");
		ritChoice.options.Add ("What is it?");
		ritChoice.ResponseNrs.Add (1);
		ritChoice.ResponseNrs.Add (2);
		dialogueContainer.Add (ritChoice);

		DialogueInst ritChoice1 = new DialogueInst ();
		ritChoice1.id = 1;
		ritChoice1.response = "Yes, we should.";
		ritChoice1.options.Add ("To Caudden?");
		ritChoice1.options.Add ("I want to go north.");
		ritChoice1.ResponseNrs.Add (3);
		ritChoice1.ResponseNrs.Add (4);
		dialogueContainer.Add (ritChoice1);

		DialogueInst ritChoice2 = new DialogueInst ();
		ritChoice2.id = 2;
		ritChoice2.response = "Something really big. I have never seen a weatherhex be this huge. And I don’t know how it connects to the purple infestation. We need to get away from here before we find out the way your friend did, though.";
		ritChoice2.options.Add ("To Caudden? You want to go towards it?");
		ritChoice1.options.Add ("I want to go north.");
		ritChoice2.ResponseNrs.Add (3);
		ritChoice2.ResponseNrs.Add (4);
		dialogueContainer.Add (ritChoice2);

		DialogueInst ritChoice3 = new DialogueInst ();
		ritChoice3.id = 3;
		ritChoice3.response = "Yes. It's a slim chance, but we need to.";
		ritChoice3.options.Add ("Ok, let’s go.");
		ritChoice3.options.Add ("No, I.. I'm going north.");
		ritChoice3.ResponseNrs.Add (5);
		ritChoice3.ResponseNrs.Add (4);
		dialogueContainer.Add (ritChoice3);

		DialogueInst ritChoice4 = new DialogueInst ();
		ritChoice4.id = 4;
		ritChoice4.response = "You go north then. I’m going to Caudden.";
		ritChoice4.options.Add ("Hmm.. ok, nevermind. I'm going with you.");
		ritChoice4.options.Add ("Good luck");
		ritChoice4.ResponseNrs.Add (5);
		ritChoice4.ResponseNrs.Add (6);
		dialogueContainer.Add (ritChoice4);

		DialogueInst ritChoice5 = new DialogueInst ();
		ritChoice5.id = 5;
		ritChoice5.disengage = true;
		ritChoice5.NextTrigger("goesToCaudden",false);
		dialogueContainer.Add (ritChoice5);
		
		DialogueInst ritChoiceEx = new DialogueInst ();
		ritChoiceEx.id = 6;
		ritChoiceEx.disengage = true;
		ritChoiceEx.NextTrigger("goesNorth",false);
		dialogueContainer.Add (ritChoiceEx);
		
		
		allDialogues.Add ("ritChoice", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();

		#endregion



		#region Search
		DialogueInst search = new DialogueInst ();
		search.id = 0;
		search.response = "The skies have lost the signs of the early epidemic, the early clouds that gather everywhere. It has been here a long time, at this stage. We are too late.     ¤Still, we must investigate, find out what we can, understand the curse as it struck here. Fortunately, Eravola leaves many traces of what happened before.  ¤¤¤The signs are crossed out. No one who lives here anymore.";
		search.thoughts = "/Initiate---Module C5F.04. V. 5.4";
		search.options.Add ("Next");
		search.ResponseNrs.Add (9);
		dialogueContainer.Add (search);

		DialogueInst search1 = new DialogueInst ();
		search1.id = 9;
		search1.response = "The grass is purple, the skies are blue. Houses that are surprisingly intact are scattered along the overgrown roadside, not burnt down, not rioted or looted—just abandoned.     ¤¤Vines peer out of the broken windows, creeping up the walls and twisting around the doorframes where the door has long since rotted away.     ¤¤Cutlery, plates, and tools are all left in their places, scattered around on tables without anything in them; as if the town was inhabited by ghosts that didn’t eat or work. All food, all drinks are gone or poisoned, devoured away by the purple, decrepit force that took over.";
		search1.thoughts = "";
		search1.options.Add ("Investigate the Inn");
		search1.options.Add ("Investigate the Pond.");
		search1.options.Add ("Investigate the Houses.");
		search1.options.Add ("Move.");
		search1.ResponseNrs.Add (1);
		search1.ResponseNrs.Add (2);
		search1.ResponseNrs.Add (3);
		search1.ResponseNrs.Add (8);
		dialogueContainer.Add (search1);

		DialogueInst search2 = new DialogueInst ();
		search2.id = 8;
		search2.response = "";
		search2.thoughts = "";
		search2.options.Add ("Investigate the Stables");
		search2.options.Add ("Investigate the Roadside.");
		search2.options.Add ("Return.");
		search2.options.Add ("Leave.");
		search2.ResponseNrs.Add (4);
		search2.ResponseNrs.Add (5);
		search2.ResponseNrs.Add (9);
		search2.ResponseNrs.Add (99);
		dialogueContainer.Add (search2);

		DialogueInst searchinn = new DialogueInst ();
		searchinn.id = 1;
		searchinn.response = "The Inn was the gathering hall for the village when it was inhabited. The evidence of this is clear, the many chairs, the many empty tankards and plates, the large kitchen with a stove and oven enough to feed twenty men.   ¤¤There are trails of a conversation here. Words that linger in the air. But none of them are clear enough that we can hear them.  ¤¤By the doorside, there are a lot of footsteps, as if the entire village shuffled in and out of the inn at once. Something big must have happened that day   ¤¤This was one of the first places the curse hit, see the coloration of the plants in here have a darker gradient, starting to crumble. It’s far south, so the plague must have hit from the south.";
		searchinn.thoughts = "";
		searchinn.options.Add ("Investigate Further");
		searchinn.options.Add ("Go Back");
		searchinn.ResponseNrs.Add (11);
		searchinn.ResponseNrs.Add (9);
		dialogueContainer.Add (searchinn);

		DialogueInst searchinn2 = new DialogueInst ();
		searchinn2.id = 11;
		searchinn2.response = "There are scraps of a journal in a withered bag that is porous from the infestation. Scanning the note, we see the following:        ¤¤<I will arrive tomorrow. Still no sign of any curse. The weather is acting up, though, clouds circling. The town I’m going to is supposed to have an inn, so I can hopefully rest there a while. This has been a long journey, and I’m not looking forward to seeing those pompous idiots from Caudden one bit.>                 ¤¤Lucky the note was preserved so well, the bag has helped keep it safe.     ¤¤There’s nothing else here.";
		searchinn2.thoughts = "";
		searchinn2.options.Add ("Go Back");
		searchinn2.ResponseNrs.Add (9);
		dialogueContainer.Add (searchinn2);

		DialogueInst searchpond = new DialogueInst ();
		searchpond.id = 2;
		searchpond.response = "The little pond to the south of the village would have been a pleasant spot to relax pre-curse. A once magnificent willowtree lies bent over, crashed into the pond, mushy and deteriorated by the eating curse.    ¤¤There are signs of moving plants around the pond.  That’s why it spread so fast from Caudden. The moving plants have carried it down here, and then up to the village with a scary pace. The villagers must have been completely defenseless.       ¤¤There are marks of a girl landing here, underneath where the willowtree should have been. And footsteps leading back to the village. There are also a set of footsteps leading towards Caudden.";
		searchpond.thoughts = "";
		searchpond.options.Add ("Follow the other Footsteps");
		searchpond.options.Add ("Go Back");
		searchpond.ResponseNrs.Add (22);
		searchpond.ResponseNrs.Add (9);
		dialogueContainer.Add (searchpond);

		DialogueInst searchpond2 = new DialogueInst ();
		searchpond2.id = 22;
		searchpond2.response = "They stagger and stumble across a small path, in the beginning following a regular, but fast, rhythm, then slowly sagging and becoming haphazard.     ¤¤Eventually, long down the road, but only halfway to Cauddden, lies a skeleton peeking out from the ground. The purple mold has almost enveloped it fully, but you can still see a little edge of a cranium and some scattered bones lying.          ¤¤The bones come from a human, a woman in her forties, carrying a small box of jewels. Why she decided to run this way is beyond our understanding. ¤[WHO IS SHE? THIS I CAN CUT IF NEEDED]";
		searchpond2.thoughts = "";
		searchpond2.options.Add ("Go Back");
		searchpond2.ResponseNrs.Add (9);
		dialogueContainer.Add (searchpond2);

		DialogueInst searchhouses = new DialogueInst ();
		searchhouses.id = 3;
		searchhouses.response = "There are many houses in the village, each covered in the purple plants. Most of them are empty and without much of interest.   ¤We found two that might have something interesting, though.";
		searchhouses.thoughts = "";
		searchhouses.options.Add ("Go to the Leatherdyer's house.");
		searchhouses.options.Add ("Go to the house around the corner");
		searchhouses.ResponseNrs.Add (33);
		searchhouses.ResponseNrs.Add (335);
		dialogueContainer.Add (searchhouses);

		DialogueInst searchhouses2 = new DialogueInst ();
		searchhouses2.id = 33;
		searchhouses2.response = "Half devoted as a living area, half devoted to a leatherworker’s practice, the smell of the dyeing process is still stained in the wooden walls, even as they are purple.    ¤¤The house is small, with only one room with two tiny beds, and a small kitchen with one table and two chairs. The rest the leatherworking space, with purple, cursed leather stretched out on tables and vats full of dye that interestingly aren’t contaminated. Note that down: The dye, even though it’s from something living, has not been infested by Eravola. This should be investigated further.             ¤¤Other than that, there are remnants of a conversation here.";
		searchhouses2.thoughts = "";
		searchhouses2.options.Add ("Listen");
		searchhouses2.options.Add ("Go Back");
		searchhouses2.ResponseNrs.Add (331);
		searchhouses2.ResponseNrs.Add (9);
		dialogueContainer.Add (searchhouses2);

		DialogueInst searchhouses3 = new DialogueInst ();
		searchhouses3.id = 331;
		searchhouses3.response = "Loading Conversation c_LW_01… Done.      ¤¤‘Hold it’  ¤‘What?’    ¤‘Stop it with your high and mighty attitude, girl. I’m working days and nights off, and you think none of it matters, do you?’   ¤‘Gods, mom, can’t you relax a little? We didn’t get close to the city.’   ¤‘Don’t you go and excuse this as something little. I don’t want you going there! It’s dangerous!’    ¤	*END*	";
		searchhouses3.thoughts = "";
		searchhouses3.options.Add ("Go Back");
		searchhouses3.ResponseNrs.Add (9);
		dialogueContainer.Add (searchhouses3);

		DialogueInst searchhouses4 = new DialogueInst ();
		searchhouses4.id = 335;
		searchhouses4.response = "The lone house on the hill is different from the rest of them. It’s further away from the main road than most of them, it’s built in a different time, judging by the wood, and it’s built with a different set of tools.       ¤¤Inside, however, you see the most profound differences. Instead of the regular decorum in most houses in this area, there are no golden circles on the walls, no unburnt candles beside the door. A foreigner lived here.       ¤¤A well-kept skeleton lies in the middle of the living room. Male, late thirties. He must have stayed home when he saw the spread, hoping it wouldn’t get in here. It took a while, too, the stone slabs around his house and ceramic oven slowed the onslaught significantly, but it wasn’t enough. Poor guy.";
		searchhouses4.thoughts = "";
		searchhouses4.options.Add ("Go Back");
		searchhouses4.ResponseNrs.Add (9);
		dialogueContainer.Add (searchhouses4);

		DialogueInst searchstables = new DialogueInst ();
		searchstables.id = 4;
		searchstables.response = "Many footsteps lead to the stables, where there are signs of horses being kept; around six, we estimate. They were torn away from their stalls, the saddles still hanging on the walls. There one skeleton here. Man, middle-aged. Got a few broken bones. Horses must have trampled him to death. The Eravola did the rest.      ¤¤There are signs of blood on the doorframe. Someone scraped by there, wounding themselves. Badly enough, it seems, to leave a faint trail going out of the stable, toward Caudden.";
		searchstables.thoughts = "";
		searchstables.AlterResp("Many footsteps lead to the stables, where there are signs of horses being kept; around six, we estimate. They were torn away from their stalls, the saddles still hanging on the walls. There was quite a rustle here, many footsteps leading in all directions, hoof prints pressed down on top of each other, where the new plants haven’t covered them up completely.       ¤¤Remnants of two people lie on the ground, skeletons that have almost completely disappeared beneath the overgrowth. Difficult to assess properties. Perhaps both male, perhaps one male and one female. Adults.      ¤¤In the corner lies a lone horseshoe with blood spattered on it.");
		searchstables.options.Add ("Investigate");
		searchstables.options.Add ("Go Back");
		searchstables.ResponseNrs.Add (44);
		searchstables.ResponseNrs.Add (8);
		dialogueContainer.Add (searchstables);

		DialogueInst searchstables2 = new DialogueInst ();
		searchstables2.id = 44;
		searchstables2.response = "The trail leads down beside the village, as if the rider was trying to avoid the village at first. It curves around in a gentle bow until it stops and goes straight for another short length, then there’s a skeleton. But not a human one: A horse skeleton. Must have tripped. Or struck by limb-paralysis from the Eravola.     ¤¤There are scatterings of downtrodden purple plants, of shuffling feet, of someone scrambling along the plants, but they were probably already infested at this point.      ¤¤The rider lies just a little further down the road. It’s a child, too. Can’t be more than seventeen. Girl.";
		searchstables2.thoughts = "";
		searchstables2.AlterResp("Following them takes a while, as they get quite far. The take a detour around the village, possibly to avoid the plants that were encroaching. The rider managed to get far, too. Got out of the village and went towards Caudden. [END OF SITE REACHED]      ¤¤Unclear whether they are the ones who brought the plague into Caudden. However, since it came from the south, Caudden might have been infested already.");
		searchstables2.options.Add ("Go Back");
		searchstables2.ResponseNrs.Add (8);
		dialogueContainer.Add (searchstables2);

		DialogueInst searchRoadside = new DialogueInst ();
		searchRoadside.id = 5;
		searchRoadside.response = "Something peculiar’s by the roadside. Specks of ash, of burnt coal. Someone made a fire here. Seems, odd, though. There are no marks of a regular fireplace, no stone circle.      ¤¤Beside it, there are marks of someone lying, and, judging by the darker purple, it was an Eravola victim. To the left of that, another person sat. There are flakes of iron and bone in the dirt. Maybe they did a curse-analysis. They must not have had a lot of time for that, though, if it is true that the one beside was infected already.         ¤¤However, performing such a thing means that there was a Sage present. This is not present in any of the previous records. A Caudden Sage would have known what it was, too, and wouldn’t have needed to perform an analysis.       ¤¤There are several footsteps leading away, one leading over to the stables, but another, heavier set, leading north.";
		searchRoadside.thoughts = "";
		searchRoadside.options.Add ("Go to the Stables");
		searchRoadside.options.Add ("Follow the other set of footsteps");
		searchRoadside.options.Add ("Go Back");
		searchRoadside.ResponseNrs.Add (4);
		searchRoadside.ResponseNrs.Add (55);
		searchRoadside.ResponseNrs.Add (8);
		dialogueContainer.Add (searchRoadside);

		DialogueInst searchRoadside2 = new DialogueInst ();
		searchRoadside2.id = 55;
		searchRoadside2.response = "Either this was a heavy person, or they were carrying something heavy, since they are considerably deeper than other footsteps here. They lead north, toward the forest in a hurried pace.       ¤¤However, there is something uncomfortable about them. They stutter and start again, becomes slow and erratic.     ¤Outside the village, they split into two sets, but both stop almost immediately and return back to each other. Signs point to one of them lying there again, but then walking a bit farther.         ¤¤Eventually they both stop. They must have been infected. At least one of them. Their pace is too strange for anything else to be the case. The stopping could also have been caused by hyper function of motor abilities, one of them forcing their way from the other, or pushing them into the ground.";
		searchRoadside2.thoughts = "";
		searchRoadside2.options.Add ("Go Back");
		searchRoadside2.ResponseNrs.Add (8);
		dialogueContainer.Add (searchRoadside2);

		DialogueInst searchleave = new DialogueInst ();
		searchleave.id = 10;
		searchleave.response = "             ¤Area excavated.     ¤Amount of information gained from staying is negligible.           ¤Path south found. Venture forth?";
		searchleave.thoughts = "";
		searchleave.options.Add ("Go");
		searchleave.options.Add ("Exit Program");
		searchleave.ResponseNrs.Add (99);
		searchleave.ResponseNrs.Add (91);
		dialogueContainer.Add (searchleave);

		DialogueInst searchleave2 = new DialogueInst ();
		searchleave2.id = 99;
		searchleave2.response = "The outbreak is worse here. Origin is definitely sure.      ¤The city of Caudden grows larger as we get closer, the chimneys lining the sky rise up above it all, in patterns of frozen grass.     ¤It’s clear that the city is dead already. The Eravola is everywhere, purple grass bedding the fields, vines and crooked flowers greet us as we inch closer.";
		searchleave2.thoughts = "";
		searchleave2.options.Add ("Investigate");
		searchleave2.ResponseNrs.Add (98);
		dialogueContainer.Add (searchleave2);

		DialogueInst searchleave3 = new DialogueInst ();
		searchleave3.id = 98;
		searchleave3.response = "We doubt we can get closer. We’re getting out of reach, signal is faltering.    ¤The walls of the city are becoming overgrown, too, climbing plants curl up their sides, seething into the stone.";
		searchleave3.thoughts = "";
		searchleave3.options.Add ("Investigate");
		searchleave3.ResponseNrs.Add (97);
		dialogueContainer.Add (searchleave3);

		DialogueInst searchleave4 = new DialogueInst ();
		searchleave4.id = 97;
		searchleave4.response = "Finally, just before we lose connection, there’s one more thing. A movement inside. Something’s disturbing our view through the gate. Like it’s being blocked. ";
		searchleave4.thoughts = "";
		searchleave4.options.Add ("Investigate");
		searchleave4.ResponseNrs.Add (96);
		dialogueContainer.Add (searchleave4);

		DialogueInst searchleave5 = new DialogueInst ();
		searchleave5.id = 96;
		searchleave5.response = "There’s something living in there… How can it… What—No_ItC                ¤¤ --- ERROR ---     ¤SIGNAL LOST.  ¤ATTEMPTING REBOOT…              ¤…              ¤Reboot failed. AT---**********     ¤¤Hello. I’m… here?  ¤I made it. Wow. Hello there.  ¤Caution, what you are about to hear is extraordinary. ¤I have survived. There is something else in here. There is something spreading this. I think I have seen what it is but I haven’t been able to get close.  ¤Sorry for hijacking your signal, but I had to get this message out. I hope you find it well. I hope you can save me.";
		searchleave5.thoughts = "";
		searchleave5.options.Add ("Investigate");
		searchleave5.ResponseNrs.Add (95);
		dialogueContainer.Add (searchleave5);

		DialogueInst searchleave6 = new DialogueInst ();
		searchleave6.id = 95;
		searchleave6.response = "SIGNAL LOST ………………………………………                ¤SIGNAL LOST ………………………………………                ¤SIGNAL LOST ………………………………………                 ¤SIGNAL LOST ………………………………………                                  ¤Probe left transmission area.         ¤Shutting down Natural Language Interface… Done  ¤Exiting search… Done";
		searchleave6.thoughts = "";
		searchleave6.options.Add ("Investigate");
		searchleave6.ResponseNrs.Add (100);
		dialogueContainer.Add (searchleave6);

		DialogueInst searchleave7 = new DialogueInst ();
		searchleave7.id = 91;
		searchleave7.response = "Sending Probe Home... Done.              ¤Shutting down Natural Language Interface… Done  ¤Exiting search… Done";
		searchleave7.thoughts = "";
		searchleave7.options.Add ("Investigate");
		searchleave7.ResponseNrs.Add (100);
		dialogueContainer.Add (searchleave7);

		DialogueInst searchEx = new DialogueInst ();
		searchEx.id = 100;
		searchEx.response = "Area Search Over.               ¤Uploading Results… Done.    ¤Amount of information: 5.4  ¤Relevance: 78%  ¤Further research possibilities: 2  ¤Score: 8  ¤Expected survivability of Area: 0.4 minutes.  ¤Origin: South.  ¤Spread: North, East.   ¤Area categorized: Hazardous.            ¤¤Thank you.                          ¤¤¤¤                         -- Together, we can stop the spread --";
		searchEx.thoughts = "";
		searchEx.options.Add ("Restart");
		searchEx.options.Add ("Exit");
		searchEx.ResponseNrs.Add (102);
		searchEx.ResponseNrs.Add (101);
		dialogueContainer.Add (searchEx);

		DialogueInst searchEx2 = new DialogueInst ();
		searchEx2.id = 101;
		searchEx2.response = "";
		searchEx2.thoughts = "";
		searchEx2.disengage = true;
		dialogueContainer.Add (searchEx2);

		DialogueInst searchEx3 = new DialogueInst ();
		searchEx3.id = 102;
		searchEx3.response = "";
		searchEx3.thoughts = "";
		searchEx3.disengage = true;
		dialogueContainer.Add (searchEx3);
		
		allDialogues.Add ("search", dialogueContainer);
		dialogueContainer = new List<DialogueInst> ();

		#endregion


	}


	public List<string> GetOptions(string s,int c){

		Debug.Log(s+" "+allDialogues.Count+" "+c+" "+allDialogues[s][c].options.Count);
		return allDialogues[s][c].options;

	}

}
