using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DialogueInst : MonoBehaviour {

	public int id;
	public List<string> options = new List<string>();
	public string response;
	public string thoughts;
	public List<int> ResponseNrs = new List<int> ();
	public bool disengage = false;
	public float optionDelay = 0;
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


		//MOMINTRO
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
		//dialogueManager.instance.dialNames.Add ("momIntro","momIntro");

	}


	public List<string> GetOptions(string s,int c){

		Debug.Log(s+" "+allDialogues.Count+" "+c+" "+allDialogues[s][c].options.Count);
		return allDialogues[s][c].options;

	}

}
