using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escenas.

public class MenuController : MonoBehaviour
{
    // Método Start (se ejecuta una vez al inicio del script).
    void Start()
    {
        // Actualmente no realiza ninguna acción al iniciar el menú.
    }

    // Método Update (se ejecuta una vez por frame).
    void Update()
    {
        // Actualmente no realiza ninguna acción en cada frame.
    }

    // Método público llamado "Jugar".
    public void Jugar()
    {
        // Carga una nueva escena llamada "EscenaJuegp".
        SceneManager.LoadScene("EscenaJuegp");
    }

    // Método público llamado "Salir".
    public void Salir()
    {
        // Cierra la aplicación cuando se ejecuta. 
        Application.Quit();
    }
}
