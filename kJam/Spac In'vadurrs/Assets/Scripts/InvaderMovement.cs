using UnityEngine;
using System.Collections;

public class InvaderMovement: MonoBehaviour {

	public float speed = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		/*if (Input.GetKeyDown(KeyCode.RightArrow))
		{ 
			transform.position += Vector3.right * speed * Time.deltaTime;
		}*/
	}
}
