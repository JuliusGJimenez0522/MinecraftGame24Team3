using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {



	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Walls")
		{
			transform.parent.gameObject.GetComponent<PlayerController>().grounded = true;  
		}
	}
	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Walls")
		{
			transform.parent.gameObject.GetComponent<PlayerController>().grounded = true;  
		}
	}

}
