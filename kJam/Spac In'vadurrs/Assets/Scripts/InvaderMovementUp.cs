using UnityEngine;
using System.Collections;

public class InvaderMovementUp : MonoBehaviour {

	public float speed = 30f; //block movement
	public float upspeed = 40f; //downwards block translation
	public int directionup = 1; //used as a switch for direction
	public Vector2 mincamera;
	public Vector2 maxcamera;
	public float timespeed; //float for the calculation of the delay between steps the invaders take
	
	// Use this for initialization
	void Start () {
		timespeed = 1;
		StartCoroutine (ConstantMove ()); //creates coroutine for delay between enemy movement
	}
	
	
	void MoveLeft() //controls left movement. Moves constantly to the left until it detects the edge of the screen, then moves down and reverses movement
	{
		
		Vector2 mincamera = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxcamera = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		transform.position += Vector3.left * speed * Time.deltaTime;
		if (transform.position.x > mincamera.x) 
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
			
		}
		
	}
	
	void MoveRight () //controls right movement. Moves constantly to the right until it detects the edge of the screen, then moves down and reverses movement
		
	{
		Vector2 mincamera = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxcamera = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		transform.position += Vector3.right * speed * Time.deltaTime;
		if (transform.position.x < maxcamera.x) 
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			
		}
		
	}
	
	void MoveUp () //code to move all blocks down a row
	{
		transform.position += Vector3.up * upspeed * Time.deltaTime;
	}
	
	
	IEnumerator ConstantMove(){ //IEnumerator that is responsible for moving the invaders with a slight delay between steps. Controls the direction switches
		while (true) 
		{
			while (directionup == 0) //direction switch for right movement
			{
				MoveRight ();
				yield return new WaitForSeconds (timespeed);
			}
			
			while (directionup == 1) //direction switch for left movement
			{
				MoveLeft ();
				yield return new WaitForSeconds (timespeed);
			}
			
			while (directionup == 2) //direction switch for a downward movement, then swaps the blocks to move right
			{
				MoveUp ();
				yield return new WaitForSeconds (timespeed); 
				directionup = 0;
				
			}
			while (directionup == 3)//direction switch for a downward movement, then swaps blocks to move left
			{
				MoveUp ();
				yield return new WaitForSeconds (timespeed);
				directionup = 1;
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		ConstantMove();
		Vector2 mincamera = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxcamera = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (transform.position.y >= maxcamera.y)
		{
			Destroy (gameObject);
		}
	}
	
	
}