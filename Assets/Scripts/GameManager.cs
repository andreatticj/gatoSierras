using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para acceder al GameManager desde otros scripts.
    bool gameOver = false; // Indica si el juego ha terminado.

    [SerializeField]
    public Text marcador; // Referencia al texto del marcador en la interfaz de usuario (UI).
    private int puntuacion = 0; // Puntuación actual del jugador.

    private void Awake()
    {
        Instance = this; // Asigna esta instancia como Singleton.
    }

    // Método que se llama cuando el juego termina.
    public void GameOver()
    {
        gameOver = true; // Marca el estado del juego como terminado.
        // Detiene la generación de sierras accediendo al componente GeneradorSierras.
        GameObject.Find("GeneradorSierras").GetComponent<GeneradorSierras>().StopSpawning();

        // Encuentra todas las sierras activas en la escena.
        Obstaculo[] sierras = FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo sierra in sierras)
        {
            if (sierra != null)
            {
                sierra.DetenerSonido(); // Detiene el sonido de cada sierra.
            }
        }
        // Carga la escena de "Game Over".
        SceneManager.LoadScene("GameOver");
    }

    // Incrementa la puntuación del jugador y verifica si se debe aumentar la velocidad de las sierras.
    public void IncrementScore()
    {
        if (!gameOver) // Solo incrementa si el juego no ha terminado.
        {
            puntuacion++; // Incrementa la puntuación.
            print("TU PUNTUACIÓN ES " + puntuacion); // Muestra la puntuación en la consola (para depuración).
            marcador.text = puntuacion.ToString(); // Actualiza el texto del marcador en la UI.

            // Cada 5 puntos, aumenta la velocidad de las sierras.
            if (puntuacion % 5 == 0)
            {
                AumentarVelocidadSierras();
            }
        }
    }

    // Método para aumentar la velocidad de las sierras.
    void AumentarVelocidadSierras()
    {
        // Obtiene el script GeneradorSierras del objeto "GeneradorSierras".
        GeneradorSierras generador = GameObject.Find("GeneradorSierras").GetComponent<GeneradorSierras>();
        generador.AumentarVelocidad(); // Llama al método para aumentar la velocidad de las sierras.
    }

    // Reinicia el juego cargando nuevamente la escena principal.
    public void Restart()
    {
        SceneManager.LoadScene("EscenaJuegp");
    }

    // Vuelve al menú principal cargando la escena del menú.
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
