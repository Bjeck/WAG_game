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

		#region villageIntro
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

		ambientInst exitSage = new ambientInst ();
		exitSage.id = 6;
		exitSage.disengage = true;
		ambientContainer.Add (exitSage);
		
		allAmbients.Add ("sageIntro", ambientContainer);
		ambientContainer = new List<ambientInst> ();
		#endregion


	}

}
