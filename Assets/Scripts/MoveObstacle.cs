using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField]private float force = 1;
    
    private float force2 = 15;

    //private float rotationSpeed = 30; // Velocidad de rotación en grados por segundo

    
    
    void LateUpdate()
    {
        transform.Translate(Vector3.right * force * Time.deltaTime);
      //  transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.up * force2, ForceMode.Impulse);
            
            Lifes lifes = FindObjectOfType<Lifes>();
            lifes.NumberLive--;
        }
    }

    
}
