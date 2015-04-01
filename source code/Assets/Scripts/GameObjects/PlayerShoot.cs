using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
	public GameObject prefabBullet;

	private PlayerMovement movementScript;

	[SerializeField]
	//set in Unity Editor
	protected float speed   = 20.0f;
	//variable that controls cooldown
	protected bool canShoot = true;

	void Start()
	{
		movementScript = gameObject.GetComponentInParent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update ()
	{
		Shoot ();
	}

	void Shoot()
	{
		if (   canShoot
		    && Input.GetKeyDown (KeyCode.Space))
		{
			GameObject bullet         = Instantiate(prefabBullet, transform.position, transform.rotation) as GameObject;
			PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();
			
			int dir = GetFaceDirection();
			bulletScript.SetBulletSpeed(speed * dir);
			canShoot = false;
		}
	}
	//returns 1 if facing right, returns -1 if facing left
	int GetFaceDirection()
	{
		return movementScript.getFace();
	}

	public void resetCooldown()
	{
		canShoot = true;
	}

	public void disableShooting()
	{
		canShoot = false;
	}
}
