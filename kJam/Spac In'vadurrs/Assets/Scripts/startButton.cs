using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("joystick 1 button 7")) 
		{
			Application.LoadLevel ("playerselection");
		}
	}
}
