using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textRoll : MonoBehaviour {

	Text text;

	public float startDel = 0;
	bool hasStartedRolling = false;

	public float del;
	bool isColored = false;

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
			if(c == '<'){
				text.text += "<color=#0f0f0fff>"+"</color>";
				isColored = true;
			}
			else if(isColored){
				text.text = text.text.Substring(0,text.text.Length-8);
				if(c == '>'){
					isColored = false;
					text.text += "</color>";
				}
				else{
					text.text += c+"</color>";
				}
			}
			else{
				text.text += c;
			}

			yield return new WaitForSeconds(del);
		}
	}


}
