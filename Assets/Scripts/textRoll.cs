using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textRoll : MonoBehaviour {

	Text text;

	public float startDel = 0;
	bool hasStartedRolling = false;

	int curPos = 0;
	public float del;
	float time = 0;

	public string textToDisplay;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		textToDisplay = textToDisplay.Replace("¤", System.Environment.NewLine);

		if (startDel == 0) {
			hasStartedRolling = true;
			StartCoroutine (RollText ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hasStartedRolling) {
			return;
		}

		if (startDel <= 0) {
			hasStartedRolling = true;
			StartCoroutine (RollText ());
		} else {
			startDel -= Time.deltaTime;
		}

	}


	IEnumerator RollText(){
		foreach (char c in textToDisplay) {
			text.text += c;
			yield return new WaitForSeconds(del);
		}
	}


}
