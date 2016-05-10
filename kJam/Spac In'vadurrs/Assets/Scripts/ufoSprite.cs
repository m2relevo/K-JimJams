using UnityEngine;
using System.Collections;

public class ufoSprite : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2; 	 
	
	public SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		spriteRenderer.sprite = sprite1; 
	}
	
	public void ChangeSprite(bool hit)
	{
		if (hit==true) 
		{
            Debug.Log("BLACKKKKKKKKKKKKKKKKKK");
            spriteRenderer.sprite = sprite2;
		} 
		if (hit==false) 
		{
            Debug.Log("GREEEEEEEEEEEEEEEEEEEEEN");
			spriteRenderer.sprite = sprite1;
		}
	}
}