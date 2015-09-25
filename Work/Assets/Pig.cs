using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour 
{
	public int startingHealth = 3;
	public int currentHealth;
	public float timer = 2.0f;
	public int Invert;
	public int Movement = 1;
	public float speedBoost = 5.0f;
	public float currentSpeed = 5.0f;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () 
	{
		Invert = 6;
		Movement = 1;
		if (currentHealth <= 0) 
		{	
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		transform.Translate (Vector3.left * Time.deltaTime * speed);

	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "Zombie") 
		{
				Movement = 1;
			GetComponent<Rigidbody>().velocity = new Vector3 (1.0f * Invert * speedBoost, 0.0f, 1.0f * speedBoost);
		}
		if (other.gameObject.tag == "Zombie") 
		{
			currentHealth--;
		}

	}


}
