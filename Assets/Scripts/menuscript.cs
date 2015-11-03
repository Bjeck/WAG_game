using UnityEngine;
using System.Collections;

public class menuscript : MonoBehaviour {

	public AudioSource ambience;
	public AudioSource clicksound;
	public AudioSource thirdSound;
	public AudioSource bootSound;
	public AudioSource boot2Sound;
	public AudioSource[] noiseSounds;
	public GlitchEffectMenu glitch;

	// Use this for initialization
	void Start () {

		ambience.Play();
		clicksound.Play();
		thirdSound.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void LoadGame(){
		clicksound.Play();
		bootSound.Play();
		boot2Sound.Play();
		glitch.intensity = 4f;

		Application.LoadLevel("scene1");
	}




	public void PlayGlitchSound(int c){
		int soundChooser = 0;
		switch (c) {
		case 0 :
			soundChooser = Random.Range (0, noiseSounds.Length+1);
			if(soundChooser == 2){
				soundChooser += Random.Range(-2,1);
			}
		//	mixer.SetFloat("drymix",Random.Range(0,1f));
		//	mixer.SetFloat ("wetmix", Random.Range (0, 1f));
		//	mixer.SetFloat("rate",Random.Range(0,20));
		//	mixer.SetFloat("lowpassCut",22000f);
			if(soundChooser < noiseSounds.Length){
				noiseSounds [soundChooser].Play ();
			}
			break;
		case 1 :
			soundChooser = Random.Range (0, noiseSounds.Length+1);
			if(soundChooser == 2){
				soundChooser += Random.Range(-1,1);
			}
		//	mixer.SetFloat("lowpassCut",Random.Range(100f,20000f));
			if(soundChooser < noiseSounds.Length){
				noiseSounds [soundChooser].Play ();
			}
			break;
		case 2 :
		//	mixer.SetFloat("drymix",Random.Range(0,1f));
		//	mixer.SetFloat ("wetmix", Random.Range (0, 1f));
		//	mixer.SetFloat("rate",Random.Range(0,20));
		//	mixer.SetFloat("lowpassCut",22000f);
			noiseSounds [2].Play ();
			break;
		}
		if (soundChooser == noiseSounds.Length) {
			foreach (AudioSource a in noiseSounds) {
				a.Stop();		
			}
		}
		//SoundManager.instance.master.SetFloat ("volume", -80);
		
	}

}
