using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
            
        }
    }
}
