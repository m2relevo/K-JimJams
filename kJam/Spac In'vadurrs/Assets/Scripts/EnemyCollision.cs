using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mincamera = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxcamera = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject newDir = GameObject.Find ("MovementController");
		InvaderMovement movementscript = newDir.GetComponent<InvaderMovement> ();
		int directioncontrol = movementscript.direction;

		if (directioncontrol == 0) 
		{
			if (transform.position.x >= maxcamera.x) {

				movementscript.direction = 3; 
				directioncontrol = movementscript.direction;
			}
		}

		if (directioncontrol == 1) 
		{
			if (transform.position.x <= mincamera.x)
			{
				movementscript.direction = 2; 
				directioncontrol = movementscript.direction;
			}
		}
	}
}
