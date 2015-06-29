using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
	public static Story instance { get; private set; }

	public bool hasTalkedToMomIntro;
	public bool wentToVillageMorning;
	public bool hastalkedToCeara;
	public bool wentToInn;
	public bool talkedToIllijInInn;
	public bool wentToPond;
	public bool racedTree;
	public bool wentBackToInn;
	public bool gotGloves;
	public bool ritualStart;
	public bool ritualHasStarted;
	public bool rebootGo;
	public bool shouldExit;
	public bool shouldRestart;

	public string StartDial;
	public GameObject DatabaseButton;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void OnCanvasChange(Canvas c){
		if(c==canvasManager.instance.houseCanvas){ //IF HOUSE
			if(!hasTalkedToMomIntro){
				canvasManager.instance.ActivateDialogueButton(c,"momIntro", "Talk to Mom");
				return;
			}
		}

		if(c==canvasManager.instance.villageCanvas){ //IF VILLAGE
			if(!wentToVillageMorning){
				//dialogueManager.instance.EnterAmbient("firstVillage",null);
				return;
			}
		}
	}


	public void OnExitDialogue(Canvas c){
		if(shouldExit){
			Application.Quit();
			return;
		}
		if (shouldRestart) {
			//SHOULD RESTART
		}
		if(rebootGo){
			BootScript.instance.StartReboot();
			return;
		}
		if (c == canvasManager.instance.villageCanvas && ritualStart && !ritualHasStarted) {
			if(MC.instance.wentWithCearaForGloves){
			//	dialogueManager.instance.EnterAmbient("cearaRitIntro",null);
			}
			else{
			//	dialogueManager.instance.EnterAmbient("stayRitIntro",null);
			}
			return;
		}
		if(c==canvasManager.instance.villageCanvas && gotGloves && !ritualStart){
			//dialogueManager.instance.EnterDialogue("cearaAgree",null);
			ritualStart = true;
			return;
		}
		/*if (c == racedTree && !wentBackToInn) {
			Debug.Log("race over");
			if(MC.instance.CearaCursed){
				//TRIGGER PULL DIAL
				Debug.Log("pulling");
				dialogueManager.instance.EnterAmbient("pullAmbient",null);
			}
			else{
				Debug.Log("not pulling");
				dialogueManager.instance.EnterAmbient("nonPullAmbient",null);
			}
			return;
		}*/
		if(c==canvasManager.instance.villageCanvas && wentToInn && !talkedToIllijInInn){
			Debug.Log("illijIntro");
			//dialogueManager.instance.EnterDialogue("IllijIntro",null);
			talkedToIllijInInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && hastalkedToCeara && !wentToInn){
			//dialogueManager.instance.EnterAmbient("innIntro",null);
			wentToInn = true;
			return;
		}
		if(c==canvasManager.instance.villageCanvas && !hastalkedToCeara){
			//dialogueManager.instance.EnterDialogue("cearaIntro",null);
			//canvasManager.instance.ActivateDialogueButton(c,"cearaIntro", "Say hi to Ceara");
			return;
		}
		if(c==canvasManager.instance.houseCanvas && !hasTalkedToMomIntro){

			return;
		}

	}

	public void OnDialogueTrigger(string dial, int pos){
		ChangeGlitchTimings (dial,pos);
		if (dial == "momIntro" && pos == 0) {
			hasTalkedToMomIntro = true;	
		}
		if (dial == "cearaIntro" && pos == 17) {
			hastalkedToCeara = true;
		}
		if(dial == "sageIntro" && pos == 2){
			GlitchManager.instance.GlitchScreenOnCommand(0.4f);
			SoundManager.instance.ChangeMasterMixerValue("volume",-10f);
			SoundManager.instance.curMasterVolume = -10f;
		}
		if(dial == "sageIntro" && pos == 5){
			SoundManager.instance.PlayAmbient("inn");
		}
		if(dial == "raceChoice" && pos == 0){
			racedTree = true;
		}
		if(dial == "raceChoice" && pos == 1){
			MC.instance.CearaCursed = true;
		}
		if(dial == "pullAmbient" && pos == 5){
			wentBackToInn = true;
		}
		if (dial == "innCurseIntro" && pos == 12) {
			MC.instance.toldAboutSmell = true;
		}
		if(dial == "pondIntro" && pos == 0){
			wentToPond = true;
		}
		if (dial == "pullAmbient" && pos == 2) {
			GlitchManager.instance.GlitchScreenOnCommand(1f);
		}
		if(dial == "cursedGoBackToInn" && pos == 3){
			SoundManager.instance.PlayAmbient("inn");
		}
		if(dial == "cursedGoBackToInn" && pos == 5){
			SoundManager.instance.StopAmbients();
		}
		if(dial == "followCeara" && pos == 4){
			MC.instance.wentWithCearaForGloves = true;
			SoundManager.instance.StopAmbients();
		}

		if(dial == "followCeara" && pos == 8){
			MC.instance.toldCearaAboutSageBeingWeird = true;
		}
		if(dial == "followCeara" && pos == 15){
			gotGloves = true;
			if(!MC.instance.toldCearaAboutSageBeingWeird){
				ritualStart = true;
			}
		}
		if((dial == "cearaRitIntro" || dial == "stayRitIntro") && pos == 0){
			ritualHasStarted = true;
		}
		if(dial == "ritual" && pos == 15){
			GlitchManager.instance.GlitchScreenOnCommand(0.5f);
		}
		if(dial == "ritChoice" && pos == 5){
			MC.instance.wentToCaudden = true;
		}
		if (dial == "goesToCaudden" || dial == "goesNorth" && pos == 2) {
			rebootGo = true;
		}
		if(dial == "search" && pos == 4){
			if(!MC.instance.wentToCaudden){
				dialogueOptionContainerScript.instance.allDialogues["search"].Find(x=>x.id==4).altResp.shouldAlter = true;
				dialogueOptionContainerScript.instance.allDialogues["search"].Find(x=>x.id==44).altResp.shouldAlter = true;
			}
		}

		if (dial == "search" && pos == 96) {
			SoundManager.instance.PlayMessageSound(1f);
		}
		if (dial == "search" && pos == 101) {
			shouldExit = true;
		}
		if (dial == "search" && pos == 95) {
			SoundManager.instance.StopSound(SoundManager.instance.messageSound);
			SoundManager.instance.StopAmbients();
			//       ----------------------------------      GLITCHING
		}

		if (dial == "search" && pos == 100) {
			SoundManager.instance.ShutDownComputer();
		}
		if (dial == "search" && pos == 102) {
			shouldRestart = true;
		}
	}



	public void ActivateSounds(string d){
		if (d == "cearaIntro") {
			SoundManager.instance.PlayAmbient("village");
		}
		if(d == "innIntro"){
			SoundManager.instance.PlayAmbient("inn");
		}
		if (d == "sageIntro") {
			SoundManager.instance.StopAmbients();
		}
		if(d == "pondIntro"){
			SoundManager.instance.PlayAmbient("pond");
		}
		if(d == "cursedGoBackToInn"){
			SoundManager.instance.StopAmbients();
		}
		//I Play inn somewhere here. And stop it again.

		if(d == "outsideInn"){
			SoundManager.instance.PlayAmbient("village");
		}
		if(d == "cearaAgree" || d == "cearaRitIntro"){
			SoundManager.instance.PlayAmbient("village");
		}
		if(d == "ritual"){
			GlitchManager.instance.GlitchScreenOnCommand(0.4f);
			SoundManager.instance.PlayAmbient("wind");
		}
		if (d == "search") {
			SoundManager.instance.StopSound(SoundManager.instance.roomSound);
			SoundManager.instance.StopSound(SoundManager.instance.workSound);
			SoundManager.instance.PlayAmbient("deadvillage");
		}
	}



	public void ChangeGlitchTimings(string dial, int pos){
		if(dial == "sageIntro" && pos == 2){ //START GLITCHING, sage comes
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if(dial == "race" && pos == 0){ //WENT TO POND
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if (dial == "cCursed" && pos == 0) { //C cursed
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if(dial == "ritual" && pos == 4){ //ritual
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if(dial == "ritual" && pos == 15){ //ritual go nuts
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if((dial == "goesNorth" || dial == "goesToCaudden") && pos == 1){ //reboot start
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if(dial == "search" && pos == 0){ //search start
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if (dial == "search" && pos == 98) { // search go nuts
			GlitchManager.instance.ChangeGlitchTimings();
		}
		if (dial == "search" && pos == 95) { //search end
			GlitchManager.instance.ChangeGlitchTimings();
		}

	}




}
