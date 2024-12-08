using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorSierras : MonoBehaviour
{
    public GameObject obstaculo; // Prefab del obstáculo (sierra) que se generará

    [SerializeField] 
    public float velocidadSpawn = 2f; // Tiempo entre cada aparición de una nueva sierra
    float minimoX = -2f; // Posición mínima en el eje X para generar la sierra
    float maximoX = 2f;  // Posición máxima en el eje X para generar la sierra

    [SerializeField]
    float incrementoVelocidad = 0.2f; // Incremento en la velocidad de generación (reduce el tiempo entre spawns)

    void Start()
    {
        StartSpawning(); // Inicia el proceso de generación de sierras
    }

    // Método que genera un nuevo obstáculo en una posición aleatoria en el rango de X
    void Spawn()
    {
        float randomenX = Random.Range(minimoX, maximoX); // Genera una posición aleatoria entre minimoX y maximoX
        Vector2 spawnPos = new Vector2(randomenX, transform.position.y); // Calcula la posición de generación
        Instantiate(obstaculo, spawnPos, Quaternion.identity); // Crea la sierra en la posición generada
    }

    // Método para iniciar la generación repetida de obstáculos
    void StartSpawning()
    {
        InvokeRepeating("Spawn", 1f, velocidadSpawn); // Llama al método Spawn repetidamente cada velocidadSpawn segundos
    }

    // Método para detener la generación de sierras
    public void StopSpawning()
    {
        CancelInvoke("Spawn"); // Detiene el proceso de generación
    }

    // Método para aumentar la velocidad de generación de sierras
    public void AumentarVelocidad()
    {
        CancelInvoke("Spawn"); // Detiene el proceso actual
        // La función Mathf.Max se asegura de que el valor de velocidadSpawn nunca sea menor que 0.1 segundos.
        velocidadSpawn = Mathf.Max(0.1f, velocidadSpawn - incrementoVelocidad); // Reduce el tiempo entre spawns, asegurándose de no bajar de 0.1
        StartSpawning(); // Reinicia el proceso con la nueva velocidad
    }
}
