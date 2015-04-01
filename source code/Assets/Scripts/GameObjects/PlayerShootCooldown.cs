using UnityEngine;
using System.Collections;

public class PlayerShootCooldown : MonoBehaviour
{
	//set in Unity
	public  float cooldownTimer = 0.5f;

	private float timeStamp;
	private PlayerShoot shootScript;

	// Use this for initialization
	void Start ()
	{
		timeStamp   = Time.time + cooldownTimer;
		shootScript = GetComponentInParent<PlayerShoot>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (timeStamp <= Time.time)
		{
			timeStamp = Time.time + cooldownTimer;

			shootScript.resetCooldown();
		}
	}
}
