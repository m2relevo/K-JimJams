using UnityEngine;
using System.Collections;

public class ufoSprite : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2; 	 
	
	private SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		spriteRenderer.sprite = sprite1; 
	}
	
	public void ChangeSprite()
	{
		if (spriteRenderer.sprite == sprite1) 
		{ 
			spriteRenderer.sprite = sprite2;
		} else if (spriteRenderer.sprite == sprite2) 
		{
			spriteRenderer.sprite = sprite1;
		}
	}
}