﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float speed = 5.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet") 
		{
			Destroy (gameObject);
		}
	}
}
