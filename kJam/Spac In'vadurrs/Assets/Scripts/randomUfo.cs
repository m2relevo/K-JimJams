using UnityEngine;
using System.Collections;

public class randomUfo : MonoBehaviour {

	Vector2 maxCam;
	Vector2 minCam;
	float speed = 1f;

	public GameObject leftBox;
	public GameObject rightBox;
	public Vector2 position;

	bool timerDone = false;
	float t= Time.time;
	float ellapsed;
	int randomTime; 
	public ufoSprite UFOSp;

	// Use this for initialization
	void Start () {
		position = transform.position;
		maxCam = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		minCam = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		timerDone = false;
		UFOSp = GameObject.Find("UFO").GetComponent<ufoSprite>();
		setStuff ();
	}
	
	// Update is called once per frame
	void Update () {
		ellapsed=Time.time-t;
		Debug.Log (ellapsed);

		if (ellapsed >= randomTime) {
			timerDone = true;
			moveUfo ();
		}
	}

	void setStuff()
	{
		leftBox.transform.position = new Vector3(minCam.x -2, gameObject.transform.position.y, 1);
		rightBox.transform.position = new Vector3(maxCam.x +2, gameObject.transform.position.y, 1);
		position = new Vector2 (minCam.x -1, gameObject.transform.position.y);
		transform.position = position;
		randomTime = Random.Range(10,15);
	}

	void moveUfo()
	{
		if (timerDone == true) {
			position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
			transform.position = position;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "rightBox") 
		{	
			timerDone = false;
			//col.GetComponent<ufoSprite>().spriteRenderer.sprite = col.GetComponent<ufoSprite>().sprite1;		
			randomTime = Random.Range(10,15);
			t = Time.time;
			speed = -1f;
		}
		if (col.gameObject.tag == "leftBox") 
		{
			timerDone = false;
			//col.GetComponent<ufoSprite>().spriteRenderer.sprite = col.GetComponent<ufoSprite>().sprite1;
			randomTime = Random.Range(10,15); 
			t = Time.time;
			speed = 1f;
		}
	}
}
