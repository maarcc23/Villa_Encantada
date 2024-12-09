using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MapaInstrucciones : MonoBehaviour
{

public TextMeshProUGUI messageText; // Arrastra aquí el componente de texto de tu canvas
    private float messageDuration = 2f; // Duración del mensaje en pantalla

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("mapa"))
    {
        StartCoroutine(ShowMessage("¡Agafa les 2 claus per obrir la porta!", messageDuration));
        Destroy(other.gameObject, messageDuration);
    }
}

    private IEnumerator ShowMessage(string message, float duration)
    {
        // Mostrar el texto
        messageText.text = message;
        messageText.enabled = true;

        // Esperar el tiempo indicado
        yield return new WaitForSeconds(duration);

        // Ocultar el texto
        messageText.enabled = false;
    }




    private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Colisión detectada");
    if (collision.gameObject.CompareTag("mapa"))
    {
        Debug.Log("Colisión con 'mapa'");
        StartCoroutine(ShowMessage("¡Agafa les 2 claus per obrir la porta!", messageDuration));
        Destroy(collision.gameObject, messageDuration);
    }
}

}
