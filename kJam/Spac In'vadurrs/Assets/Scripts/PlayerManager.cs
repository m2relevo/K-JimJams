using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	public int maxPCount = 4;
	bool[] pCount;
	bool firstcall;
	GameObject[] players;
	bool[] alive;
	public GameObject player1, player2, player3, player4;
	public bool Test;
	public GameObject[] text;
	public GameObject[] life;
	bool check;
	Vector2[] PSpawn;
	int[] lifes;



	void SetPlayNo()
	{
		text = GameObject.FindGameObjectsWithTag("Text");
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
				text[1].GetComponent<Text>().text = " Press Left Bumper";
			}
			if(pCount[0] == true)
			{
				text[1].GetComponent<Text>().text  = " Ready ";
			}
			
		}
		if (Input.GetKeyDown ("joystick 1 button 5"))
		{
			pCount[1] = !pCount[1];
			if(pCount[1] == false)
			{
				text[3].GetComponent<Text>().text  = " Press Right Bumper";
			}
			if(pCount[1] == true)
			{
				text[3].GetComponent<Text>().text  = " Ready ";
			}
		}
		if (Input.GetKeyDown ("joystick 2 button 4")) 
		{
			pCount[2] = !pCount[2];
			if(pCount[2] == false)
			{
				text[0].GetComponent<Text>().text  = " Press Left Bumper";
			}
			if(pCount[2] == true)
			{
				text[0].GetComponent<Text>().text  = " Ready ";
			}
			
		}
		if (Input.GetKeyDown ("joystick 2 button 5"))
		{
			pCount[3] = !pCount[3];
			if(pCount[3] == false)
			{
				text[2].GetComponent<Text>().text  = " Press Right Bumper";
			}
			if(pCount[3] == true)
			{
				text[2].GetComponent<Text>().text  = " Ready ";
			}
			
		}
	}

	void Awake () 
	{
		DontDestroyOnLoad (transform.gameObject);
	}
	

	void Start () 
	{
        players  = new GameObject[4];
		pCount = new bool[maxPCount];
		firstcall = true;
		check = false;
		PSpawn = new Vector2[4];
		lifes = new int[4];
		lifes[0]= 0;
		lifes[1]= 0;
		lifes[2]= 0;
		lifes[3]= 0;
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
			life = GameObject.FindGameObjectsWithTag("Text");

			if (check == false) {
				for (int i =0; i<4; i++) {
					if (pCount [i] == true) {
						if (i == 0) {
							players [0] = (GameObject)Instantiate (player1);
							players[0].name = "P1";
							PSpawn[0] = players[0].transform.position;
						}
						if (i == 1) {
							players [1] = (GameObject)Instantiate (player2);
							players[1].name = "P2";
							PSpawn[1] = players[1].transform.position;
						}
						if (i == 2) {
							players [2] = (GameObject)Instantiate (player3);
							players[2].name = "P3";
							PSpawn[2] = players[2].transform.position;
						}
						if (i == 3) {
							players [3] = (GameObject)Instantiate (player4);
							players[3].name = "P4";
							PSpawn[3] = players[3].transform.position;
						}
					}
				}
				check = true;
			}

		}
	}


	public void playerDead(string name)
	{

		if (name.Equals ("P1") && lifes [0] < 3) {
			players [0].SetActive (true);
			players [0].GetComponent<PlayerMovement> ().enabled = true;
			players [0].transform.position = PSpawn [0];
			lifes [0]++;

			life [3].GetComponent<Text> ().text = ((3 - lifes [0]).ToString ()); //3


		} else if (pCount [0] == false) 
		{
			lifes[0]++;
		}
		if (name.Equals ("P2") && lifes [1] < 3 ) {
			players [1].SetActive (true);
			players [1].GetComponent<PlayerMovement2> ().enabled = true;
			players [1].transform.position = PSpawn [1];
			lifes [1]++;

			life [0].GetComponent<Text> ().text = ((3 - lifes [1]).ToString ());//0
		}
		else if(pCount [1] == false)
			{
			lifes[1]++;
			}

		 if (name.Equals ("P3") && lifes [2] < 3 ) {
			players [2].SetActive (true);
			players [2].GetComponent<PlayerMovement3> ().enabled = true;
			players [2].transform.position = PSpawn [2];
			lifes [2]++;

			life [2].GetComponent<Text> ().text = ((3 - lifes [2]).ToString ());//2

		}
		else if(pCount [2] == false)
		{
			lifes[2]++;
		}
		if (name.Equals ("P4") && lifes [3] < 3 ) {
			players [3].SetActive (true);
			players [3].GetComponent<PlayerMovement4> ().enabled = true;
			players [3].transform.position = PSpawn [3];
			lifes [3]++;
			life [1].GetComponent<Text> ().text = ((3 - lifes [3]).ToString ());//1
		} 
		else if(pCount [3] == false)
		{
			lifes[3]++;
		}
		if(lifes[0] >= 3 && lifes[1] >= 3 && lifes[2] >= 3 && lifes[3] >= 3)
		{
			Application.LoadLevel ("Menu");
		}

	}


	public bool[] playerCheck()
	{

		bool[] pStats = new bool[maxPCount+1];
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
	public int[] lifeCheck()
	{
		return lifes;
	}
}
