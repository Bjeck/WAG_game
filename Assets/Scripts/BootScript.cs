using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BootScript : MonoBehaviour {

	public Text text;
	public InputField ipf;

	float passDel;
	public GameObject bootCanvas;
	public GameObject mainGameCanvas;



	// Use this for initialization
	void Start () {
		passDel = text.gameObject.GetComponent<textRoll> ().textToDisplay.Length * text.gameObject.GetComponent<textRoll> ().del+0.5f;

	}
	
	// Update is called once per frame
	void Update () {

		if (passDel <= 0) {
			ipf.gameObject.SetActive (true);
			ipf.GetComponent<activateInputField> ().ActivateInputField ();
		} else {
			passDel -= Time.deltaTime;
		}
	
	}

	public void CheckPassword(){
		string passInp = ipf.text.ToLower();
		if(passInp == "password"){
			Debug.Log("YAY");
			bootCanvas.SetActive(false);
			canvasManager.instance.ActivateCanvas(canvasManager.instance.houseCanvas);
		}
	}
}
