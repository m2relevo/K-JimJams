using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;
	bool PP = true; // Player projectile too check if shot by enemy or player
	public PlayerMovement PM;
	public PlayerMovement2 PM2;
	public PlayerMovement3 PM3; 
	public PlayerMovement4 PM4;
	public baseSprite BS;
	public ProjectileManager Man;
	public PlayerManager PMan;
	int ProVal;
	Vector3 startPos;
	bool UporDown;

	// Use this for initialization
	void Start ()
	{	
		speed = 2f;
		Man = GameObject.Find("Manager").GetComponent<ProjectileManager>();
		PMan = GameObject.Find("Manager").GetComponent<PlayerManager>();
		bool[] pCheck = new bool[PMan.maxPCount];
		pCheck = PMan.playerCheck ();
		UporDown = Man.checkView();
		if(pCheck[0] == true)
		PM = GameObject.Find("Player(Clone)").GetComponent<PlayerMovement>();
		if(pCheck[1] == true)
		PM2 = GameObject.Find("Player 2(Clone)").GetComponent<PlayerMovement2>();
		if(pCheck[2] == true)
		PM3 = GameObject.Find("Player 3(Clone)").GetComponent<PlayerMovement3>();
		if(pCheck[3] == true)
		PM4 = GameObject.Find("Player 4(Clone)").GetComponent<PlayerMovement4>();
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
			 if(this.gameObject.name == "1")
			     PM.bulletDead ();
			 if(this.gameObject.name == "2")
				 PM2.bulletDead ();
			 if(this.gameObject.name == "3")
				 PM3.bulletDead ();
			 if(this.gameObject.name == "4")
				 PM4.bulletDead ();

			 Debug.Log("ENEMY HIT");
			 Destroy(col.gameObject);
			 Destroy(this.gameObject);
			}
		}
		if (col.gameObject.tag == "PixelEffect") 
		{
			if(this.gameObject.name == "1")
				PM.bulletDead ();
			if(this.gameObject.name == "2")
				PM2.bulletDead ();
			if(this.gameObject.name == "3")
				PM3.bulletDead ();
			if(this.gameObject.name == "4")
				PM4.bulletDead ();

			if(PP == false)
			{
			 Man.setDead(this.gameObject);
			}

			//col.GetComponent<ProjectileManager>().setDead(this.gameObject);
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
			if(this.name =="1" || this.name == "3")
			{
			position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
			}
			else
			{
				position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
			}
			transform.position = position;
		}
		if (PP == false) 
		{
			Debug.Log ("I am enemy bullet");
			Vector2 Eposition = transform.position;


			if(UporDown == false)
			{
			Eposition = new Vector2 (Eposition.x, Eposition.y - speed * Time.deltaTime);
			this.transform.position = Eposition;
			}
			else
			{
			 Eposition = new Vector2 (Eposition.x, Eposition.y + speed * Time.deltaTime);
			 this.transform.position = Eposition;
			}

		}
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//Debug.Log ("Shots fired!");

		if (transform.position.y > max.y)
		{

			//if(ProMan!=null)
			if(PP == false)
			{
			Man.setDead(this.gameObject);
			}
			else
			if(this.gameObject.name == "1")
				PM.bulletDead ();
			if(this.gameObject.name == "2")
				PM2.bulletDead ();
			if(this.gameObject.name == "3")
				PM3.bulletDead ();
			if(this.gameObject.name == "4")
				PM4.bulletDead ();
			Destroy (this.gameObject);
			Debug.Log ("Bullet Despawned");
		
		}
		if (transform.position.y < min.y)
		{
			if(PP == false)
			{
			 Man.setDead (this.gameObject);
			}
			if(this.gameObject.name == "1")
				PM.bulletDead ();
			if(this.gameObject.name == "2")
				PM2.bulletDead ();
			if(this.gameObject.name == "3")
				PM3.bulletDead ();
			if(this.gameObject.name == "4")
				PM4.bulletDead ();
			Destroy (this.gameObject);
			Debug.Log ("Bullet Despawned");
		}
	}




}