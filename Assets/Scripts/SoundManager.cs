using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance { get; private set; }

	public AudioMixer master;
	public AudioMixer glitch;
	public AudioMixer computer;

	public AudioSource OnClickSound;
	public AudioSource BootSound;


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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeComputerMixerValue(string n, float f){
		Debug.Log ("cHNAGE " + n + " " + f);
		computer.SetFloat (n, f);
	}

	public void ChangeMasterMixerValue(string n, float f){
		master.SetFloat (n, f);
	}


	public void PlayClickSound(){
		OnClickSound.Play ();
	}

	public void PlayBootSound(){
		BootSound.Play ();
	}



}
