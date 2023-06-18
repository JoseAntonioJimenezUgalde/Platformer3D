using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotate : MonoBehaviour
{
    [SerializeField]private float rotationSpeed = 30; // Velocidad de rotación en grados por segundo

                                            
    void LateUpdate()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
    
    
}
