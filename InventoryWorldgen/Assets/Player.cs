using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Camera camera;
	//needs to be integrated with scroll wheel / player controller
	public GameObject selectedCube;

	void Start () 
	{
		camera = this.gameObject.GetComponent<Camera> ();
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray  = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				Instantiate(selectedCube, hit.normal + hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
			}
		}
	}
}
