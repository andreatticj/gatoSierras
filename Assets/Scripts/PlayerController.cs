using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaración de variables privadas:
    Rigidbody2D rb; // Referencia al componente Rigidbody2D del jugador
    SpriteRenderer sr; // Referencia al componente SpriteRenderer del jugador

    [SerializeField]
    float velocidad = 4f; // Velocidad de movimiento del jugador (configurable desde el Inspector)

    // Método llamado al inicializar el script
    private void Awake()
    {
        // Asigna el componente Rigidbody2D del GameObject a la variable 'rb'
        rb = GetComponent<Rigidbody2D>();
        // Asigna el componente SpriteRenderer del GameObject a la variable 'sr'
        sr = GetComponent<SpriteRenderer>();
    }

    // Método que se ejecuta en intervalos fijos de tiempo (recomendado para físicas)
    private void FixedUpdate()
    {
        // Verifica si estamos en un dispositivo móvil o en el editor (si hay toques o se hace clic con el ratón)
        if (Input.touchCount > 0) // Para dispositivos móviles
        {
            // Obtiene el primer toque
            Touch toque = Input.GetTouch(0);

            // Verifica si el toque está en la fase de movimiento o inicial
            if (toque.phase == TouchPhase.Began || toque.phase == TouchPhase.Moved)
            {
                MoverJugador(toque.position.x); // Mueve al jugador según la posición del toque
            }
        }
        else if (Input.GetMouseButton(0)) // Para el editor (ratón)
        {
            MoverJugador(Input.mousePosition.x); // Mueve al jugador según la posición del mouse
        }
        else
        {
            // Detiene al jugador si no hay interacción táctil ni con el ratón
            rb.velocity = Vector2.zero;
        }
    }

    // Método para mover al jugador en función de la posición de la entrada
    private void MoverJugador(float posicionX)
    {
        // Si la entrada está en la parte izquierda de la pantalla
        if (posicionX < Screen.width / 2)
        {
            rb.velocity = Vector2.left * velocidad; // Mueve al jugador hacia la izquierda
            sr.flipX = true; // Invierte el sprite
        }
        else // Si la entrada está en la parte derecha de la pantalla
        {
            rb.velocity = Vector2.right * velocidad; // Mueve al jugador hacia la derecha
            sr.flipX = false; // No invierte el sprite
        }
    }

    // Método Start (se ejecuta una vez al inicio del juego)
    void Start()
    {
        // Actualmente no realiza ninguna acción
    }

    // Método Update (se ejecuta una vez por frame)
    void Update()
    {
        // Actualmente no realiza ninguna acción
    }
}
