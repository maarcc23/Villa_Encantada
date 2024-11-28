using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public string tagPlayer = "Player";
    public GameObject calculoMatematico;
    public TMP_InputField inputField;    // El campo donde el usuario escribe
    public TextMeshProUGUI textoHUD;
    // Start is called before the first frame update
    void Start()
    {
        
        textoHUD.text = " ";
        inputField.text = " ";
     
        inputField.onValueChanged.AddListener(respuesta);

        calculoMatematico.SetActive(false);

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

    
    public void PasarAlSiguienteNivel()
    {
        
      nivelCompletado = true;

        Debug.Log("¡Nivel completado! Pasando al siguiente nivel...");

        // Cambia a la escena siguiente
        SceneManager.LoadScene("game2");
    }

    
    public int Sumar()
    {
        resultadoOperacion = (int)(numero1 + numero2); // Realiza la suma
        Debug.Log("Resultado de la suma: " + resultadoOperacion);
        return resultadoOperacion;
    }

 
    public void Restar()
    {
        resultadoOperacion = (int)(numero1 - numero2); // Realiza la resta
        Debug.Log("Resultado de la resta: " + resultadoOperacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            calculoMatematico.SetActive(true);
        }
    }
    public void respuesta(string text)
    {
        
        // Actualizar el texto en el HUD con lo que el usuario ha escrito
        textoHUD.text = ":" + text;
        checkUserAnswer(text);
    }

  
    private void checkUserAnswer(string text)
    {
        int userAnswer;
        bool isValid = int.TryParse(text, out userAnswer);

        if (isValid && userAnswer == Sumar()) // Aquí puedes cambiar la operación si es necesario (por ejemplo, Restar())
        {
            textoHUD.text = "¡Respuesta correcta!";
            PasarAlSiguienteNivel();  // Cambia de escena si la respuesta es correcta
        }
        else
        {
            textoHUD.text = "Respuesta incorrecta. Intenta de nuevo.";  // Mensaje en caso de error
        }

    }
}