using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;
	bool PP = true; // Player projectile too check if shot by enemy or player
	public PlayerMovement PM;
	public baseSprite BS;

	// Use this for initialization
	void Start ()
	{	
		speed = 2f;
		PM = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
		//BS = GameObject.FindGameObjectWithTag("PixelEffect").GetComponent<baseSprite> ();
	}

	public void SetPPT()
	{
		PP = true;
	}
	public void SetPPF()
	{
		PP = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{


		if (col.gameObject.tag == "enemy") 
		{
		   if(PP == true)
			{
			 Debug.Log("ENEMY HIT");
			 Destroy(col.gameObject);
			 Destroy(this.gameObject);
			 PM.bulletDead ();
			}
		}
		if (col.gameObject.tag == "home_base") {
			Debug.Log ("HIT BASE");
			//FOR GEORGE: CALL PIXELEFFECT DO NOT CHILD CALL
			Destroy (col.gameObject);
			Destroy (this.gameObject);
			PM.bulletDead ();		
		}
		if (col.gameObject.tag == "Player") 
		{
			if(PP == false)
			{
				Debug.Log("PLAYER HIT");
				//loose life or loose game
			}
		}
	}


	// Update is called once per frame
	void Update ()
	{
	
		Vector2 position = transform.position;

		position = new Vector2(position.x,position.y+speed*Time.deltaTime);
		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (-1, -1));

		Debug.Log ("Shots fired!");

		if (transform.position.y > max.y)
		{
			Destroy (gameObject);
			Debug.Log ("Bullet Despawned");
			PM.bulletDead ();
		}
		//if (transform.position.y > min.y)
		//{
		//	Destroy (gameObject);
		//	Debug.Log ("Bullet Despawned");
		//}
	}




}