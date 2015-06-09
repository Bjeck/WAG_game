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


	public GameObject ambientRePrefab;
	public GameObject ambientThPrefab;
	
	public GameObject ambientRePos;
	public GameObject ambientThPos;

	public GameObject CurAmbientObject;
	public GameObject AmbientPrefab;

	public GameObject ambientButton;

	public GameObject buttonThatActivatedThisDialogue;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void EnterDialogue(string dialName, GameObject b){
		CurDialogueObject = Instantiate (DialoguePrefab,this.transform.position,this.transform.rotation) as GameObject;
		CurDialogueObject.transform.parent = dialogueCanvas.transform;
		CurDialogueObject.GetComponent<dialogueProgression> ().dialName = dialName;
		canvasManager.instance.ChangeDialogueCanvas (true);
		buttonThatActivatedThisDialogue = b;
	}

	public void ExitDialogue(){
		Destroy (CurDialogueObject);
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);
		dialoguePosition = 0;
		canvasManager.instance.ChangeDialogueCanvas (false);
		if (buttonThatActivatedThisDialogue != null) {
			Destroy (buttonThatActivatedThisDialogue);
			buttonThatActivatedThisDialogue = null;
		}
		Story.instance.OnExitDialogue (canvasManager.instance.curCanvas);
	}


	public void TriggerNextDialogue(GameObject but){
		Destroy (but.transform.parent.gameObject);
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);

		dialoguePosition = int.Parse (but.GetComponent<Button>().name);
		Story.instance.OnDialogueTrigger (CurDialogueObject.GetComponent<dialogueProgression>().dialName,dialoguePosition);

		if (dialogueOptionContainerScript.instance.allDialogues [CurDialogueObject.GetComponent<dialogueProgression> ().dialName].Find (x => x.id == dialogueManager.instance.dialoguePosition).disengage == true) {
			ExitDialogue ();
		} else {
			CurDialogueObject.GetComponent<dialogueProgression> ().TriggerNextInstance ();
		}
	}



// AMBIENT

	public void EnterAmbient(string name, GameObject b){
		CurDialogueObject = Instantiate (AmbientPrefab,this.transform.position,this.transform.rotation) as GameObject;
		CurDialogueObject.transform.parent = dialogueCanvas.transform;
		CurDialogueObject.GetComponent<ambientProgression> ().ambientName = name;
		canvasManager.instance.ChangeDialogueCanvas (true);
		ambientButton.SetActive (true);
		buttonThatActivatedThisDialogue = b;
	}

	public void ExitAmbient(){
		Destroy (CurDialogueObject);
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);
		dialoguePosition = 0;
		canvasManager.instance.ChangeDialogueCanvas (false);
		ambientButton.SetActive (false);
		if (buttonThatActivatedThisDialogue != null) {
			Destroy (buttonThatActivatedThisDialogue);
			buttonThatActivatedThisDialogue = null;
		}
		Story.instance.OnExitDialogue (canvasManager.instance.curCanvas);
	}

	public void TriggerNextAmbient(){
		Destroy (response.gameObject);
		Destroy (thoughts.gameObject);

		dialoguePosition++;
		
		if (ambientVoiceContainer.instance.allAmbients [CurDialogueObject.GetComponent<ambientProgression> ().ambientName].Find (x => x.id == dialogueManager.instance.dialoguePosition).disengage == true) {
			//Disengage Dialogue
			ExitAmbient ();
			
		} else {
			CurDialogueObject.GetComponent<ambientProgression> ().TriggerNextInstance ();
		}
	}








}
