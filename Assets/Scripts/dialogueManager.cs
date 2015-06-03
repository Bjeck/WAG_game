using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class dialogueManager : MonoBehaviour {

	public static dialogueManager instance { get; private set; }

	public int dialoguePosition = 0;
	//public Dictionary<string,string> dialNames = new  Dictionary<string,string> ();

	public GameObject responsePrefab;
	public GameObject thoughtsPrefab;

	public GameObject response;
	public GameObject thoughts;

	public GameObject responsePos;
	public GameObject thoughtsPos;

	public GameObject dialogueCanvas;

	public GameObject CurDialogueObject;
	public GameObject DialoguePrefab;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void EnterDialogue(string dialName){
		CurDialogueObject = Instantiate (DialoguePrefab,this.transform.position,this.transform.rotation) as GameObject;
		CurDialogueObject.transform.parent = dialogueCanvas.transform;
		CurDialogueObject.GetComponent<dialogueProgression> ().dialName = dialName;
		canvasManager.instance.ChangeDialogueCanvas (true);
	}

	public void ExitDialogue(){
		Destroy (CurDialogueObject);
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);

		dialoguePosition = 0;


		canvasManager.instance.ChangeDialogueCanvas (false);
	}


	public void TriggerNextDialogue(GameObject but){
		Destroy (but.transform.parent.gameObject);
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);


		dialoguePosition = int.Parse (but.GetComponent<Button>().name);

		if (dialogueOptionContainerScript.instance.allDialogues [CurDialogueObject.GetComponent<dialogueProgression> ().dialName].Find (x => x.id == dialogueManager.instance.dialoguePosition).disengage == true) {
			//Disengage Dialogue
			ExitDialogue ();

		} else {
			CurDialogueObject.GetComponent<dialogueProgression> ().TriggerNextInstance ();
		}


	}


}
