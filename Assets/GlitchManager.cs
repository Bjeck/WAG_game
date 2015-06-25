using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GlitchManager : MonoBehaviour {
	public static GlitchManager instance { get; private set; }

	public List<GameObject> textObjects = new List<GameObject>();
	public List<glitchText> glitchTexts = new List<glitchText>();

	public float timeToGlitchMin;
	public float timeToGlitchMax;
	public float sustainGlitchTimeMin = 0.03f;
	public float sustainGlitchTimeMax = 0.4f;
	public bool shouldUpdateGlitchTiming;
	[SerializeField]
	int GlitchProgression = 0;
	bool firsttime = true;

	public GlitchEffect glEf;
	public float glitchIntensity;
	public float glitchTimeMin;
	public float glitchTimeMax;
	float timeToGlitch;
	public float glitchSustainMin;
	public float glitchSustainMax;

	public AudioSource[] noiseSounds;
	public AudioMixer mixer;


	//0.01, 0.02, 0.005, 0.015

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}


	public void Update(){
		if (timeToGlitch > 0) {
			timeToGlitch -= Time.deltaTime;
		} else {
			StartCoroutine(GlitchScreen());
		}
	}

	public IEnumerator GlitchScreen(){
		float time;
		if (firsttime) {
			glEf.enabled = true;
			timeToGlitch = UnityEngine.Random.Range (glitchTimeMin, glitchTimeMax);
			time = 1f;
			glEf.intensity = glitchIntensity ;
			firsttime = false;
		} else {
			glEf.enabled = true;
			timeToGlitch = UnityEngine.Random.Range (glitchTimeMin, glitchTimeMax);
			time = UnityEngine.Random.Range (glitchSustainMin, glitchSustainMax);
			glEf.intensity = glitchIntensity * Random.Range (0.5f, 1.5f);
		}

		//PlayGlitchSound ();
		
		while (time > 0) {
			time -= Time.deltaTime;
			yield return 0;
		}
		glEf.intensity = 0;
		glEf.enabled = false;
		if (BootScript.instance.panel.activeSelf) {
			BootScript.instance.panel.SetActive(false);
		}
		SoundManager.instance.master.SetFloat ("volume", 0);
		foreach (AudioSource a in noiseSounds) {
			a.Stop();		
		}
		yield return 0;
	}

	public void GlitchScreenOnCommand(float t){
		StartCoroutine (GlitchScreenOC (t));
	}

	IEnumerator GlitchScreenOC(float time){

		glEf.enabled = true;
		glEf.intensity = glitchIntensity * Random.Range (0.5f, 1.5f);
		
		//PlayGlitchSound ();
		
		while (time > 0) {
			time -= Time.deltaTime;
			yield return 0;
		}
		glEf.intensity = 0;
		glEf.enabled = false;
		SoundManager.instance.master.SetFloat ("volume", 0);
		foreach (AudioSource a in noiseSounds) {
			a.Stop();		
		}
		yield return 0;
	}


	public void OnChangingText(){
		if (!Story.instance.wentToPond) {
			return;
		} 
		textObjects.Clear ();
		glitchTexts.Clear ();


		textObjects.Add (dialogueManager.instance.response);
		textObjects.Add (dialogueManager.instance.thoughts);


		foreach (GameObject g in textObjects) {
				glitchTexts.Add(g.AddComponent<glitchText>());
		}

		foreach(glitchText s in glitchTexts){
			s.timeToGlitchMax = timeToGlitchMax;
			s.timeToGlitchMin = timeToGlitchMin;
			s.sustainGlitchTimeMax = sustainGlitchTimeMax;
			s.sustainGlitchTimeMin = sustainGlitchTimeMin;
		}

	}

	public void ChangeGlitchTimings(){ //timeToGlitchMin = 1f; timeToGlitchMax = 4f; sustainGlitchTimeMin = 0.03f; sustainGlitchTimeMax = 0.08f;
		if (GlitchProgression == 0) {
			timeToGlitchMin = 1f; timeToGlitchMax = 4f; sustainGlitchTimeMin = 0.03f; sustainGlitchTimeMax = 0.08f; 
		}
		if (GlitchProgression == 1) {
			timeToGlitchMin = 0.1f; timeToGlitchMax = 4f; sustainGlitchTimeMin = 0.05f; sustainGlitchTimeMax = 0.1f;
		}
		else if(GlitchProgression == 2){
			timeToGlitchMin = 0.07f; timeToGlitchMax = 3f; sustainGlitchTimeMin = 0.02f; sustainGlitchTimeMax = 0.15f;
		}
		else if(GlitchProgression == 3){
			timeToGlitchMin = 0.03f; timeToGlitchMax = 1f; sustainGlitchTimeMin = 0.01f; sustainGlitchTimeMax = 0.15f;
		}

		GlitchProgression++;
	}


	public void PlayGlitchSound(int c){
		int soundChooser = 0;
		switch (c) {
		case 0 :
			soundChooser = Random.Range (0, noiseSounds.Length+1);
			if(soundChooser == 2){
				soundChooser += Random.Range(-2,1);
			}
			mixer.SetFloat("drymix",Random.Range(0,1f));
			mixer.SetFloat ("wetmix", Random.Range (0, 1f));
			mixer.SetFloat("rate",Random.Range(0,20));
			mixer.SetFloat("lowpassCut",22000f);
			if(soundChooser < noiseSounds.Length){
				noiseSounds [soundChooser].Play ();
			}
			break;
		case 1 :
			soundChooser = Random.Range (0, noiseSounds.Length+1);
			if(soundChooser == 2){
				soundChooser += Random.Range(-1,1);
			}
			mixer.SetFloat("lowpassCut",Random.Range(100f,20000f));
			if(soundChooser < noiseSounds.Length){
				noiseSounds [soundChooser].Play ();
			}
			break;
		case 2 :
			mixer.SetFloat("drymix",Random.Range(0,1f));
			mixer.SetFloat ("wetmix", Random.Range (0, 1f));
			mixer.SetFloat("rate",Random.Range(0,20));
			mixer.SetFloat("lowpassCut",22000f);
			noiseSounds [2].Play ();
			break;
		}
		if (soundChooser == noiseSounds.Length) {
			foreach (AudioSource a in noiseSounds) {
				a.Stop();		
			}
		}
		SoundManager.instance.master.SetFloat ("volume", -80);

	}





}
