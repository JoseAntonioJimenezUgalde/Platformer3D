using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Controller : MonoBehaviour
{
    private Animator animControl;    // Controlador del Animator
    public float velocidadCaminar = 5f;     // Velocidad de movimiento del personaje al caminar
    public float velocidadCorrer = 10f;     // Velocidad de movimiento del personaje al correr
    [SerializeField] public float velocidadActual;   // Velocidad actual de movimiento del personaje
    public float alturaSalto = 2f;       // Altura máxima del salto
    public float tiempoSalto = 0.5f;     // Tiempo total del salto
    public float gravedad = -9.8f;       // Gravedad aplicada al personaje
    private float velocidadVertical;     // Velocidad vertical actual del personaje
    public bool enSuelo;                // Indica si el personaje está en el suelo
    private Vector3 movimiento;          // Movimiento acumulado del personaje
    private Rigidbody _rigidbody;        // Referencia al Rigibody
    public Vector3 posicionInicial;      // Posicion inicial
    [SerializeField] GameObject Panza;
    [SerializeField] private LayerMask Ground; 
    
    public float suavizado = 5f;     // Velocidad de interpolación suave

    void Start()
    {
       animControl = GetComponent<Animator>();   // Obtener referencia al componente Animator del personaje
       velocidadActual = velocidadCaminar;    // Inicializar la velocidad actual como la velocidad de caminar
       _rigidbody = GetComponent<Rigidbody>(); // Obtener referencia de mi Rigibody que tengo en mi componente
       posicionInicial = transform.position;  // Punto de referencia para el Respawn
    }


    void Update()
    {
    float movimientoHorizontal = Input.GetAxis("Horizontal");    // Obtener la entrada horizontal del teclado

    // Solo se permite movimiento horizontal
    float movimientoVertical = 0f;

    if (movimientoHorizontal != 0f || movimientoVertical != 0f)
    {

        animControl.SetBool("isMoving", true);    // Activar la animación de movimiento cuando el personaje se está moviendo

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        movimiento = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * movimiento;

        // Calcular la posición objetivo sumando el movimiento al punto actual
        Vector3 posicionObjetivo = transform.position + movimiento * velocidadActual * Time.deltaTime;
        
        // Comprobar colisión con una pared utilizando Raycast
        RaycastHit raycastHit;
        float distance = 1.1f;
        if (Physics.Raycast(Panza.transform.position, movimiento, out raycastHit, distance))
        {
            if (raycastHit.collider.CompareTag("Ground"))
            {
                Debug.DrawRay(Panza.transform.position, movimiento.normalized * distance, Color.red); // Dibujar el rayo en la direccion frontal del Player
                return; // Si se detecta una colisión con una pared, se detiene la aplicación de fuerza de movimiento
            }
        }else
        {
            Debug.DrawRay(Panza.transform.position, movimiento.normalized * distance, Color.green);
        }
        

        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, 1f);    // Mover suavemente al personaje hacia la posición objetivo

        if (movimiento != Vector3.zero)
        {
            // Calcular la rotación hacia la dirección de movimiento utilizando LookRotation
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionObjetivo, 1f);    // Girar suavemente al personaje hacia la rotación objetivo
        }
    }
    else
    {
        animControl.SetBool("isMoving", false);   // Desactivar la animación de movimiento cuando el personaje está quieto
    }

    // Salto y caída suave
    if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
    {
        velocidadVertical = Mathf.Sqrt(2f * alturaSalto * -gravedad);   // Calcular la velocidad inicial para alcanzar la altura del salto
        _rigidbody.AddForce(new Vector3(0f, velocidadVertical, 0f), ForceMode.VelocityChange);
        enSuelo = false; // Actualizar el estado del suelo a falso ya que hemos saltado
    }

    if (!enSuelo)
    {
        velocidadVertical += gravedad * Time.deltaTime;   // Aplicar gravedad al personaje
        
        // Interpolación suave de la posición vertical
        Vector3 movimientoVerticalVectorizado = new Vector3(0f, velocidadVertical, 0f);
        movimiento += movimientoVerticalVectorizado * Time.deltaTime * suavizado;

    }


    if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
    {
        animControl.SetBool("isJump", true);
    }
    else
    {
        animControl.SetBool("isJump", false);
    }

    animControl.SetFloat("yVelocity", _rigidbody.velocity.y);
    animControl.SetBool("isGround", enSuelo);

    Vector3 movimientoVerticalVector = new Vector3(0f, velocidadVertical, 0f);
    movimiento += movimientoVerticalVector;
    

    // Detectar el suelo utilizando Raycast
    RaycastHit hit;
    float raycastDistance = 0.5f; // Distancia máxima del Raycast
    if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
    {
        if (hit.collider.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }
    else
    {
        enSuelo = false;
    }
    Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.blue);

    if (Input.GetKey(KeyCode.LeftShift))
    {
        animControl.SetBool("runButton", true);   // Activar la animación de carrera cuando se mantiene presionado el botón de correr
        velocidadActual = velocidadCorrer;    // Actualizar la velocidad actual a la velocidad de correr
    }
    else
    {
        animControl.SetBool("runButton", false);  // Desactivar la animación de carrera cuando no se mantiene presionado el botón de correr
        velocidadActual = velocidadCaminar;   // Actualizar la velocidad actual a la velocidad de caminar
    }
    
    }


    public void ResetPosition()
    {
       transform.position = posicionInicial;
    }

}

