using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet 
{
	public override void OnTriggerEnter (Collider collider)
	{
		if (collider.name == CollidableObject.Platform.AsText() 
		 || collider.name == CollidableObject.Enemy.AsText() )
		{
			Health a = collider.gameObject.GetComponent<Health>();
			if (a != null)
				a.Modify(-dmg);
			
			SelfDestruct();
		}
	}
}
