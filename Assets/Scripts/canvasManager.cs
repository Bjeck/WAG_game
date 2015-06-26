using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class canvasManager : MonoBehaviour {

	public static canvasManager instance { get; private set; }
	
	public Canvas houseCanvas;
	public Canvas villageCanvas;
	public Canvas dialogueCanvas;
	public Canvas bootCanvas;
	public Canvas overlayCanvas;
	List<Canvas> canvases = new List<Canvas> ();

	public Canvas curCanvas;
	GameObject enterDialogueButton;
	public GameObject EnterDialogueButtonPrefab;
	
	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);

	}

	// Use this for initialization
	void Start () {
		canvases.Add (houseCanvas);
		canvases.Add (villageCanvas);
		canvases.Add (dialogueCanvas);
		canvases.Add (bootCanvas);

		if (Story.instance.StartDial != "" && Story.instance.StartDial != null) {
			if (dialogueOptionContainerScript.instance.allDialogues.ContainsKey (Story.instance.StartDial)) {
				//ActivateCanvas (dialogueCanvas);
				dialogueManager.instance.EnterDialogue (Story.instance.StartDial, null);
			}
			if (ambientVoiceContainer.instance.allAmbients.ContainsKey (Story.instance.StartDial)) {
				//ActivateCanvas (dialogueCanvas);
				dialogueManager.instance.EnterAmbient (Story.instance.StartDial, null);
			}
		} else {
			ActivateCanvas (curCanvas);
		}
	
	}

	public void ActivateCanvas(Canvas c){
		c.gameObject.SetActive (true);
		foreach (Canvas p in canvases) {
			if(p!=c){
				p.gameObject.SetActive(false);
			}
		}
		curCanvas = c;
		if (enterDialogueButton != null) {
	//		Debug.Log (enterDialogueButton.name + " deactivate");
			Destroy (enterDialogueButton);
			enterDialogueButton = null;
		}
		Story.instance.OnCanvasChange (c);
	}

	public void DeactivateCanvas(Canvas c){

		c.gameObject.SetActive (false);
	}

	public void ChangeDialogueCanvas(bool f){
		dialogueCanvas.gameObject.SetActive (f);
		curCanvas.gameObject.SetActive (!f);
		if (!f && enterDialogueButton != null) {
	//		Debug.Log (enterDialogueButton.name + " deactivate");
			Destroy (enterDialogueButton);
			enterDialogueButton = null;
		}

	}

	public void SetCurCanvas(Canvas c){
		curCanvas = c;
	}

	public void TurnOnOverlay(){
		overlayCanvas.gameObject.SetActive (true);
	}

	public void TurnOffOverlay(){
		overlayCanvas.gameObject.SetActive (false);
	}

	public void ActivateDialogueButton(Canvas c, string s, string desc){
		enterDialogueButton = Instantiate(EnterDialogueButtonPrefab) as GameObject;
		enterDialogueButton.transform.SetParent(c.transform);
		enterDialogueButton.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (364, -134, 0);
		enterDialogueButton.GetComponent<RectTransform> ().localScale = new Vector3(1.642344f,1.642344f,1.642344f);
		enterDialogueButton.GetComponent<Button>().onClick.AddListener(() => dialogueManager.instance.EnterDialogue(s,enterDialogueButton));
		enterDialogueButton.GetComponentInChildren<Text> ().text = desc;
		MC.instance.UpdateBool (s);
	}



}
