using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	[SerializeField]
	protected int     dmg           = 1;
	protected float   speed         = 0;
	protected float   bulletGravity = 1.0f;
	protected Vector3 projectileMotion;

	protected float deltaX = 0;
	protected float deltaY = 10.0f;

	void Start()
	{
		InitBullet ();
	}

	public virtual void InitBullet()
	{
		Invoke ("SelfDestruct", 10);
	}

	void FixedUpdate ()
	{
		deltaY          -= bulletGravity;
		projectileMotion = new Vector3(speed, deltaY, 0.0f);
		transform.Translate(projectileMotion * Time.deltaTime);
	}

	public virtual void OnTriggerEnter(Collider collider)
	{
		//to be overriden by sub classes (as each bullet exhibits different behaviour)
		Debug.Log ("Bullet.cs OnTriggerEnter Placeholder");
	}
	
	public void SelfDestruct()
	{
		Destroy (gameObject);
	}

	public void SetBulletSpeed(float spd)
	{
		speed = spd;
	}
}
