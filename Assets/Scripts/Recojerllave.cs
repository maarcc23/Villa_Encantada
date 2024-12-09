using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cofre : MonoBehaviour
{
    public GameObject cofreCerrado;
    public GameObject textPorta;
    public GameObject textPortaLlave;
    public bool puedeAbrirCofre = false; // Controlar si el jugador está cerca del cofre
    public bool puedeUsarLlave = false; // Controlar si el jugador tiene la llave
    public GameObject cofreAbierto;
    public GameObject llaveCasa;
    public TextMeshPro textoLlave; // Asumiendo que usas TextMeshPro para mostrar el texto de las llaves

    void Start()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(false);
        if (llaveCasa != null) llaveCasa.SetActive(false);
        if (textPorta != null) textPorta.SetActive(false);
        if (textPortaLlave != null) textPortaLlave.SetActive(false);
        if (textoLlave != null) textoLlave.gameObject.SetActive(false);
        
    }

    void Update()
    {
        // Interacción con el cofre cerrado
        if (puedeAbrirCofre)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                Destroy(cofreCerrado);
                Invoke("activarCofre", 0f);
                puedeAbrirCofre = false; // Impedir que el cofre se abra nuevamente
            }

            
            
            textPortaLlave.SetActive(true);
        }

        // Usar la llave
        if (puedeUsarLlave && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(llaveCasa);
            textoLlave.text = "Tienes 1 llave"; // Mostrar que el jugador tiene la llave
            textoLlave.gameObject.SetActive(true);
            Invoke("ocultarTextoLlave", 3f); // Ocultar el texto después de un tiempo
            puedeUsarLlave = false; // Impedir que la llave se use nuevamente
        }
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Tocant col: " + col);
        if (col.gameObject.CompareTag("cofre"))
        {
            //textPorta.SetActive(true);
            Debug.Log("Tocant cofre");
            puedeAbrirCofre = true; // Permitir abrir el cofre
        }
        else if (col.gameObject.CompareTag("cofreAbierto"))
        {
            textPortaLlave.SetActive(true); // Mostrar texto que indica que ahora se puede obtener la llave
        }
        else if (col.gameObject.CompareTag("llave"))
        {
            textPortaLlave.SetActive(true); // Mostrar texto de que el jugador puede tomar la llave
            puedeUsarLlave = true; // Permitir usar la llave
        }
    }

    public void activarCofre()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(true); // Mostrar el cofre abierto
        if (llaveCasa != null) llaveCasa.SetActive(true); // Mostrar la llave
    }

    // Ocultar el texto de la llave después de un tiempo
    void ocultarTextoLlave()
    {
        if (textoLlave != null) textoLlave.gameObject.SetActive(false);
    }

}