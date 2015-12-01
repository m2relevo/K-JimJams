using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {


	struct ProjectileStruct
	{
		public GameObject shot;
		public bool alive;
	};
	static int maxNumProjectiles = 3;
    ProjectileStruct[] Projectiles;
	public GameObject missile;
	GameObject[] enemies;
	bool noFire = false;
	int Ran;


	// Use this for initialization
	void Start () 
	{

		enemies = GameObject.FindGameObjectsWithTag("enemy");


		if(enemies.Length > 0)
		{
		//array of projectiles initialized
		Projectiles = new ProjectileStruct[maxNumProjectiles];

		for(int i = 0; i<maxNumProjectiles; i++) 
		{
			//preload the missiles 
			GameObject proj = (GameObject)Instantiate (missile);
			Projectiles[i].shot = proj;
			Projectiles[i].shot.GetComponent<Projectile>().SetPPF();
			Projectiles[i].alive = true;

		}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemies.Length > 0) {
			//Just so i dont have to type it all out each time
			if (Projectiles [0].alive == true && Projectiles [1].alive == true && Projectiles [2].alive == true) {
				noFire = true;
			} else {
				noFire = false;
			}
	   
			//all missiles in use
			if (noFire == true) {
				//add later 
				Debug.Log ("Still shooting");
			}
			//able to spawn a missile
			if (noFire == false) {
				int i = 0;
				Debug.Log ("Making new bullet");
				//pick enemy to shoot from
				int R = (Random.Range (0, (enemies.Length - 1)));
				while (i == 0) {
					if (enemies [R] != null) {
						i++;
					} else {
						R = (Random.Range (0, (enemies.Length - 1)));
					}
				}
				int resupply = projCheck ();
				if (resupply < maxNumProjectiles) {
					newMissile (resupply);  
					setView(R);
					Projectiles [resupply].shot.transform.position = enemies [R].transform.position;
				}
			}
		}
	}
	// Check which projectile is dead
	int projCheck()
	{
		Debug.Log ("whos Dead");
		for(int i = 0; i < maxNumProjectiles; i++)
		{
			if(Projectiles[i].alive == false)
				return i;
		}
		return maxNumProjectiles+1;
	}
	//instantiates new missile
	void newMissile(int supply)
	{
		Debug.Log ("Its a baby bullet");
		GameObject proj = (GameObject)Instantiate (missile);
		Projectiles[supply].shot = proj;
		Projectiles[supply].shot.GetComponent<Projectile>().SetPPF();
		Projectiles[supply].alive = true;
	}
	//sets projectile as dead
	public void setDead(GameObject obj)
	{
		for (int w = 0; w < maxNumProjectiles; w++) 
		{
			if(Projectiles[w].shot == obj)
			{
			 Debug.Log ("Ure Dead m9");
			 Projectiles [w].alive = false;
			}
		}
	}
	void setView( int selection)
	{
		Ran = selection;
	}
	public bool checkView()
	{
		if (enemies [Ran].transform.parent.transform.position.y > -2) 
		{
			return true;
		}
		else 
		{
			return false;
		}
	}
}
