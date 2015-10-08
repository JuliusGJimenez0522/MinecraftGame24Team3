using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float speed = 2.0f;
	public int startingHealth = 3;
	public int currentHealth;
	public GameObject hunted = null;
	//public Transform;
	
	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) 
		{	
			Destroy (gameObject);
		}
	}
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject)
		{
			hunted = other.gameObject;
			transform.LookAt (hunted.transform);
			transform.position = Vector3.Lerp (transform.position, hunted.transform.position, Mathf.SmoothStep (0.0f, speed, Time.deltaTime));
		}
		
	
	}
	void OnTriggerExit (Collider other)
	{
		hunted = null;
	}
	}