using UnityEngine;
using System.Collections;

public class InvaderMovement: MonoBehaviour {

	public float speed = 30f;
	// Use this for initialization
	void Start () {
		StartCoroutine (ConstantMove ());
	}

	
	void MoveLeft()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
	
	void MoveRight ()
	{
		transform.position += Vector3.right * speed * Time.deltaTime;
	}

	IEnumerator ConstantMove(){
		while (true) {
			MoveLeft ();
			yield return new WaitForSeconds (1);
		}
	}

	
	// Update is called once per frame
	void Update () 
	{

	}


}
