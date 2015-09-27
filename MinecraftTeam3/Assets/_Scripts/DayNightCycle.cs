using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour 
{
	//NOTES:
	// This script attaches to the light source.
	//This script can probably be merged with whatever game manager you guys come up with, but if not then attached to the light it won't work unless the code is rewriten to point at the rotation component of light.
	//the spawn system needs to look at the isNight variable if done with a seperate script.


	//CONTROLING DAYLENGTH:
	// the lower the variable daylenght is set, the faster the sun goes round. 0.1 is probably good for demo purposes.

	//Lighting controls

	public float dayLength = 0.0f;
	public float rotationSpeed = 0.0f;

	//For spawning mobs
	public bool isNight = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		// This makes the light spin round and controls the day/night cycle
		rotationSpeed = Time.deltaTime / dayLength;
		
		transform.Rotate( rotationSpeed, 0 ,0);


		// For spawning mobs
		if( transform.eulerAngles.x >= 270 )
		{
			// spawn enemies!
			isNight = true;
		}

		else
		{
			// spawn animals!
			isNight = false;
		}

	}
}
