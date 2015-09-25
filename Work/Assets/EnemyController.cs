using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public float speed = 2.0f;
	public int startingHealth = 4;
	public int currentHealth;
	public float timer = 0.0f;
	
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
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Pig")
		{
			other.GetComponent<Pig>().currentHealth--;
		}
		
	
		}
	}