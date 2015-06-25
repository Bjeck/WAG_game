using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BootScript : MonoBehaviour {
	public static BootScript instance { get; private set; }
	
	public Text text;
	public InputField ipf;
	public textRoll t;
	public textRoll buttonText;
	public GameObject button;
	public GameObject panel;
	float bootWaitTime = 1f;
	bool haveplayedBootSound;

	float passDel;
	public GameObject bootCanvas;
	public GameObject mainGameCanvas;

	public bool hasBooted;
	public int bootSeq;
	public bool buttonShouldSpawn;
	public float rollTime;
	public bool buttonHasSpawned;

	public bool inSearchMode = false;

	//
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
		t.del = 0.05f;
		passDel = text.gameObject.GetComponent<textRoll> ().textToDisplay.Length * text.gameObject.GetComponent<textRoll> ().del+2f;
		button.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (!haveplayedBootSound) {
			if (bootWaitTime > 0) {
				bootWaitTime -= Time.deltaTime;
			} else {
				SoundManager.instance.PlayBootSound ();
				haveplayedBootSound = true;
			}
		}



		if (!inSearchMode) {

			if(hasBooted){
				if (rollTime > 0) {
					rollTime -= Time.deltaTime;
				} else if(!buttonShouldSpawn && !buttonHasSpawned) {
					buttonShouldSpawn = true;
					buttonHasSpawned = false;
				}
				
				if (buttonShouldSpawn && !buttonHasSpawned) {
					button.SetActive(true);
					WriteButtonText();
					buttonHasSpawned = true;
				}
			}

			
			if (!hasBooted) {
				if (passDel <= 0) {
					ipf.gameObject.SetActive (true);
					ipf.GetComponent<activateInputField> ().ActivateInputField ();
				} else {
					passDel -= Time.deltaTime;
				}
			}
		}
	}

	public void NextBootWindow(){
		button.SetActive(false);
		t.del = 0.02f;
		buttonShouldSpawn = false;
		buttonHasSpawned = false;
		ipf.gameObject.SetActive(false);
		hasBooted = true;

		ClearBootText ();
		GlitchManager.instance.StartCoroutine (GlitchManager.instance.GlitchScreen ());

		switch (bootSeq) {
		case 0:
			t.textToDisplay = "----- SEQUENCE TERMINATED -----¤Invalid Argument Error: Query exceeds data string count. Exiting…¤…Done.";
			buttonText.textToDisplay = "[Load Site] ";
			rollTime = 3f;
			break;
		case 1:
			t.textToDisplay = "Loading process.contamination              ¤Accessing system files           ¤3-8 Ready ¤2-7 Ready ¤1-9 Ready  ¤7-4 Ready     ¤Filling memory banks… … …Done.";
			buttonText.textToDisplay = "[Access Site] ";
			rollTime = 5f;
			break;
		case 2:
			t.textToDisplay = "Loading surveySite.sat    ¤Requesting access… Granted. ¤Server ready.        ¤Sending Message  ¤:: Hello ::          ¤…            ¤…         ¤No response from Site.                                   ¤¤Sending Message ¤:: Status(Caudden) ::  ¤Response:    ¤:: Dead ::";
			rollTime = 8f;
			break;
		case 3:
			t.textToDisplay = "POI Requested… Searching…   ¤1 POI Found...  ¤Name: Sauddoc  ¤Marked of Interest: Eravola Outbreak Reported   ¤Investigate?";
			rollTime = 4f;
			break;
		case 4:
			t.textToDisplay = "Requesting Access… Access Granted.  ¤Loading POI…  ¤Processing site… … Done.  ¤Loading status… Done. ¤Populating area... Done. 0 Person(s) present  ¤Finding Marks of Relevance… Done.  ¤Loading descriptions… Done.   ¤Loading Natural Language Interface… Done.";
			rollTime = 4f;
			break;
		case 5:
			ActivateSearchMode();
			break;
		}

		if (!inSearchMode) {
			t.shouldStopRolling = false;
			buttonText.shouldStopRolling = false;
			
			//buttonText.Start();
			t.Start();
			
			bootSeq++;
		}	
	}


	public void ActivateSearchMode(){
		inSearchMode = true;
		ClearBootText ();
		canvasManager.instance.ActivateCanvas (canvasManager.instance.bootCanvas);
		dialogueManager.instance.EnterDialogue ("search",null);
	}	









	public void WriteButtonText(){
		buttonText.shouldStopRolling = true;
		buttonText.StopCoroutine(buttonText.RollText());
		buttonText.gameObject.GetComponent<Text> ().text = "";
		buttonText.textToDisplay = "";

		switch (bootSeq - 1) {
		case 0:
			buttonText.textToDisplay = "[Load Site] ";
			break;
		case 1:
			buttonText.textToDisplay = "[Access Site] ";
			break;
		case 2:
			buttonText.textToDisplay = "[Load Nearest POI] ";
			break;
		case 3:
			buttonText.textToDisplay = "[Investigate] ";
			break;
		case 4:
			buttonText.textToDisplay = "[Enter] ";
			break;
		}
		buttonText.Start();
	}


	public void ClearBootText(){
		//t.shouldStopRolling = true;
		//buttonText.shouldStopRolling = true;
		t.StopCoroutine(t.RollText());
		buttonText.StopCoroutine(buttonText.RollText());
		t.gameObject.GetComponent<Text> ().text = "";
		buttonText.gameObject.GetComponent<Text> ().text = "";
		t.textToDisplay = "";
		buttonText.textToDisplay = "";
	}



	public void CheckPassword(){
		string passInp = ipf.text.ToLower();
		if(passInp.Length > 0){
			bootCanvas.SetActive(false);
			ipf.gameObject.SetActive(false);
			hasBooted = true;
			SoundManager.instance.ChangeComputerMixerValue("volume",-5f);
			SoundManager.instance.passWordSound.Play();
			canvasManager.instance.ActivateCanvas(canvasManager.instance.houseCanvas);
			dialogueManager.instance.EnterDialogue("momIntro", null);
		}
	}
}

