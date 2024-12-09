using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private float _velocidad = 5f; // Velocidad de la flecha
    private Vector2 limitesPantallaMaxX; // Límites de la pantalla
    private Vector2 limitesPantallaMinX; // Límites de la pantalla
    private int direccion; // Dirección (-1 izquierda, 1 derecha)

    [SerializeField] private GameObject prefabExplosio; // Prefab de la explosión

    void Start()
    {
        limitesPantallaMaxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)); // Obtener límites
        limitesPantallaMinX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Obtener límites
        direccion = Random.Range(0, 2) == 0 ? -1 : 1; // Dirección aleatoria

        if (direccion < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void Update()
    {
        // Mover la flecha
        Vector2 posicion = transform.position;
        posicion += new Vector2(direccion, 0) * _velocidad * Time.deltaTime;
        transform.position = posicion;

        // Explosión si llega al borde
        if (transform.position.x > limitesPantallaMaxX.x || transform.position.x < limitesPantallaMinX.x)
        {
            Explota();
        }
    }

    private void Explota()
    {
        GameObject explosion = Instantiate(prefabExplosio, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destruir la flecha
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hacer que el jugador muera
            //other.GetComponent<Personaje>().Morir();
            Explota();
        }
    }
}