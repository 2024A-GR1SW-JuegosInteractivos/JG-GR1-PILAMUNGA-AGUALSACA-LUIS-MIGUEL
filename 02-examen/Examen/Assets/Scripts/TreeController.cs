using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Player exited tree");
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Player is colliding with tree");
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Player collided with tree");
        }
    }
}
