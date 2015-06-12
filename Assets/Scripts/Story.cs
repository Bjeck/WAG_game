using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
	public static Story instance { get; private set; }

	public bool hasTalkedToMomIntro;
	public bool wentToVillageMorning;
	public bool hastalkedToCeara;
	public bool wentToInn;
	public bool talkedToIllijInInn;
	public bool racedTree;
	public bool wentBackToInn;

	public string StartDial;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void OnCanvasChange(Canvas c){
		if(c==canvasManager.instance.houseCanvas){ //IF HOUSE
			if(!hasTalkedToMomIntro){
				canvasManager.instance.ActivateDialogueButton(c,"momIntro", "Talk to Mom");
				return;
			}
		}

		if(c==canvasManager.instance.villageCanvas){ //IF VILLAGE
			if(!wentToVillageMorning){
				dialogueManager.instance.EnterAmbient("firstVillage",null);
				return;
			}
		}
	}


	public void OnExitDialogue(Canvas c){
		if (c == racedTree && !wentBackToInn) {
			Debug.Log("race over");
			if(MC.instance.CearaCursed){
				//TRIGGER PULL DIAL
				Debug.Log("pulling");
				dialogueManager.instance.EnterAmbient("pullAmbient",null);
			}
			else{
				Debug.Log("not pulling");
				dialogueManager.instance.EnterAmbient("nonPullAmbient",null);
			}
			return;
		}
		if(c==canvasManager.instance.villageCanvas && wentToInn && !talkedToIllijInInn){
			Debug.Log("illijIntro");
			dialogueManager.instance.EnterDialogue("IllijIntro",null);
			talkedToIllijInInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && hastalkedToCeara && !wentToInn){
			dialogueManager.instance.EnterAmbient("innIntro",null);
			wentToInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && !hastalkedToCeara){
			canvasManager.instance.ActivateDialogueButton(c,"cearaIntro", "Say hi to Ceara");
			return;
		}

	}

	public void OnDialogueTrigger(string dial, int pos){
		Debug.Log ("ON DIALOGUE TRIGGER "+dial+" "+pos);
		if (dial == "cearaIntro" && pos == 17) {
			hastalkedToCeara = true;
		}
		if(dial == "raceChoice" && pos == 0){
			racedTree = true;
		}
		if(dial == "raceChoice" && pos == 1){
			MC.instance.CearaCursed = true;
		}
		if(dial == "pullAmbient" && pos == 5){
			wentBackToInn = true;
		}
		if (dial == "innCurseIntro" && pos == 12) {
			MC.instance.toldAboutSmell = true;
		}
	}

}
