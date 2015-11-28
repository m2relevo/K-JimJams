using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;
	public PlayerMovement PM;

	// Use this for initialization
	void Start ()
	{	
		speed = 2f;
		PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{		
		if (col.gameObject.tag == "enemy") 
		{
			Debug.Log("HIT ENEMY");
			Destroy(col.gameObject);
			Destroy(this.gameObject);
			PM.bulletDead();
		}
		else if(col.gameObject.tag == "home_base")
		{
			Debug.Log("HIT BASE");
			Destroy(col.gameObject);
			Destroy(this.gameObject);
			PM.bulletDead();
		}
	}

	// Update is called once per frame
	void Update ()
	{	
		Vector2 position = transform.position;

		position = new Vector2(position.x,position.y+speed*Time.deltaTime);
		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		Debug.Log ("Shots fired!");

		if (transform.position.y > max.y)
		{
			Destroy (gameObject);
			Debug.Log ("Bullet Despawned");
			PM.bulletDead();
		}
	}
}