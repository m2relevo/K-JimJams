using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	public int maxPCount = 4;
	bool[] pCount;
	bool firstcall;
	GameObject[] players;
	public GameObject player1, player2, player3, player4;
	public bool Test;
	public Text[] text;
	bool check;



	void SetPlayNo()
	{
		if (firstcall == true) {
			//would loop if more players
			pCount [0] = false;
			pCount [1] = false;
			pCount [2] = false;
			pCount [3] = false;
			firstcall = false;
		}
		if (Input.GetKeyDown ("joystick 1 button 4")) 
		{
			pCount[0] = !pCount[0];
			if(pCount[0] == false)
			{
				text[0].text = " Press Left Bumper";
			}
			if(pCount[0] == true)
			{
				text[0].text = " Ready ";
			}
			
		}
		if (Input.GetKeyDown ("joystick 1 button 5"))
		{
			pCount[1] = !pCount[1];
			if(pCount[1] == false)
			{
				text[1].text = " Press Right Bumper";
			}
			if(pCount[1] == true)
			{
				text[1].text = " Ready ";
			}
		}
		if (Input.GetKeyDown ("joystick 2 button 4")) 
		{
			pCount[2] = !pCount[2];
			if(pCount[2] == false)
			{
				text[2].text = " Press Left Bumper";
			}
			if(pCount[2] == true)
			{
				text[2].text = " Ready ";
			}
			
		}
		if (Input.GetKeyDown ("joystick 2 button 5"))
		{
			pCount[3] = !pCount[3];
			if(pCount[3] == false)
			{
				text[3].text = " Press Right Bumper";
			}
			if(pCount[3] == true)
			{
				text[3].text = " Ready ";
			}
			
		}
	}

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);

	}
	

	void Start () 
	{
        players  = new GameObject[4];
		pCount = new bool[maxPCount];
		firstcall = true;
		check = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.loadedLevelName == "playerselection") 
		{
			SetPlayNo ();
			if (Input.GetKeyDown ("joystick 1 button 7")) {
				Application.LoadLevel ("DaRealDemo");
			}
		}
		if (Application.loadedLevelName == "DaRealDemo") {
			this.gameObject.GetComponent<ProjectileManager>().enabled=true;
			if (check == false) {
				for (int i =0; i<4; i++) {
					if (pCount [i] == true) {
						if (i == 0) {
							players [0] = (GameObject)Instantiate (player1);
						}
						if (i == 1) {
							players [1] = (GameObject)Instantiate (player2);
						}
						if (i == 2) {
							players [2] = (GameObject)Instantiate (player3);
						}
						if (i == 3) {
							players [3] = (GameObject)Instantiate (player4);
						}
					}
				}
				check = true;
			}
		}
	}





	public bool[] playerCheck()
	{

		bool[] pStats = new bool[maxPCount+1];
		//first cell in array returns no of players rest act as booleans to say whether playing
		for (int j = 0; j<maxPCount; j++) 
		{
			pStats[j] =false;
		}
		for (int i =0; i< maxPCount; i++) 
		{
			if(pCount[i] == true)
			{
				pStats[i] = true;
			}
		}

		return pStats;
	}
}
