using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet
{
	//override parent class to remove gravity effect
	public override void InitBullet()
	{
		deltaY        = 0;
		bulletGravity = 0;
		base.InitBullet ();
	}

	public override void OnTriggerEnter (Collider collider)
	{
		if (   collider.name == CollidableObject.Player.AsText() 
		    || collider.name == CollidableObject.Shield.AsText())
		{
			Health a = collider.gameObject.GetComponent<Health>();
			if (a != null)
				a.Modify(-dmg);
			
			SelfDestruct();
		}
	}
}
