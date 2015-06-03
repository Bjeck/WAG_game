using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class dialogueProgression : MonoBehaviour {

	public GameObject dialogueOptionsPrefab;
	public dialogueOptionContainerScript dialogueOptionsFull;

	GameObject curDialogueOptions;

	public string dialName;
	public DialogueInst curInst;
 	dialogueManager dialMan;

	public List<Button> buttonList = new List<Button>();


	// Use this for initialization
	void Start () {
		dialMan = dialogueManager.instance;
		TriggerNextInstance ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TriggerNextInstance(){

		curInst = dialogueOptionContainerScript.instance.allDialogues [dialName].Find (x => x.id == dialogueManager.instance.dialoguePosition);

		dialMan.response = Instantiate (dialMan.responsePrefab,dialMan.responsePos.transform.position,dialMan.responsePos.transform.rotation) as GameObject;
		dialMan.thoughts = Instantiate (dialMan.thoughtsPrefab,dialMan.thoughtsPos.transform.position,dialMan.thoughtsPos.transform.rotation) as GameObject;
		
		dialMan.response.transform.parent = dialMan.responsePos.transform;
		dialMan.thoughts.transform.parent = dialMan.thoughtsPos.transform;
		dialMan.response.GetComponent<RectTransform> ().localScale = Vector3.one;
		dialMan.thoughts.GetComponent<RectTransform> ().localScale = Vector3.one;
		
		dialMan.response.GetComponent<textRoll> ().textToDisplay = curInst.response;
		dialMan.thoughts.GetComponent<textRoll> ().textToDisplay = curInst.thoughts;

		StartCoroutine (SpawnButtons(curInst.optionDelay));


	}


	IEnumerator SpawnButtons(float t){
		while (t > 0) {
			t -= Time.deltaTime;
			yield return 0;
		}

		curDialogueOptions = Instantiate (dialogueOptionsPrefab,this.transform.position,this.transform.rotation) as GameObject;
		
		curDialogueOptions.transform.parent = dialogueManager.instance.dialogueCanvas.transform;
		curDialogueOptions.GetComponent<RectTransform> ().localScale = Vector3.one;
		curDialogueOptions.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3(-115,150,0);
		
		
		List<Button> buttonList = new List<Button> ();
		buttonList.AddRange (curDialogueOptions.GetComponentsInChildren<Button> ()); 
		
		//Remove uneeded buttons.
		if (buttonList.Count > curInst.options.Count) {
			for(int j=0;j<4-curInst.options.Count;j++){
				Destroy(buttonList[j].gameObject);
			}
			buttonList.RemoveRange(0,4-curInst.options.Count);
			
		}
		
		
		string[] stringList = curInst.options.ToArray();
		
		int i = 0;
		foreach (Button b in buttonList) {
			buttonList[i].GetComponentInChildren<Text>().text = stringList[i];
			buttonList[i].name = curInst.ResponseNrs[i].ToString();
			i++;
		}
	}








}
