using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;
	bool PP = true; // Player projectile too check if shot by enemy or player
	public PlayerMovement PM;
	public baseSprite BS;
	public ProjectileManager Man;
	int ProVal;

	// Use this for initialization
	void Start ()
	{	
		speed = 2f;
		PM = GameObject.Find ("Player").GetComponent<PlayerMovement>();
		Man = GameObject.Find("Manager").GetComponent<ProjectileManager>();
	}
	// Is a player projectile
	public void SetPPT()
	{
		PP = true;
	}
	//isnt a player projectile
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
			 PM.bulletDead ();
			 Debug.Log("ENEMY HIT");
			 Destroy(col.gameObject);
			 Destroy(this.gameObject);
			}
		}
		if (col.gameObject.tag == "PixelEffect") 
		{
				PM.bulletDead ();
			col.GetComponent<ProjectileManager>().setDead(this.gameObject);
			Debug.Log ("HIT BASE");
			col.GetComponent<baseSprite>().ChangeSprite();
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Player") 
		{
			if(PP == false)
			{
				Debug.Log("PLAYER HIT");
				Destroy (col.gameObject);
				Destroy(this.gameObject);
			}
		}
	}


	// Update is called once per frame
	void Update ()
	{
	
		if (PP == true) 
		{

			Debug.Log ("I am player Bullet");
			Vector2 position = transform.position;

			position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
			transform.position = position;
		}
		if (PP == false) 
		{
			Debug.Log ("I am enemy bullet");
			Vector2 Eposition = transform.position;

			Eposition = new Vector2 (Eposition.x, Eposition.y - speed * Time.deltaTime);
			transform.position = Eposition;

		}
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Debug.Log ("Shots fired!");

		if (transform.position.y > max.y)
		{
			//if(PM != null)
				PM.bulletDead ();
			//if(ProMan!=null)
			Man.setDead(this.gameObject);
			Destroy (gameObject);
			Debug.Log ("Bullet Despawned");
		
		}
		if (transform.position.y < min.y)
		{
			Man.setDead (this.gameObject);
			Destroy (this.gameObject);
			Debug.Log ("Bullet Despawned");
		}
	}




}