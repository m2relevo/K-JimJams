using UnityEngine;
using System.Collections;

public class baseSprite : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2; 
	public Sprite sprite3; 
	public Sprite sprite4; 

	private SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		spriteRenderer.sprite = sprite1; 
	}

	public void ChangeSprite()
	{
		if (spriteRenderer.sprite == sprite1) { 
			spriteRenderer.sprite = sprite2;
		} else if (spriteRenderer.sprite == sprite2) {
			spriteRenderer.sprite = sprite3; 
		} else if (spriteRenderer.sprite == sprite3) {
			spriteRenderer.sprite = sprite4;
		} else {
			Destroy(transform.parent.gameObject);
		}
	}
}