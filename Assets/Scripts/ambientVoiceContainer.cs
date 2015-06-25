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
		firstVillage2.response = "'Well, I better go tell Rasmin.¤'And I gotta prepare. See you at the inn.'";
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
		innIntro1.thoughts = "There's already a crowd gathering in the inn.  ¤Nearly half the village is here, talking loudly about wild rumours, misinforming, and just generally enjoying themselves. ";
		ambientContainer.Add (innIntro1);

		ambientInst innIntro2 = new ambientInst ();
		innIntro2.id = 1;
		innIntro2.response = "\'Come to see the show?\' <he asks.>";
		innIntro2.ambDelay = 4.5f;
		innIntro2.thoughts = "Me and Ceara scout around for Illij, and spot him by a corner table sitting alone as he usually does. ¤We approach lightly, sitting down next to him, before he even notices us.";
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
		sageIntro2.thoughts = "Murmur erupts and dies immediately as more people enter the inn, followed lastly by someone I don't know.";
		ambientContainer.Add (sageIntro2);

		ambientInst sageIntr3 = new ambientInst ();
		sageIntr3.id = 2;
		sageIntr3.response = "";
		sageIntr3.thoughts = "He's tall, dark skin but lighter than Illij's, as if it was a mix of the two.  ¤His clothes are strange, red and brown, with green lines running down in a foreign pattern, mostly on his arms and chest, criss-crossing each other in a design that must have taken forever to sew.   ¤He walks in and looks around, everyone else staring up at him as if he's their long lost child who came home after war .";
		ambientContainer.Add (sageIntr3);

		ambientInst sageIntr4 = new ambientInst ();
		sageIntr4.id = 3;
		sageIntr4.response = "'Hello' <he says. He crooks a smile.>";
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
		sageIntr6.response = "'I can see you all have questions. I will take my time to answer them, don't you worry. But first, I'll need a drink. It's been a long journey.'";
		sageIntr6.thoughts = "The people seem to eagerly await his every move, but Deidre (the innkeep) instinctually sets into motion at the order of a drink. This loosens up the crowd, and the murmur begins anew, although this time it's harder to hear what they're saying. Guess they don't want the guest to hear, either.";
		ambientContainer.Add (sageIntr6);
		
		ambientInst sageIntr7 = new ambientInst ();
		sageIntr7.id = 6;
		sageIntr7.response = "";
		sageIntr7.thoughts = "The Sage waltzes into the room and immediately people around him start asking questions he answers in the most leasurely way possible.";
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
		pondInt.response = "<Ceara lets out a long sigh.>  ¤'Damn it was hot in there'    ¤'Yeah' <I say.>";
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
		race.thoughts = "We both start sprinting before she said anything else. We’re on the south side of the pond, and the trees to the north. We sprint to the left of the shallow water, and I faintly notice movement under the surface.";
		ambientContainer.Add (race);

		ambientInst race1 = new ambientInst ();
		race1.id = 1;
		race1.response = "";
		race1.thoughtsSpeed = 0.01f;
		race1.thoughts = "My feet feel light and springy on the summer grass, the smell of the waving flowers seething into my nostrils. We’re sidestepping toe to toe, whistling across the pond-side almost soundlessly, as we hear the wind clatter at our ears.";
		ambientContainer.Add (race1);

		ambientInst race2 = new ambientInst ();
		race2.id = 2;
		race2.response = "";
		race2.thoughtsSpeed = 0.01f;
		race2.thoughts = "She had a slight head start, so while I would consider myself faster, she gets her first foot up on the tree. Oddly coloured flowers pique my interest for a thin moment, but I pull myself up, clawing my bare feet into the slitful bark. I can feel my feet pinch a little, almost feel pain, but I pull myself up and latch onto a branch on top of me.";
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
		pull5.thoughts = "<I approached her slowly.>   ¤Are you okay?";
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
		cursedGoBackToInn4.thoughts = "At the mention of Ceara’s name people started paying attention. I didn’t even notice what the Sage was talking about before I started yelling; that didn’t matter.         ¤The first to come running was Ceara’s mom, and the rest gave us a berth as we entered, quickly seeing the oddness of Ceara’s skin.";
		cursedGoBackToInn4.thoughtsDelay = 1.5f;
		ambientContainer.Add (cursedGoBackToInn4);

		ambientInst cursedGoBackToInn5 = new ambientInst ();
		cursedGoBackToInn5.id = 5;
		cursedGoBackToInn5.response = "Are you alright? <she demanded as she got close. Not waiting for an answer she came close to embrace her daughter.> ¤DON’T <Ceara yelled and flung herself backwards, leaving a mother with the most startled expression I have ever seen.>";
		cursedGoBackToInn5.thoughts = "The rest of the inn were now watching, most passively, with wide, horrified eyes as the girl who had come in with skin that looked… wrong.";
		cursedGoBackToInn5.thoughtsDelay = 4f;
		ambientContainer.Add (cursedGoBackToInn5);
		
		ambientInst cursedGoBackToInnExit = new ambientInst ();
		cursedGoBackToInnExit.id = 6;
		cursedGoBackToInnExit.disengage = true;
		cursedGoBackToInnExit.NextTrigger("innCurseIntro",true);
		ambientContainer.Add (cursedGoBackToInnExit);
		
		allAmbients.Add ("cursedGoBackToInn", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region outsideInn
		List<ambientInst> outsideInnList = new List<ambientInst> ();
		outsideInnList.Add(new ambientInst());
		outsideInnList [0].id = 0;
		outsideInnList [0].response = "";
		outsideInnList [0].thoughts = "I led them outside, the Sage right behind me, and Ceara following carefully, making sure not to touch anyone.    ¤I began walking towards the pond, almost half the village in tow when I looked at the grass.";
		ambientContainer.Add (outsideInnList [0]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [1].id = 1;
		outsideInnList [1].response = "";
		outsideInnList [1].thoughts = "It was spreading up from the pond. Moving with the flowers. I hadn’t noticed it before, so it must have been moving fast. Really fast. I stared, horrified at the new color the tiny pathway had gotten, once leading down to the pond with small tufts of yellow flowers along neatly downtrodden grass.";
		ambientContainer.Add (outsideInnList [1]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [2].id = 2;
		outsideInnList [2].response = "What the hell…      ¤Was this here before? <the Sage asked, getting a worried expression.>     ¤No <I say.>";
		outsideInnList [2].thoughts = "Now, it was covered in purple-green, striped splashes in uneven patterns that made everything worse.";
		outsideInnList [2].ambDelay = 1.5f;
		ambientContainer.Add (outsideInnList [2]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [3].id = 3;
		outsideInnList [3].response = "Shit. That’s not good.  ¤<He turned around and looked at Ceara again.>   ¤How are you feeling?   ¤Fine, she said again.";
		outsideInnList [3].thoughts = "I didn’t know what to do.";
		outsideInnList [3].thoughtsDelay = 1.5f;
		ambientContainer.Add (outsideInnList [3]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [4].id = 4;
		outsideInnList [4].response = "What is it? Can you fix it? <The mother asked.>";
		outsideInnList [4].thoughts = "He didn’t respond for some time, all of us staring at him in incredulity, afraid to go forward and unwilling to go back.";
		outsideInnList [4].thoughtsDelay = 1.0f;
		ambientContainer.Add (outsideInnList [4]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [5].id = 5;
		outsideInnList [5].response = "It looks like an infestation, a spread of a disease. Never seen something like this spread this fast, though. Nor go from plants to humans.   ¤<He paused again.>      ¤Okay, listen. I’m going to need some equipment. Don’t have anything here, because I didn’t expect to solve a curse here, but I can investigate the nature of this. Unfortunately, I might have to go to Caudden to get specific help.";
		outsideInnList [5].thoughts = "";
		outsideInnList [5].thoughtsDelay = 1.0f;
		ambientContainer.Add (outsideInnList [5]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [6].id = 6;
		outsideInnList [6].response = "With all respect, sir, doesn’t look like we have that kind of time, if it spreads that fast.";
		outsideInnList [6].thoughts = "It was moving closer. It was hard to see the actual movement, but it now touched some plants it did not before. I’m sure of it.";
		ambientContainer.Add (outsideInnList [6]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [7].id = 7;
		outsideInnList [7].response = "What do you need? <Ceara asks.> ¤A compass, fire, bones of a dead animal, preferably a mouse or cat, something made of iron, a casket or pan or something, and a sample of a flower with the infection on it.";
		outsideInnList [7].thoughts = "We looked around at each other, considering the list of ingredients.";
		outsideInnList [7].thoughtsDelay = 3f;
		ambientContainer.Add (outsideInnList [7]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [8].id = 8;
		outsideInnList [8].response = "I can get the flower <Ceara said.> I’m already touched, right? What does it matter if I touch it again?  ¤<The Sage nodded.> Still, I would get some gloves.  ¤She nodded and started moving.";
		outsideInnList [8].thoughts = "I was surprised at how calm Ceara took this. There was almost no hesitation, no fear in her voice.";
		outsideInnList [8].thoughtsDelay = 3f;
		ambientContainer.Add (outsideInnList [8]);

		outsideInnList.Add(new ambientInst());
		outsideInnList [9].id = 9;
		outsideInnList [9].response = "<Ceara’s mother began looking at the others.> We need a fire! Anyone’s got a dead animal perchance? Or something we can slaughter?";
		outsideInnList [9].thoughts = "Several voices rose up, started yelling at each other in a frantic language I could only understand if I paid close attention to one of the sounds—the rest were drowning out as noise in a [REDACTED].";
		outsideInnList [9].thoughtsDelay = 1f;
		ambientContainer.Add (outsideInnList [9]);

		outsideInnList.Add (new ambientInst ());
		outsideInnList [10].id = 10;
		outsideInnList [10].disengage = true;
		outsideInnList [10].NextTrigger("innCurseIntro",true);
		ambientContainer.Add (outsideInnList[10]);
		
		allAmbients.Add ("outsideInn", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region cearaRitIntro
		ambientInst cearaRitIntro = new ambientInst ();
		cearaRitIntro.id = 0;
		cearaRitIntro.response = "";
		cearaRitIntro.thoughts = "We returned with the plant to see the rest of the village in disarray. Some were by the roadside, building a small fire, many were standing around in various clumps not doing anything, and two people were crying. The Sage wasn’t there.";
		ambientContainer.Add (cearaRitIntro);

		ambientInst cearaRitIntro1 = new ambientInst ();
		cearaRitIntro1.id = 1;
		cearaRitIntro1.response = "Ceara! <Mauge says, rushing to her daughter> Did you get the plant?   ¤Yeah. What’s happening? Did you finish?";
		cearaRitIntro1.thoughts = "The looks of the others said enough. Some glanced up, shaking their head, rustled their feet, crossed their arms, but no one came to help. No one came to ask her if she was okay. Mikal’s wife Perna, who was crying, was watching some of the others hold a dead cat, throat slit.     ¤Oh.";
		ambientContainer.Add (cearaRitIntro1);

		ambientInst cearaRitIntro2 = new ambientInst ();
		cearaRitIntro2.id = 2;
		cearaRitIntro2.response = "";
		cearaRitIntro2.thoughts = "";
		ambientContainer.Add (cearaRitIntro2);

		ambientInst cearaRitIntro3 = new ambientInst ();
		cearaRitIntro3.id = 3;
		cearaRitIntro3.response = "Do we have everything? <Ceara still doesn’t accept that. I can understand her perfectly well.>  ¤Yeah, we got everything. <Ceara looks back at Perna> You had to— ¤Yes! We had to. Look at it. <She points towards the pond. There is no reason to go down to see the purple anymore. It is close enough that it would hit the first houses soon enough.>";
		cearaRitIntro3.thoughts = "I look at Ceara. She seems worried. There is something she isn’t telling us.";
		ambientContainer.Add (cearaRitIntro3);

		ambientInst cearaRitIntroExit = new ambientInst ();
		cearaRitIntroExit.id = 4;
		cearaRitIntroExit.disengage = true;
		cearaRitIntroExit.NextTrigger("ritual",false);
		ambientContainer.Add (cearaRitIntroExit);
		
		allAmbients.Add ("cearaRitIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region stayRitIntro
		ambientInst stayRitIntrow = new ambientInst ();
		stayRitIntrow.id = 0;
		stayRitIntrow.response = "";
		stayRitIntrow.thoughts = "The atmosphere was weird when they left. The Sage wasn’t back either. Ceara was gone, Mauge was gone. Tripping, I was anxious, staring back the way Ceara left, wondering if I should have gone after her. Peopl glare with trepidation to the south, at the purple mess that is slowly moving closer. Maybe some of them are considering if they should run. I wouldn’t blame them.";
		ambientContainer.Add (stayRitIntrow);

		ambientInst stayRitIntrow1 = new ambientInst ();
		stayRitIntrow1.id = 1;
		stayRitIntrow1.response = "Illij comes back with a compass and holds it while he looks around, waiting with the rest of us.";
		stayRitIntrow1.thoughts = "";
		ambientContainer.Add (stayRitIntrow1);

		ambientInst stayRitIntrow2 = new ambientInst ();
		stayRitIntrow2.id = 2;
		stayRitIntrow2.response = "Perna comes with with a dead cat, crying, with Mikal supporting her as they walk. Damn, that hurts more than I expected to. They slit its throat, clean, but with blood running down Perna’s arms.";
		stayRitIntrow2.thoughts = "Shit...";
		ambientContainer.Add (stayRitIntrow2);

		ambientInst stayRitIntro = new ambientInst ();
		stayRitIntro.id = 4;
		stayRitIntro.response = "Hey Tari.  ¤Are you okay? <I settle with.>";
		stayRitIntro.thoughts = "Ceara returns with a plant in her hand shortly after. I go over to her and thought of fifteen things to say but none of them fit.>";
		stayRitIntro.ambDelay = 3f;
		ambientContainer.Add (stayRitIntro);

		ambientInst stayRitIntro1 = new ambientInst ();
		stayRitIntro1.id = 5;
		stayRitIntro1.response = "Ceara! <Mauge says before I get an answer, pan in hand> Did you get the plant?  ¤Yeah. What’s happening? Did you get the rest?";
		stayRitIntro1.thoughts = "Ceara spots Perna and Mikal and her face becomes stern, but she doesn’t say anything. No one answers her.";
		ambientContainer.Add (stayRitIntro1);

		ambientInst stayRitIntro2 = new ambientInst ();
		stayRitIntro2.id = 6;
		stayRitIntro2.response = "Do we have everything? <She repeats.>  ¤Yeah, we got everything. <Ceara looks at Perna> You had to— ¤Yes! We had to. Look at it. <She points towards the pond. There is no reason to go down to see the purple anymore. It is close enough that it would hit the first houses soon enough.>";
		stayRitIntro2.thoughts = "";
		ambientContainer.Add (stayRitIntro2);

		ambientInst stayRitIntroEx = new ambientInst ();
		stayRitIntroEx.id = 7;
		stayRitIntroEx.disengage = true;
		stayRitIntroEx.NextTrigger("ritual",false);
		ambientContainer.Add (stayRitIntroEx);
		
		allAmbients.Add ("stayRitIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region ritual
		ambientInst rit = new ambientInst ();
		rit.id = 0;
		rit.response = "";
		rit.thoughts = "";
		ambientContainer.Add (rit);

		ambientInst rit1 = new ambientInst ();
		rit1.id = 1;
		rit1.response = "Is everything ready? Come here with the plant. <he says> ";
		rit1.thoughts = "We hear rustling footsteps coming from the inn again. It’s the Sage, looking at us with morbid eyes. ";
		rit1.ambDelay = 2f;
		ambientContainer.Add (rit1);

		ambientInst rit2 = new ambientInst ();
		rit2.id = 2;
		rit2.response = "";
		rit2.thoughts = "Mauge wretches the dead cat out of the hands of Mikal and leads Ceara there too. Illij steps up with a compass and Trenner gives him an iron pan. The Sage nods to himself as he sees the items, and bends down by the fire.";
		ambientContainer.Add (rit2);

		ambientInst rit3 = new ambientInst ();
		rit3.id = 3;
		rit3.response = "";
		rit3.thoughts = "It takes a long time before anything happens. He works there, in the middle of the road, where we had slapdashed a fire together, and the rest of us stands around in small circles, looking at the strange clouds and the purple get closer and closer. None of us panic. We don’t know if we need to. We don’t understand what’s happening.";
		ambientContainer.Add (rit3);

		ambientInst rit4 = new ambientInst ();
		rit4.id = 4;
		rit4.response = "";
		rit4.thoughts = "I lean over to Ceara, but before I say anything I notice how she’s standing. One leg limp and not using any force, the other completely straight and leaning against the wall. None of her hands touch the wall. She’s just leaning with her shoulder, her arms a dead limp.";
		ambientContainer.Add (rit4);

		ambientInst rit5 = new ambientInst ();
		rit5.id = 5;
		rit5.response = "Shit, are you okay? <I ask.>    ¤<She doesn’t respond.> ¤Gods, are you… Ceara!";
		rit5.thoughts = "I lean in close to see her face, but she’s... Her eyes are sheets of white, her face more covered up the last time than the last time I saw it—reminding me she was hiding her face on the way back here.";
		ambientContainer.Add (rit5);

		ambientInst rit6 = new ambientInst ();
		rit6.id = 6;
		rit6.response = "Mauge! <I scream, but then I hear muffled sounds.>   ¤No, no… it’s.. I’m…  ¤<but she never finishes that sentence before Mauge gets here.> ¤Oh, gods <she says and raises her hands to her mouth.> Sage! Please! She’s gotten worse!";
		rit6.thoughts = "Worse doesn’t even describe it. Mauge cracks into tears as she speaks, Ceara barely answers.";
		rit6.thoughtsDelay = 5f;
		ambientContainer.Add (rit6);

		ambientInst rit7 = new ambientInst ();
		rit7.id = 7;
		rit7.response = "<The Sage looks at her and furrows his brow immediately.>   ¤Can she get over here?   ¤Can you walk? <Me and Mauge both say, in both our ways>, and Ceara starts shuffling along.>";
		rit7.thoughts = "I almost instinctually lean in to help her but remember myself and stop. Seeing her like this makes me doubly careful.";
		ambientContainer.Add (rit7);

		ambientInst rit8 = new ambientInst ();
		rit8.id = 8;
		rit8.response = "";
		rit8.thoughts = "Ceara scrapes herself by, the entire village watching in fear as they realize what happened to her—how real it is. Most of them glance down south one extra time, whispering to each other. I glance down there too, checking my legs and arms one extra time for any purple marks.";
		ambientContainer.Add (rit8);

		ambientInst rit9 = new ambientInst ();
		rit9.id = 9;
		rit9.response = "<She collapses in front of the Sage, right beside his fire and he immediately use a small duster to roll the plant beside him.>  ¤How are you? Is there a fever? Do you feel numb? Like you’re about to fall asleep?  ¤<Ceara doesn’t even have time to answer all the questions. And the Sage doesn’t wait either.>";
		rit9.thoughts = "";
		ambientContainer.Add (rit);

		ambientInst rit10 = new ambientInst ();
		rit10.id = 10;
		rit10.response = "";
		rit10.thoughts = "He takes the bones and, lays them in the pan, then begins grinding them out, as if in a mortar and pestle. He lays the compass beside, seeing it bend nicely towards the pan as he does. When most of the pan is covered in a layer of bone dust, he picks up the plants and grinds that in with the rest. While he sets the pan on the fire he pulls something from out of his pouch I don’t quite see what is, but looks like small yellow flakes, that he pours on top as well.";
		ambientContainer.Add (rit10);

		ambientInst rit11 = new ambientInst ();
		rit11.id = 11;
		rit11.response = "It’s… <the Sage says.> But no? It’s… <he pauses again.>";
		rit11.thoughtsDelay = 1.5f;
		rit11.thoughts = "The entire village is watching in tension. The wind is blowing heavily, more heavily than it did a minute ago.";
		ambientContainer.Add (rit11);

		ambientInst rit12 = new ambientInst ();
		rit12.id = 12;
		rit12.response = "Shit <he says.>";
		rit12.thoughts = "That’s all. That’s all he says for a long time.    ¤The compass arrow is running amok, pointing everywhere every second it can.";
		rit12.thoughtsDelay = 1.5f;
		ambientContainer.Add (rit12);

		ambientInst rit13 = new ambientInst ();
		rit13.id = 13;
		rit13.response = "What is it? Can you cure her?   ¤<The Sage looks up, as if from a long slumber.> Only tend her. I can’t cure her completely. This is something I have never seen before. They might help us in Caudden, if it’s not there already, considering it spread from that direction. Whatever it is, it’s bad. Really bad.";
		rit13.thoughts = "";
		ambientContainer.Add (rit13);

		ambientInst rit14 = new ambientInst ();
		rit14.id = 14;
		rit14.response = "...";
		rit14.thoughtsDelay = 1.5f;
		rit14.thoughts = "It takes a long time before anyone does anything. It feels like an hour. It looks like an eternity.                ¤¤Then it’s as if everyone starts shouting at once.";
		ambientContainer.Add (rit14);

		ambientInst rit15 = new ambientInst ();
		rit15.id = 15;
		rit15.responseSpeed = 0.005f;
		rit15.response = "What do we do? ¤Do we have to run? Where can we go? ¤Is it over? What about Ceara? ¤I can’t leave here! It’s my home.";
		rit15.thoughts = "Ceara looks terrible. She lies down beside the fire, as if with a fever, but all stricken across her face in that purple, dreadful color. The streaks of green are starting to show more clearly.    ¤Panic takes over. The Sage barely has time to respond to anything. The infestation or whatever the fuck it is, is really, really close now. We’re running out of options here.";
		ambientContainer.Add (rit15);

		ambientInst rit16 = new ambientInst ();
		rit16.id = 16;
		rit16.response = "We need to get to Caudden <the Sage says> there they might have a cure.  ¤Caudden?! <Mauge says> They’ll never take us in in Caudden. We’re shut out, like we always are. And what if it’s in there too, as you said?  ¤We have to take that chance.";
		rit16.thoughts = "I feel a rumbling in my stomach, some low, crunching feeling that something’s wrong. Of course it is, I think, our entire village is about to be consumed by some weird purple shit that’s killing Ceara, but there’s something else too. A worry that this goes  [REDACTED].";
		ambientContainer.Add (rit16);

		ambientInst rit17 = new ambientInst ();
		rit17.id = 17;
		rit17.response = "Nevermind <Mauge says> we’re bloody leaving now. Come on, Ceara, let’s get out of here.  ¤<She rushes towards Ceara and bends down to pick her up> No, don’t! <the Sage says, but Mauge isn’t listening>.";
		rit17.thoughts = "Mauge’s skin turns purple immediately, but she picks her child up and carries her. She starts crying as soon as she steps away from the fire, looking down at her daughter. ";
		ambientContainer.Add (rit17);

		ambientInst rit18 = new ambientInst ();
		rit18.id = 18;
		rit18.response = "Her skin is… soft <she says.>";
		rit18.thoughts = "Her skin transforms, begins to look like the purple mush that Ceara has as well.    ¤¤People are running now. In all directions, home to their houses, shutting themselves in or running to the stables to grab a horse, or just running north, into the forest.";
		ambientContainer.Add (rit18);

		ambientInst rit19 = new ambientInst ();
		rit19.id = 19;
		rit19.response = "";
		rit19.thoughts = "Mauge tries to run as well, but with Ceara in her arms, she can only stumble along, her body already giving way to the stuff, as she clearly can’t rest on her left leg either. I almost begin to run as well, but stop.";
		ambientContainer.Add (rit19);

		ambientInst rit20 = new ambientInst ();
		rit20.id = 20;
		rit20.response = "";
		rit20.thoughts = "There it is. I notice it. The clouds aren’t just moving weird. They aren’t just picking up speed and circling unnaturally. They’re… close. And they’re tiny, so they look like they are as far away as usual. The entire village is enveloped in it, not really noticeable since it isn’t fog.  ¤[[Should it get dark?]]";
		ambientContainer.Add (rit20);

		ambientInst ritEx = new ambientInst ();
		ritEx.id = 21;
		ritEx.disengage = true;
		ritEx.NextTrigger("ritChoice",true);
		ambientContainer.Add (ritEx);
		
		allAmbients.Add ("ritual", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion


		#region goesToCaudden
		ambientInst goesToCaudden = new ambientInst ();
		goesToCaudden.id = 0;
		goesToCaudden.response = "";
		goesToCaudden.thoughts = "The Sage sets off but immediately as he starts walking I realize the infestation has caught up to us. It’s right there, on the grass beneath us, only about two feet away. He rushes to the right, and I go with him, running now, to get away from a thing we can’t see moving—only taking leaps to where we are.";
		ambientContainer.Add (goesToCaudden);

		ambientInst goesToCaudden1 = new ambientInst ();
		goesToCaudden1.id = 0;
		goesToCaudden1.response = "";
		goesToCaudden1.thoughts = "We run towards the stables, where he says he has a horse. I doubt it’s still there anymore.";
		ambientContainer.Add (goesToCaudden1);

		ambientInst goesToCauddenEx = new ambientInst ();
		goesToCauddenEx.id = 2;
		goesToCauddenEx.disengage = true;
		ambientContainer.Add (goesToCauddenEx);
		
		allAmbients.Add ("goesToCaudden", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

		#region goesNorth
		ambientInst goesNorth = new ambientInst ();
		goesNorth.id = 0;
		goesNorth.response = "";
		goesNorth.thoughts = "The Sage sets off but immediately as he starts walking I realize the infestation has caught up to us. It’s right there, on the grass beneath us, only about two feet away. He rushes to the right, and I run north, to get away from a thing we can’t see moving—only taking leaps to where we are.";
		ambientContainer.Add (goesNorth);
		
		ambientInst goesNorth1 = new ambientInst ();
		goesNorth1.id = 1;
		goesNorth1.response = "";
		goesNorth1.thoughts = "I don’t see where he goes but I just continue to run away, running away from the sun and everything I know.";
		ambientContainer.Add (goesNorth1);
		
		ambientInst goesNorthEx = new ambientInst ();
		goesNorthEx.id = 2;
		goesNorthEx.disengage = true;
		ambientContainer.Add (goesNorthEx);
		
		allAmbients.Add ("goesNorth", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion

	}

}
