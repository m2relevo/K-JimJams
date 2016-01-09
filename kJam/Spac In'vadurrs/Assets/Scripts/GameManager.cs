using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	GameObject[] enemies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int check = 1;
		enemies = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < enemies.Length; i++) 
		{
			if(enemies[i] == null)
			{
				check++;
			}
		}
		if (check == enemies.Length) 
		{
			Application.LoadLevel("Menu");
		}
	
	}
}
