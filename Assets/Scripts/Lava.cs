using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float force = 15;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
           rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
           
           Lifes lifes = FindObjectOfType<Lifes>();
           lifes.NumberLive--;
        }
    }
}
