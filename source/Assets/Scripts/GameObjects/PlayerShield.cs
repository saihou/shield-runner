using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour 
{
	private BoxCollider child;
	private PlayerMovement movementScript;
	private PlayerShoot shootScript;
	private GameObject canvas;
	private Animator anim;
	private bool canShield = true;

	//set in Unity
	public int ammo = 3;

	// Use this for initialization
	void Start () 
	{
		child          = gameObject.GetComponentsInChildren<BoxCollider>(true)[0];
		movementScript = gameObject.GetComponentInParent<PlayerMovement>();
		shootScript    = gameObject.GetComponentInParent<PlayerShoot>();
		canvas         = GameObject.Find ("Canvas");
		anim           = canvas.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canShield)
		{
			//player holds down ctrl btn
			if (Input.GetKey (KeyCode.LeftControl))
			{
				//activate shield!
				ActivateShield ();
				DisableShooting ();
			}
			//player releases ctrl btn
			else if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				UpdateAmmo();
			}
			//player doesn't press ctrl btn
			else
			{
				DeactivateShield();
			}
		}
		//ran out of ammo
		else 
		{
			//alert player if he tries to use shield when out of ammo
			if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				anim.SetTrigger("OutOfAmmo");
			}

			DeactivateShield();
		}
	}

	void ActivateShield ()
	{
		child.gameObject.SetActive (true);
		int dir = GetFaceDirection ();
		child.gameObject.transform.localPosition = new Vector3 ((float) dir, 0.0f, 0.0f);
	}

	void DisableShooting ()
	{
		shootScript.disableShooting ();
	}

	void UpdateAmmo()
	{
		if (Input.GetKeyUp (KeyCode.LeftControl))
		{
			--ammo;
			if (ammo <= 0)
			{
				canShield = false;
			}
		}
	}

	void DeactivateShield ()
	{
		child.gameObject.SetActive (false);
	}

	int GetFaceDirection()
	{
		return movementScript.getFace();
	}

	public int GetAmmo()
	{
		return ammo;
	}
}
