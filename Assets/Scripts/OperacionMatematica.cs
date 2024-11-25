using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena (nivel)

public class OperacionMatematica : MonoBehaviour
{

    public float numero1 = 10f;
    public float numero2 = 5f;
    public int resultadoOperacion;
    public int puntajeActual = 0;
    public int puntajeRequeridoParaSiguienteNivel = 50;
    private bool nivelCompletado = false;
    public string tagPuerta = "Puerta";

    // Start is called before the first frame update
    void Start()
    {

        //RealizarOperacionMatematica();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void RealizarOperacionMatematica()
    {

        resultadoOperacion = (int)(numero1 * numero2);


        if (resultadoOperacion == 50)
        {

            puntajeActual += 10;
            Debug.Log("¡Operación correcta! Puntaje actual: " + puntajeActual);
        }
        else
        {
            Debug.Log("Operación incorrecta. El resultado era: " + resultadoOperacion);
        }
        if (puntajeActual >= puntajeRequeridoParaSiguienteNivel && !nivelCompletado)
        {
            PasarAlSiguienteNivel();
        }
    }

    
    void PasarAlSiguienteNivel()
    {
        
      nivelCompletado = true;

        Debug.Log("¡Nivel completado! Pasando al siguiente nivel...");

        // Cambia a la escena siguiente
        SceneManager.LoadScene("SiguienteNivel");
    }

    
    void Sumar()
    {
        resultadoOperacion = (int)(numero1 + numero2); // Realiza la suma
        Debug.Log("Resultado de la suma: " + resultadoOperacion);
    }

 
    void Restar()
    {
        resultadoOperacion = (int)(numero1 - numero2); // Realiza la resta
        Debug.Log("Resultado de la resta: " + resultadoOperacion);
    }
}