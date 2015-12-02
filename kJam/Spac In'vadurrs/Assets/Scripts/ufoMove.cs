using UnityEngine;
using System.Collections;

public class ufoMove : MonoBehaviour {

	Vector2 maxCam;
	Vector2 minCam;
	float speed = 3f;

	public GameObject leftBox;
	public GameObject rightBox;
	public Vector2 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
		maxCam = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		minCam = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		setStuff ();
	}
	
	// Update is called once per frame
	void Update () {
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		transform.position = position;
	}

	void setStuff()
	{
		leftBox.transform.position = new Vector3(minCam.x, gameObject.transform.position.y, 1);
		rightBox.transform.position = new Vector3(maxCam.x, gameObject.transform.position.y, 1);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "rightBox") 
		{
			speed = -3f;
		}
		if (col.gameObject.tag == "leftBox") 
		{
			speed = 3f;
		}
	}
}
