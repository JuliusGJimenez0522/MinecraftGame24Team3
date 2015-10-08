using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour 
{
	public int startingHealth = 3;
	public int currentHealth;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward * Time.deltaTime * speed);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

	}
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject) 
		{
			transform.Rotate(new Vector3(0,180,0));
			Debug.Log (other.gameObject);
			transform.position = new Vector3 (0.1f, transform.position.y, transform.position.z);
		}

        if (other.gameObject.tag == "Zombie")
        {
            currentHealth = currentHealth - 1;
        }
	}


}
