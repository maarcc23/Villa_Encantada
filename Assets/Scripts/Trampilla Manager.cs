using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrampillaManager : MonoBehaviour
{
    public string escenaDestino; // Nombre de la escena a cargar
    public Vector3 posicionDestino; // Posición donde aparecerá el personaje en la nueva escena

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardar la posición destino para la próxima escena
            PlayerPrefs.SetFloat("posX", posicionDestino.x);
            PlayerPrefs.SetFloat("posY", posicionDestino.y);
            PlayerPrefs.SetFloat("posZ", posicionDestino.z);

            // Cargar la escena destino
            SceneManager.LoadScene("game3");
        }
    }

    private void Start()
    {
        // Si el jugador reaparece, colocar en la posición guardada
        if (PlayerPrefs.HasKey("posX"))
        {
            float x = PlayerPrefs.GetFloat("posX");
            float y = PlayerPrefs.GetFloat("posY");
            float z = PlayerPrefs.GetFloat("posZ");

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = new Vector3(x, y, z);
            }

            // Limpiar los datos para evitar conflictos futuros
            PlayerPrefs.DeleteKey("posX");
            PlayerPrefs.DeleteKey("posY");
            PlayerPrefs.DeleteKey("posZ");
        }
    }
}