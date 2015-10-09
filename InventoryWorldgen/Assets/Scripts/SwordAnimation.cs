using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour
{
	public Animation _swordAnimation = null;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void swordSwing()
    {
        _swordAnimation.Play();
    }
}
