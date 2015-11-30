using UnityEngine;
using System.Collections;

public class SplitMovement : MonoBehaviour
{
	public float speed;
	public GameObject Bullet;
	public GameObject Projectileposition;
	public bool limit = false;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{	
		if (GameObject.Find ("Player") != null)
		{
			float x = Input.GetAxisRaw ("Horizontal_1");
			float y = Input.GetAxisRaw ("Vertical_1");
			Vector2 direction = new Vector2 (x, y).normalized;

			Move (direction);
			Debug.Log ("Ready Player 1");
		}

		if (GameObject.Find ("Player2") != null)
		{
			float x = Input.GetAxisRaw ("Horizontal_2");
			float y = Input.GetAxisRaw ("Vertical_2");
			Vector2 direction = new Vector2 (x, y).normalized;

			Move2 (direction);
			Debug.Log ("Ready Player 2");
		}
	}

	//player1 movement
	void Move (Vector2 direction)
	{
		if (Input.GetKeyDown ("joystick 1 button 4")) //&& limit == false
		{
			if(limit==false)
			    {
			        limit=true;
			        GameObject Projectile = (GameObject)Instantiate (Bullet);
			        Projectile.GetComponent<Projectile>().SetPPT ();
			        Projectile.transform.position = Projectileposition.transform.position;
					Debug.Log ("Player 1 says 'Torpedos Away'");
			    }
			/*limit = true;*/
		}


		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);

		transform.position = pos;
	}

	//player2 movement
	void Move2 (Vector2 direction)
	{
		if (Input.GetKeyDown ("joystick 1 button 5")) //&& limit == false
		{
			if(limit==false)
			{
				limit=true;
				GameObject Projectile = (GameObject)Instantiate (Bullet);
				Projectile.GetComponent<Projectile>().SetPPT ();
				Projectile.transform.position = Projectileposition.transform.position;
				Debug.Log ("Player 2 says 'Torpedos Away'");
			}
			/*limit = true;*/
		}
		
		
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;
		
		Vector2 pos = transform.position;
		
		pos += direction * speed * Time.deltaTime;
		
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		
		transform.position = pos;
	}

	public void bulletDead()
	{
		limit = false;
	}
}
