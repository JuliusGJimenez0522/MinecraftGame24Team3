using UnityEngine;
using System.Collections;

public class CubeInstantiation : MonoBehaviour 
{
	RaycastHit hit;
	Ray ray;
	Vector3 hitLocation;
	GameObject selectedObject;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) 
			{
				hitLocation = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				Instantiate (selectedObject, hitLocation, Quaternion.identity);
			
			}
		}
	}
}
