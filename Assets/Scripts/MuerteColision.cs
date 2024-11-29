using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator animator;  // Referencia al Animator del personaje

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Si no se asignó, se obtiene automáticamente
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Square")) // Asegúrate de que el objeto tiene el tag "Square"
        {
            // Activa el trigger de la animación de muerte
            animator.SetTrigger("Die");

            // Llamar a la función para cargar la escena de "PantallaMuerte" después de la animación
            Invoke("LoadDeathScene", 1f);  // Asegúrate de que la escena se carga después de un pequeño retardo
        }
    }

    private void LoadDeathScene()
    {
        // Aquí puedes cargar la escena de muerte
        UnityEngine.SceneManagement.SceneManager.LoadScene("PantallaMuerte");
    }
}