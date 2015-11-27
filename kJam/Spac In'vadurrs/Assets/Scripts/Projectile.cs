using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	float speed;


	// Use this for initialization
	void Start ()
	{	
		speed = 2f;
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
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "enemy") 
		{
			Destroy(col.gameObject);
		}
	}
}