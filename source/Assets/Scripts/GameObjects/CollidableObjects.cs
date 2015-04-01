using UnityEngine;
using System.Collections;

public enum CollidableObject {Player, Enemy, Platform , Shield};

public static class CollidableObjects 
{
	public static string AsText(this CollidableObject obj) 
	{
		switch (obj) 
		{
		case CollidableObject.Player: return "player";
		case CollidableObject.Enemy: return "enemy";
		case CollidableObject.Platform: return "platform";
		case CollidableObject.Shield: return "shield";
		default: return "empty";
		}
	}
}
