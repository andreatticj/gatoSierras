using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    // Declaración de variables privadas:
    Rigidbody2D rbSierra; // Referencia al componente Rigidbody2D del obstáculo (sierra).
    [SerializeField]
    float velocidadDeRotacion; // Velocidad con la que la sierra rota sobre su eje Z.
    AudioSource audioSierra; // Referencia al componente AudioSource de la sierra para reproducir sonidos.

    // Método llamado al inicializar el script.
    private void Awake()
    {
        rbSierra = GetComponent<Rigidbody2D>(); // Obtiene y asigna el Rigidbody2D del GameObject.
        audioSierra = GetComponent<AudioSource>(); // Obtiene y asigna el AudioSource del GameObject.
    }

    // Método Start (se ejecuta una vez al inicio del juego).
    private void Start()
    {
        if (audioSierra != null) // Verifica que el componente AudioSource exista.
        {
            audioSierra.Play(); // Reproduce el sonido de la sierra al inicio.
        }
    }

    // Método FixedUpdate (se ejecuta en intervalos fijos de tiempo, ideal para cálculos de físicas).
    private void FixedUpdate()
    {
        // Rota el GameObject (la sierra) en el eje Z según la velocidad especificada.
        transform.Rotate(0, 0, velocidadDeRotacion);
    }

    // Detecta cuando la sierra entra en contacto con un objeto que tiene un Collider2D.
    void OnTriggerEnter2D(Collider2D colision)
    {
        // Si la sierra toca un objeto etiquetado como "suelo".
        if (colision.tag == "suelo")
        {
            print("suelo"); // Muestra un mensaje de depuración.
            GameManager.Instance.IncrementScore(); // Llama al método para incrementar la puntuación.
            Destroy(gameObject); // Destruye la sierra.
        }
        // Si la sierra toca un objeto etiquetado como "player".
        if (colision.tag == "player")
        {
            print("player"); // Muestra un mensaje de depuración.
            if (audioSierra != null)
            {
                audioSierra.Stop(); // Detiene el sonido de la sierra.
            }
            Destroy(colision.gameObject); // Destruye el objeto del jugador.
            GameManager.Instance.GameOver(); // Llama al método para terminar el juego.
        }
    }

    // Método público para detener el sonido de la sierra desde otro script.
    public void DetenerSonido()
    {
        if (audioSierra != null && audioSierra.isPlaying) // Verifica que el AudioSource exista y esté reproduciendo.
        {
            audioSierra.Stop(); // Detiene el sonido.
        }
    }
}
