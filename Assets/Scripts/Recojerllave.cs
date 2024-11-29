using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KeySquare")) // Verificamos que colisione con el square de la llave
        {
            // Incrementamos el contador (solo dentro del script si lo necesitas)
            // Eliminamos el objeto de la llave recogida
            Destroy(collision.gameObject); 
        }
    }
}

