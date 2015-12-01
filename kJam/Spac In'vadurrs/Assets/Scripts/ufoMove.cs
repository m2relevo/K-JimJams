using UnityEngine;
using System.Collections;

public class ufoMove : MonoBehaviour {

	Vector3 max = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 1));
	Vector3 min = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
	float speed = 0.01f;
	bool moveLeft = false;

	public GameObject leftBox;
	public GameObject rightBox;

	// Use this for initialization
	void Start () {
		leftBox = GameObject.FindWithTag ("leftBox");
		rightBox = GameObject.FindWithTag ("rightBox");

		leftBox.transform.position = new Vector3(min.x, (max.y/2), 1);
		rightBox.transform.position = new Vector3(max.x, (max.y/2), 1);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		transform.position = position;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "rightBox") 
		{
			speed = -0.01f;
		}
		if (col.gameObject.tag == "leftBox") 
		{
			speed = 0.01f;
		}
	}

}
