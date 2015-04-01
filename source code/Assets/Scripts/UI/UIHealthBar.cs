using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class UIHealthBar : MonoBehaviour
{
	public Rect rectangle = new Rect(0, 0, 50, 4);
	public Vector2 offset = new Vector2(-25, -25);
	
	Texture2D background;
	Texture2D foreground;
	
	Health health;

	// Use this for initialization
	void Start ()
	{
		// Use 1x1 pixels to draw the health bars
		background = new Texture2D(1,1);
		background.SetPixel(0,0, Color.red);
		background.Apply();
		foreground = new Texture2D(1,1);
		foreground.SetPixel(0,0, Color.green);
		foreground.Apply();
		
		health = GetComponent<Health>();
	}
	
	void OnGUI ()
	{
		rectangle.x = Camera.main.WorldToScreenPoint(transform.position).x + offset.x;
		rectangle.y = Screen.height - Camera.main.WorldToScreenPoint(transform.position).y + offset.y;
			
		GUI.DrawTexture(rectangle, background);
		
		Rect partialRect = rectangle;
		partialRect.width = rectangle.width * (health.FractionHP);
		partialRect.x = rectangle.x;
		
		GUI.DrawTexture(partialRect, foreground);
	}
}
