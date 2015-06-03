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
	List<Canvas> canvases = new List<Canvas> ();
	public Canvas curCanvas;
	
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

		foreach (Canvas c in canvases) {
				c.gameObject.SetActive(c==curCanvas);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ActivateCanvas(Canvas c){
		c.gameObject.SetActive (true);
		foreach (Canvas p in canvases) {
			if(p!=c){
				p.gameObject.SetActive(false);
			}
		}
		curCanvas = c;
	}

	public void DeactivateCanvas(Canvas c){
		c.gameObject.SetActive (false);
	}

	public void ChangeDialogueCanvas(bool f){
		dialogueCanvas.gameObject.SetActive (f);
		curCanvas.gameObject.SetActive (!f);
	}

	public void SetCurCanvas(Canvas c){
		curCanvas = c;
	}



}
