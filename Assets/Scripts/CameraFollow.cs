using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Referencia al transform del personaje que la cámara debe seguir
    public float smoothSpeed = 0.125f;    // Velocidad de suavizado de movimiento de la cámara
    public Vector3 offset;          // Desplazamiento relativo de la cámara con respecto al personaje

    void LateUpdate()
    {
        // Calcular la posición objetivo sumando el desplazamiento relativo al transform del personaje
        Vector3 targetPosition = player.position + offset;
        // Calcular la posición suavizada mediante interpolación lineal
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        // Actualizar la posición de la cámara
        transform.position = smoothedPosition;
    }
}
