using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour 
{

	public GameObject prefabBullet;
	//set in Unity Editor
	public float range = 20.0f;

	private GameObject player;
	private string faceDirection = "left";
	private float speed          = 5.0f;
	//variable that controls cooldown
	private bool canShoot        = true;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//makes enemy face the player at all times
		UpdateFaceDirection();

		if (isPlayerInRange())
		{
			Shoot();
		}
	}

	bool isPlayerInRange()
	{
		bool inRange = false;
		int dir      = GetFaceDirection();

		//cast a ray directly in front of the enemy (depending on his face)
		Ray ray = new Ray(transform.position, new Vector3(dir, 0.0f, 0.0f));
		RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, range);
		//Debug.DrawRay (ray.origin, ray.direction * range);

		//is the player one of the GameObjects directly in front of the enemy??
		for (int i = 0 ; i < hits.Length ; i++) 
		{
			RaycastHit hit = hits[i];
			if (hit.collider.name == CollidableObject.Player.AsText())
			{
				//yes!
				inRange = true;
				break;
			} 
			else
			{
				//nope, did not hit player. continue looping through the hits
				inRange = false;
			}
		}
		return inRange;
	}

	void UpdateFaceDirection()
	{
		if (player != null)
		{
			float playerX = player.transform.position.x;
			float selfX   = gameObject.transform.position.x;
			
			//always face the player
			faceDirection = ((playerX <= selfX) ? "left" : "right");
		}
	}

	void Shoot()
	{
		if (canShoot)
		{
			GameObject bullet        = Instantiate(prefabBullet, transform.position, transform.rotation) as GameObject;
			EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
			
			//shoot bullet depending on which direction I am currently facing
			int dir  = GetFaceDirection();
			bulletScript.SetBulletSpeed(speed * dir);
			canShoot = false;
		}
	}

	public void resetCooldown()
	{
		canShoot = true;
	}

	//helper method
	//returns 1 if facing right, returns -1 otherwise
	int GetFaceDirection()
	{
		return ((faceDirection == "right") ? 1 : -1);
	}

	//helper method 
	//returns true if on cooldown, false otherwise
	public bool GetCooldownStatus()
	{
		return !canShoot;
	}
}
