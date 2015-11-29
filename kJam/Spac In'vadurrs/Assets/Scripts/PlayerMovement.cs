using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
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

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction);
	}

	void Move (Vector2 direction)
	{
		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("joystick button 4")) //&& limit == false
		{
			if(limit==false)
			    {
			        limit=true;
			        GameObject Projectile = (GameObject)Instantiate (Bullet);
			        Projectile.GetComponent<Projectile>().SetPPT ();
			        Projectile.transform.position = Projectileposition.transform.position;
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
