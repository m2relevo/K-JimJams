using UnityEngine;
using System.Collections;

public class InvaderMovement: MonoBehaviour {

	public float speed = 30f; //block movement
	public float downspeed = 40f; //downwards block translation
	private int direction = 0; //used as a switch for direction
	private int right = 0;//used to control distance moved to the right
	private int left = 0; //used to control distance moved to the left

	// Use this for initialization
	void Start () {
		StartCoroutine (ConstantMove ()); //creates coroutine for delay between enemy movement
	}

	
	void MoveLeft() //controls left movement. Moves 5 spaces before resetting the right movement counter and swapping the direction switch to 2
	{
		if (left < 6) 
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
			left++;
		}

		if (left == 6)
		{

			right = 0;
			direction = 2;

		}
	}
	
	void MoveRight () //controls right movement. Moves 5 spaces before resetting the left movement counter and swapping the direction switch to 3
	{
		if (right < 6) 
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			right++;
		}

		if (right == 6) 
		{

			left = 0;
			direction = 3;

		}
	}

	void MoveDown () //code to move all blocks down a row
	{
		transform.position += Vector3.down * downspeed * Time.deltaTime;
	}


	IEnumerator ConstantMove(){ //IEnumerator that is responsible for moving the invaders with a slight delay between steps. Controls the direction switches
		while (true) 
		{
			while (direction == 0) //direction switch for right movement
			{
				MoveRight ();
				yield return new WaitForSeconds (1);
			}

			while (direction == 1) //direction switch for left movement
			{
				MoveLeft ();
				yield return new WaitForSeconds (1);
			}

			while (direction == 2) //direction switch for a downward movement, then swaps the blocks to move right
			{
				MoveDown ();
				yield return new WaitForSeconds (1); 
				direction = 0;

			}
			while (direction == 3)//direction switch for a downward movement, then swaps blocks to move left
			{
			MoveDown ();
			yield return new WaitForSeconds (1);
				direction = 1;
			}
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		ConstantMove();
	}


}
