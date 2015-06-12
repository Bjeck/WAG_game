using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ambientInst : Inst {
	public float ambDelay = 0;

}


public class ambientVoiceContainer : MonoBehaviour {
	public static ambientVoiceContainer instance { get; private set; }

	public List<ambientInst> ambientContainer = new List<ambientInst>();
	
	public Dictionary<string, List<ambientInst>> allAmbients = new Dictionary<string, List<ambientInst>>();


	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);

		#region firstVillage
	//FIRST VILLAGE INTRO
		ambientInst firstVillage = new ambientInst ();
		firstVillage.id = 0;
		firstVillage.response = "'What?' ¤'Yes. Heard he's coming today.'¤'When?' ¤'Don't know. But it's soon.'";
		firstVillage.thoughts = "I live in a small hovel on the outskirts of Caudden City, far enough away that you can’t smell the shit but still close enough that the chimneys line the sky.";
		firstVillage.thoughtsDelay = 3;

		ambientContainer.Add (firstVillage);

		ambientInst firstVillage2 = new ambientInst ();
		firstVillage2.id = 1;
		firstVillage2.response = "'Well, I better go tell Rasmin. He'll be overjoyed to learn something's happening.'¤'You do that'";
		firstVillage2.thoughts = "The most exciting thing that happens in this town is when the smoke changes colour because of a mage experiment gone wrong in the city.";
		firstVillage2.thoughtsDelay = 2;
		
		ambientContainer.Add (firstVillage2);

		ambientInst firstVillage3 = new ambientInst ();
		firstVillage3.id = 2;
		firstVillage3.disengage = true;
		ambientContainer.Add (firstVillage3);

		allAmbients.Add ("firstVillage", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region innIntro
	//INN INTRO
		ambientInst innIntro1 = new ambientInst ();
		innIntro1.id = 0;
		innIntro1.response = "";
		innIntro1.thoughts = "There's a crowd gathering at the inn, as I suspected. Something happening is bound to be interesting, regardless of what it is.  ¤Nearly half the village is already gathered here, talking loudly about wild rumours, misinforming, and just generally enjoying themselves. ";
		ambientContainer.Add (innIntro1);

		ambientInst innIntro2 = new ambientInst ();
		innIntro2.id = 1;
		innIntro2.response = "";
		innIntro2.thoughts = "Me and Ceara scout around for Illij, and spot him at a corner table sitting alone as he usually does. ¤We approach lightly, sitting down next to him, before he even notices us. ¤¤\'Come to see the show?\' he asks.";
		ambientContainer.Add (innIntro2);

		ambientInst exit = new ambientInst ();
		exit.id = 2;
		exit.disengage = true;
		ambientContainer.Add (exit);

		allAmbients.Add ("innIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region sageIntro
		ambientInst sageIntro1 = new ambientInst ();
		sageIntro1.id = 0;
		sageIntro1.response = "'He's here!'";
		sageIntro1.thoughts = "I'm interrupted by the door opening and someone shouting.";
		sageIntro1.ambDelay = 1.5f;
		ambientContainer.Add (sageIntro1);

		ambientInst sageIntro2 = new ambientInst ();
		sageIntro2.id = 1;
		sageIntro2.response = "'What's he look like, you think?'¤'Dammit, I forgot my purse'¤'What do you--'";
		sageIntro2.thoughts = "Murmur erupts and dies immediately as more people enter the inn, followed lastly by someone I don't know. I assume that's him.";
		ambientContainer.Add (sageIntro2);

		ambientInst sageIntr3 = new ambientInst ();
		sageIntr3.id = 2;
		sageIntr3.response = "";
		sageIntr3.thoughts = "He's tall, similar dark skin as Illij, but still lighter, as if it was a mix of the two.  ¤His clothes are strange, red and brown, with green lines running down in a foreign pattern, mostly on his arms and chest, criss-crossing each other in something that must have taken forever to sew.   ¤He walks in and looks around, everyone else staring up at him as if he's their long lost child who came home after a war they all thought he died in.";
		ambientContainer.Add (sageIntr3);

		ambientInst sageIntr4 = new ambientInst ();
		sageIntr4.id = 3;
		sageIntr4.response = "Hello, he says. He crooks a smile.";
		sageIntr4.thoughts = "He looks, all in all, like an asshole.         ¤No, looking at his clothes, he looks like a rich asshole.";
		sageIntr4.thoughtsDelay = 1f;
		ambientContainer.Add (sageIntr4);

		ambientInst sageIntr5 = new ambientInst ();
		sageIntr5.id = 4;
		sageIntr5.response = "";
		sageIntr5.thoughts = "Great..";
		sageIntr5.thoughtsSpeed = 0.08f;
		ambientContainer.Add (sageIntr5);

		ambientInst sageIntr6 = new ambientInst ();
		sageIntr6.id = 5;
		sageIntr6.response = "'I can see you all have questions. I will take my time to answer them, don't you worry. But first, I'll need a drink. It's beeen a long journey.'";
		sageIntr6.thoughts = "The people seem to eagerly await his every move, but Deidre (the innkeep) instinctually sets into motion at the order of a drink. This loosens up the crowd a bit, and the murmur begins anew, although this time it's harder to hear what they're saying. Guess they don't want the guest to hear, either.";
		ambientContainer.Add (sageIntr6);
		
		ambientInst sageIntr7 = new ambientInst ();
		sageIntr7.id = 6;
		sageIntr7.response = "";
		sageIntr7.thoughts = "The Sage waltzes into the room and immediately people around him start asking questions he seems to answer in the most leasurely way possible.";
		ambientContainer.Add (sageIntr7);

		ambientInst exitSage = new ambientInst ();
		exitSage.id = 7;
		exitSage.disengage = true;
		exitSage.NextTrigger("shouldTalkToSage",true);
		ambientContainer.Add (exitSage);
		
		allAmbients.Add ("sageIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region pondIntro
		ambientInst pondInt = new ambientInst ();
		pondInt.id = 0;
		pondInt.response = "<Ceara lets out a long sigh.>  ¤Damn it was hot in there    ¤Yeah <I say.>";
		pondInt.thoughts = "We trudge our way through the thick crowds and breathe fresh air again.";
		ambientContainer.Add (pondInt);

		ambientInst pondInt1 = new ambientInst ();
		pondInt1.id = 1;
		pondInt1.response = "So, about that pond, huh? <she asks.>";
		pondInt1.thoughtsDelay = 1f;
		pondInt1.thoughts = "I don’t have to think twice before answering that.";
		ambientContainer.Add (pondInt1);

		ambientInst pondInt2 = new ambientInst ();
		pondInt2.id = 2;
		pondInt2.response = "";
		pondInt2.thoughtsDelay = 1f;
		pondInt2.thoughts = "The pond’s a bit towards Caudden, which is why we’re generally not allowed to go there. But it also has color-fish and wild, moving plants, and an ancient willowtree that’s great fun to climb.";
		ambientContainer.Add (pondInt2);

		ambientInst PondIntEx = new ambientInst ();
		PondIntEx.id = 3;
		PondIntEx.disengage = true;
		PondIntEx.NextTrigger("treeBet",true);
		ambientContainer.Add (PondIntEx);
		
		allAmbients.Add ("pondIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region race
		ambientInst race = new ambientInst ();
		race.id = 0;
		race.response = "";
		race.thoughtsSpeed = 0.01f;
		race.thoughts = "We both start sprinting before she said anything else. We’re on the south side of the pond, and the tree’s to the north. We sprint to the left of the shallow water, and I faintly notice movement under the surface.";
		ambientContainer.Add (race);

		ambientInst race1 = new ambientInst ();
		race1.id = 1;
		race1.response = "";
		race1.thoughtsSpeed = 0.01f;
		race1.thoughts = "My feet feel light and springy on the summer grass, the smell of the waving flowers seething into my nostrils. We’re sidestepping toe to toe, whistling across the pond-side almost soundlessly, even though we hear the wind clatter at our ears.";
		ambientContainer.Add (race1);

		ambientInst race2 = new ambientInst ();
		race2.id = 2;
		race2.response = "";
		race2.thoughtsSpeed = 0.01f;
		race2.thoughts = "She’s had a slight head start, so while I would consider myself faster, she gets her first foot up on the tree. I put up mine on the other side, clawing my bare feet into the slitful bark. I can feel my feet pinch a little, almost feel pain, but I pull myself up and latch onto a branch on top of me.";
		ambientContainer.Add (race2);

		ambientInst race3 = new ambientInst ();
		race3.id = 3;
		race3.response = "";
		race3.thoughtsSpeed = 0.01f;
		race3.thoughts = "We hear the cracking of branches and the rough sliding of skin across tree-bark as we both scramble up the unruly tree, mowing away any little annoyance in our way, were it branches or leaves or each other. My feet skid and tumble, desperate to grip anything and clutching down at it when I do.";
		ambientContainer.Add (race3);

		ambientInst race4 = new ambientInst ();
		race4.id = 4;
		race4.response = "";
		race4.thoughtsSpeed = 0.01f;
		race4.thoughts = "Ceara’s got her hand above me and I step up, trying to grab above it, but she manages to move a little, sees me coming and slides her hand up, blocking my fingers from reaching the tree. With a smile she steps up and hurls herself further upward while I have to reset my grip, almost falling over in sheer surprise.";
		ambientContainer.Add (race4);
		
		ambientInst raceExit = new ambientInst ();
		raceExit.id = 5;
		raceExit.disengage = true;
		raceExit.NextTrigger("raceChoice",true);
		ambientContainer.Add (raceExit);
		
		allAmbients.Add ("race", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region pullAmbient
		ambientInst pull = new ambientInst ();
		pull.id = 0;
		pull.response = "";
		pull.thoughts = "God, I already feel guilty about doing this before I’ve done it. But there was no stopping my hand now. I made that decision.    ¤I slid up and grabbed her ankle, and used it to pull myself up, latching my feet in the tree and expecting her to fall down quickly.";
		ambientContainer.Add (pull);

		ambientInst pull1 = new ambientInst ();
		pull1.id = 1;
		pull1.response = "";
		pull1.thoughts = "But she didn’t. She kept holding, on with one hand, while I let go, no longer letting myself hold her out of some unplaced guilt. I took another step up, placing my right foot firmly on a good branch and pushed. I realized that while she hadn’t fallen, she had stopped moving. I could reach up to the next branch and practically be beside her.";
		ambientContainer.Add (pull1);

		ambientInst pull2 = new ambientInst ();
		pull2.id = 2;
		pull2.response = "";
		pull2.thoughts = "She was done waiting though. With a grunt, she lashed herself upwards, going over me, but she hurried too much and misstepped her foot, making it swing in the air where she was expecting it to land on a branch. This caused her to keel sideways, and with one hand desperately cling onto a lone branch she couldn’t keep holding. I gasped at her, waiting for something to happen.";
		ambientContainer.Add (pull2);

		ambientInst pull3 = new ambientInst ();
		pull3.id = 3;
		pull3.response = "";
		pull3.thoughts = "Then she let go. It didn’t take more than a second. But, she had to let go, her fingers couldn’t take it anymore, and she fell to the ground.";
		ambientContainer.Add (pull3);

		ambientInst pull4 = new ambientInst ();
		pull4.id = 4;
		pull4.response = "";
		pull4.thoughts = "I… Went started climbing down to her after a short while. She wasn’t far away, and it hadn’t been a long fall, but she kept laying there.     ¤‘Ceara?’ I said, looking down at her still body. I hadn’t judged the fall to be that hard.      ¤I slid down the tree as fast as I could, gliding with my feet over the rough surface, hearing it crunch under me.";
		ambientContainer.Add (pull4);

		ambientInst pull5 = new ambientInst ();
		pull5.id = 5;
		pull5.response = "";
		pull5.thoughts = "I approached her slowly.   ¤‘Are you okay?";
		ambientContainer.Add (pull5);

		ambientInst pullEx = new ambientInst ();
		pullEx.id = 6;
		pullEx.disengage = true;
		pullEx.NextTrigger("cCursed",true);
		ambientContainer.Add (pullEx);
		
		allAmbients.Add ("pullAmbient", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region cursedGoBackToInn
		ambientInst cursedGoBackToInn = new ambientInst ();
		cursedGoBackToInn.id = 0;
		cursedGoBackToInn.response = "";
		cursedGoBackToInn.thoughts = "As she began moving I got a glance around us. It wasn’t just the flowerpetals right where she had landed. All around the pond, in small, hollow patches of purple, crossed across the plant, as if the rain had left purple marks where it landed.";
		ambientContainer.Add (cursedGoBackToInn);

		ambientInst cursedGoBackToInn1 = new ambientInst ();
		cursedGoBackToInn1.id = 1;
		cursedGoBackToInn1.response = "";
		cursedGoBackToInn1.thoughts = "We walked back slowly. She could walk fine, except she was walking slowly, and carefully feeling around her body as if it was dangerous to touch. Imagine that, I thought, being afraid of touching your own body.      ¤I asked her several more times if she was okay, but she kept saying nothing else. I couldn’t figure out how to ask anything else.";
		ambientContainer.Add (cursedGoBackToInn1);

		ambientInst cursedGoBackToInn2 = new ambientInst ();
		cursedGoBackToInn2.id = 2;
		cursedGoBackToInn2.response = "";
		cursedGoBackToInn2.thoughts = "The clouds were moving funny above us. They twirled and had an odd quality about them. They were too thin, or too fickle.";
		ambientContainer.Add (cursedGoBackToInn2);

		ambientInst cursedGoBackToInn3 = new ambientInst ();
		cursedGoBackToInn3.id = 3;
		cursedGoBackToInn3.response = "";
		cursedGoBackToInn3.thoughts = "When we came back at the inn, nothing had changed. The entire village was still crammed inside the inn, listening to the words of a stranger. Still, there was no way around it. She needed help. She didn’t even argue against it. Just waited for me to touch the door, afraid to come into contact with anything.";
		ambientContainer.Add (cursedGoBackToInn3);

		ambientInst cursedGoBackToInn4 = new ambientInst ();
		cursedGoBackToInn4.id = 4;
		cursedGoBackToInn4.response = "Help! <I shouted when we got in.> She needs help! Ceara's got something!";
		cursedGoBackToInn4.thoughts = "At the mention of Ceara’s name people started paying attention. I didn’t even notice what the Sage was talking about before I started yelling; that didn’t matter.         ¤The first to come running was Ceara’s mom, and the rest gave us a birth as we entered, quickly seeing the oddness of Ceara’s skin.";
		cursedGoBackToInn4.thoughtsDelay = 1.5f;
		ambientContainer.Add (cursedGoBackToInn4);

		ambientInst cursedGoBackToInn5 = new ambientInst ();
		cursedGoBackToInn5.id = 5;
		cursedGoBackToInn5.response = "What happened? <she demanded as she got close. Not waiting for an answer she came close to embrace her daughter.>DON’T <Ceara yelled and flung herself backwards, leaving a mother with the most startled expression I have ever seen.>";
		cursedGoBackToInn5.thoughts = "The rest of the inn were now watching, most passively, with wide, horrified eyes as the girl who had come in with skin that looked… wrong.";
		cursedGoBackToInn5.thoughtsDelay = 4f;
		ambientContainer.Add (cursedGoBackToInn5);
		
		ambientInst cursedGoBackToInnExit = new ambientInst ();
		cursedGoBackToInnExit.id = 5;
		cursedGoBackToInnExit.disengage = true;
		pullEx.NextTrigger("innCurseIntro",true);
		ambientContainer.Add (pullEx);
		
		allAmbients.Add ("cursedGoBackToInn", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion


	}

}
