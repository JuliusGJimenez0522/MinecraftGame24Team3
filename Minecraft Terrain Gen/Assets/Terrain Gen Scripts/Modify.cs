﻿using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{
    //A small script that attaches to the camera and allows the player to modify the terrian via raycast in conjunction with the terrain script.
    //Comes with controls for rotating and moving the camera  with the mouse and wasd for demo purposes, but we cant really use them for the project cuase I don't understand how the hell it works lol...
    Vector2 rot;

    void Update()
    {
        //With this we can finish the game. All we have to do is add the functionality to change what it sets the block its targeting to depending on what is selected in the inventory
        // We can also add controls to make certain blocks break or not depending on what tool is used, similar to real minecraft (but not quite)
        //We can probably even add health to the blocks if we really wanted to which really would be similar to real minecraft but might be a pain to do...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 7))
            {
				Debug.DrawRay(transform.position, transform.forward, Color.red);
				print (hit.collider.);
                EditTerrain.SetBlock(hit, new BlockAir());
            }
        }
// demo camera controller, very little idea how it works :/ Like, where the hell does the wasd input come from???
        rot = new Vector2(
            rot.x + Input.GetAxis("Mouse X") * 3,
            rot.y + Input.GetAxis("Mouse Y") * 3);

        transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);

        transform.position += transform.forward * 3 * Input.GetAxis("Vertical");
        transform.position += transform.right * 3 * Input.GetAxis("Horizontal");
    }
}