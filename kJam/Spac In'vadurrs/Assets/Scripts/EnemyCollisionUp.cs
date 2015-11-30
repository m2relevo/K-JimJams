using UnityEngine;
using System.Collections;

public class EnemyCollisionUp : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mincamera = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 maxcamera = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		GameObject newDirUp = GameObject.Find ("MovementControllerUp");//code for editing the direction variable from the move controller during enemy collision 
		InvaderMovementUp movementscriptup = newDirUp.GetComponent<InvaderMovementUp> ();
		int directioncontrolup = movementscriptup.directionup;
		
		
		
		
		if (directioncontrolup == 0) 
		{
			if ((transform.position.x + 1) >= maxcamera.x) {
				
				movementscriptup.directionup = 3; 
				directioncontrolup = movementscriptup.directionup;
			}
		}
		
		if (directioncontrolup == 1) 
		{
			if ((transform.position.x - 1) <= mincamera.x)
			{
				movementscriptup.directionup = 2; 
				directioncontrolup = movementscriptup.directionup;
			}
		}
	}
}
