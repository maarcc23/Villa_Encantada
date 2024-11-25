using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   [Tooltip("PantallaMuerte")]
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "Square"
        if (collision.CompareTag("Square"))
        {
            // Cargar la escena especificada
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            
        }
    }
}
