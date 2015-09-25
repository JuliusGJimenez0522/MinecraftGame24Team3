using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour 
{
	// I wonder if I can get it to just scroll up and down between 1 and 9, which would allow us to generate if statement conditions when slots equals a specific number...
	public float slots = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		slots = Input.GetAxis("Mouse ScrollWheel");
		if (slots > 0f)
		{
			// scroll up
			print ("up");
		}
		else if (slots < 0f)
		{
			// scroll down
			print ("down");
		}


	}
}
