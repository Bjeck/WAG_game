﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;  
using System.Linq;
//using System;

public class twineparser : MonoBehaviour {

	public string textfileName;

	// Use this for initialization
	void Start () {
	
		Load (textfileName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool Load(string fileName)
	{
		// Handle any problems that might arise when reading the text

		string line;;
		line = "";
		// Create a new StreamReader, tell it which file to read and what encoding the file
		// was saved as
		StreamReader theReader = new StreamReader(fileName, Encoding.Default);
		// Immediately clean up the reader after this block of code is done.
		// You generally use the "using" statement for potentially memory-intensive objects
		// instead of relying on garbage collection.
		// (Do not confuse this with the using directive for namespace at the 
		// beginning of a class!)
		using (theReader)
		{
			// While there's lines left in the text file, do this:
			while(line != null){
				//print("reading line");
				line = theReader.ReadLine();

				if(line != null){
					List<string> entries = line.Split(new string[] {"[[[[]]]]"},System.StringSplitOptions.None).ToList();
					
					entries.Remove("ID§DIALOGUE§THOUGHTS§thoughtdelay§optiondelay§TRIGGER?§OPTION 1§OPTION 2§OPTION 3§OPTION 4§"); entries.Remove("");
					
					
					print ("COUNT "+entries.Count);
					//if (entries.Length > 0)
					//	DoStuff(entries);
					List<string> elements = new List<string>();
					foreach(string s in entries){
						print (s);
						elements = (s.Split('§').ToList());
					}
					
					foreach(string s in elements){
						print (s);
						//elements.Add(s.Split('§'));
					}
					if(elements.Count > 3){
						
						DialogueInst momIntroGreet = new DialogueInst ();
						momIntroGreet.id = int.Parse(elements[0]);
						momIntroGreet.response = elements[1];
						momIntroGreet.thoughts = elements[2];
						momIntroGreet.thoughtsDelay = float.Parse(elements[3]);
						momIntroGreet.optionDelay = float.Parse(elements[4]);
						//momIntroGreet.NextTrigger ("",false); //NEEDS REWORK
						momIntroGreet.options.Add (elements[6]);
						momIntroGreet.options.Add(elements[7]);
						momIntroGreet.options.Add(elements[8]);
						momIntroGreet.ResponseNrs.Add (1); //NEEDS REWORK
						momIntroGreet.ResponseNrs.Add (1);
						momIntroGreet.ResponseNrs.Add (3);
						
						print (momIntroGreet.response+" "+momIntroGreet.thoughts+" "+momIntroGreet.thoughtsDelay);
					}


				}
			}
				//
			//while(line != null);
			// Done reading, close the reader and return true to broadcast success    
			theReader.Close();
			return true;
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work

	}
}

/*
DialogueInst momIntroGreet = new DialogueInst ();
		momIntroGreet.id = 0;
		momIntroGreet.response = "'Morning, sleepyhead.'                          ¤'Tea's still fresh in the kitchen, if you want.'";
		momIntroGreet.thoughts = "..What's...";
		momIntroGreet.options.Add ("Hey.");
		momIntroGreet.options.Add("Morning.");
		momIntroGreet.options.Add("[Grab some tea]");
		momIntroGreet.thoughtsDelay = 2.0f;
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (1);
		momIntroGreet.ResponseNrs.Add (3);
		momIntroGreet.optionDelay = 3.1f;
		//momIntroGreet.NextTrigger ("",false);
		dialogueContainer.Add (momIntroGreet);

 
talks[concounter] = new List<string>();


























do
			{
				line = theReader.ReadLine();
				
				if (line != null)
				{
					// Do whatever you need to do with the text line, it's a string now
					// In this example, I split it into arguments based on comma
					// deliniators, then send that array to DoStuff()
					//line = line.Replace('[[]]',System.Environment.NewLine)
					List<string> entries = line.Split(new string[] {"[[[[]]]]"},System.StringSplitOptions.None).ToList();


					//entries.Remove("ID§DIALOGUE§THOUGHTS§thoughtdelay§optiondelay§TRIGGER?§OPTION 1§OPTION 2§OPTION 3§OPTION 4§"); //entries.Remove("]");
					print (entries.Count);
					//if (entries.Length > 0)
					//	DoStuff(entries);
					List<string> elements = new List<string>();
					foreach(string s in entries){
						print (s);
						elements = (s.Split('§').ToList());
					}

					foreach(string s in elements){
						//print (s);
						//elements.Add(s.Split('§'));
					}


					//

					//THIS NEEDS TO HAPPEN IN A LOOP, OFC


				}
			}
			while (line != null);




 */