using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {
	GameObject Manager;

	// Use this for initialization
	void Start () 
	{
	   
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.loadedLevelName == "Menu") {
			if (Input.GetKeyDown ("joystick 1 button 7")|| Input.GetKeyDown ("joystick 2 button 7")) {
				Application.LoadLevel ("playerselection");
			}
		}

		if (Application.loadedLevelName == "DaRealDemo") {
			if (Input.GetKeyDown ("joystick 1 button 7")|| Input.GetKeyDown ("joystick 2 button 7")) 
			{
				Manager = GameObject.FindGameObjectWithTag("Manager");
				Destroy (Manager);
				Application.LoadLevel ("Menu");
			}
		}
	}
}
