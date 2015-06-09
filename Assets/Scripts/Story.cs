using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
	public static Story instance { get; private set; }

	public bool hasTalkedToMomIntro;
	public bool wentToVillageMorning;
	public bool hastalkedToCeara;
	public bool wentToInn;
	public bool talkedToIllijInInn;

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
		if(c==canvasManager.instance.villageCanvas && !hastalkedToCeara){
			canvasManager.instance.ActivateDialogueButton(c,"cearaIntro", "Say hi to Ceara");
			return;
		}
		if(c==canvasManager.instance.villageCanvas && hastalkedToCeara && !wentToInn){
			dialogueManager.instance.EnterAmbient("innIntro",null);
			wentToInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && wentToInn && !talkedToIllijInInn){
			Debug.Log("illijIntro");
			dialogueManager.instance.EnterDialogue("IllijIntro",null);
			talkedToIllijInInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && talkedToIllijInInn){
			dialogueManager.instance.EnterAmbient("sageIntro",null);
			return;
		}
	}

	public void OnDialogueTrigger(string dial, int pos){
		if (dial == "cearaIntro" && pos == 17) {
			hastalkedToCeara = true;
		}
	}

}
