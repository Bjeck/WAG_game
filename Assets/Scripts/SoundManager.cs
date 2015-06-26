using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance { get; private set; }

	public AudioMixer master;
	public AudioMixer glitch;
	public AudioMixer computer;

	public AudioSource OnClickSound;
	public AudioSource BootSound;
	public AudioSource ComputerAmbient;
	public AudioSource textSound;
	public AudioSource passWordSound;
	public AudioSource textGlitchSound;
	public AudioSource noiseSound;
	public AudioSource roomSound;


	public AudioSource[] KeyBoardClacks;

	public AudioSource[] ambiences;
	Dictionary<string,AudioSource> Ambiences = new Dictionary<string,AudioSource>();


	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
		Ambiences.Add ("inn", ambiences [0]);
		Ambiences.Add ("village", ambiences [1]);
	}

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeComputerMixerValue(string n, float f){
		computer.SetFloat (n, f);
	}

	public void ChangeMasterMixerValue(string n, float f){
		master.SetFloat (n, f);
	}


	public void PlayClickSound(){
		OnClickSound.pitch = 1;
		OnClickSound.pitch += Random.Range (-0.2f, 0.2f);
		OnClickSound.Play ();
	}

	public void PlayBootSound(){
		BootSound.Play ();
		ComputerAmbient.Play ();
	}

	public void PlayTextSound(){
		if(canvasManager.instance.curCanvas == canvasManager.instance.bootCanvas)
			textSound.Play ();
	}

	public void PlayKeyboardSound(){
		int kCho = Random.Range (0, KeyBoardClacks.Length);
		KeyBoardClacks [kCho].Play ();
	}

	public void PlayTextGlitchSound(){

		SoundManager.instance.glitch.SetFloat("drymix",Random.Range(0,1f));
		SoundManager.instance.glitch.SetFloat ("wetmix", Random.Range (0, 1f));
		SoundManager.instance.glitch.SetFloat("rate",Random.Range(0,20));
		SoundManager.instance.glitch.SetFloat("lowpassCut",Random.Range(100f,20000f));
		int i = Random.Range (0, 4);
		if (i == 0) {
			textGlitchSound.Play ();
		}
		else if(i == 1){
			noiseSound.Play ();
		}
		else if(i >= 2){
			textGlitchSound.Play ();
			noiseSound.Play ();
		}
	}



	public void PlayAmbient(string s){
		StopAmbients ();
		Ambiences [s].Play ();
	}

	public void StopAmbients(){
		foreach (AudioSource a in Ambiences.Values) {
			a.Stop();
		}
	}



	public void StopSound(AudioSource s){
		s.Stop();
	}



}
