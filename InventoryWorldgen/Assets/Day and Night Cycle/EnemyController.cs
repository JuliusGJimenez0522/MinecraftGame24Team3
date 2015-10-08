using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float speed = 2.0f;
	public int startingHealth = 3;
	public int currentHealth;
	public GameObject hunted = null;

    //for making it go back to a normal non sideways rotation once its done chasing something...
    public Quaternion originalRotationValue;
    float rotationResetSpeed = 1.0f;
	
    //public Transform;
	
	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;

        originalRotationValue = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) 
		{	
			Destroy (gameObject);
		}

        if (hunted == null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed); 
        }
	}
    /*
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject)
		{
			hunted = other.gameObject;
			transform.LookAt (hunted.transform);
			transform.position = Vector3.Lerp (transform.position, hunted.transform.position, Mathf.SmoothStep (0.0f, speed, Time.deltaTime));
		}
		
	
	}
    */

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pig")
        {
            hunted = other.gameObject;
            transform.LookAt(hunted.transform);
            transform.position = Vector3.Lerp(transform.position, hunted.transform.position, Mathf.SmoothStep(0.0f, speed, Time.deltaTime));
        }


    }
	void OnTriggerExit (Collider other)
	{
		hunted = null;

        
	}
	}