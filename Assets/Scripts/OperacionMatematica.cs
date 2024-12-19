using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena (nivel)

public class OperacionMatematica : MonoBehaviour
{

     float numero1 = 10f;
     float numero2 = 5f;

    public List<int>numOperaciones = new List<int>();


    List<string> operadores = new List<string>();  
    public int resultadoOperacion;
    public int puntajeActual = 0;
    public int puntajeRequeridoParaSiguienteNivel = 50;
    private bool nivelCompletado = false;
    public string tagPlayer = "Player";
    public GameObject calculoMatematico;
    public TMP_InputField inputField;    // El campo donde el usuario escribe
    public TextMeshProUGUI textoHUD;
    public Personatge1 player; 

    // Start is called before the first frame update
    private enum Operacion { Sumar, Restar, Multiplicar, Dividir };
    private Operacion operacionSeleccionada;

    public bool isMultiplication;
    public bool isDivition;
    public bool isRest;
    public bool isSum;
    public bool problema2;
    public int result;
    public TextMeshProUGUI preguntaText;
    bool response;
    string currentOperator = "";
    void Start()
    {
       
        operadores.Add("+");
        operadores.Add("-");
        operadores.Add("*");
        operadores.Add("/");
        // preguntaText = GetComponent<TextMeshProUGUI>();
        // se generan 4 números aleatorios del 1 al 9 y se introducen en una lista. 
        numOperaciones.Add(Random.Range(1, 9));
        numOperaciones.Add(Random.Range(1, 9));
        numOperaciones.Add(Random.Range(1, 9));
        numOperaciones.Add(Random.Range(1, 9));
        result = 0;
        calculo();
        resultadoOperacion = result;
        // textoHUD.text = " ";
        inputField.text = " ";
        preguntaText.text = " ";



        //Hud
        //calculo();
        if (!problema2) {


            currentOperator = VerificarOperador(operadores);
            preguntaText.text = "Quina és la resposta de: " + numOperaciones[0] + " " + currentOperator + " " + numOperaciones[1];
        }
        else
        {
            currentOperator = VerificarOperador(operadores);
            preguntaText.text = "Quina és la resposta de: " + numOperaciones[2] + " " +currentOperator +" "+ numOperaciones[3];
        }

        //numero1 = Random.Range(1, 9);
        //numero2 = Random.Range(1, 9);

       // preguntaText.text = "Quina és la resposta de: " + numero1 + " * " + numero2;

       if (calculoMatematico.activeSelf == true)
        {
            calculoMatematico.SetActive(false);
            //RealizarOperacionMatematica();

            //SeleccionarOperacionAleatoria();
        }
    }

    private string VerificarOperador(List<string> operadores)
    {
        string returnStr = "";
        if (isSum)
        {
            returnStr = operadores[0];
        }
        if (isRest)
        {
            returnStr = operadores[1];
        }
        if (isMultiplication)
        {
            returnStr =  operadores[2];
        }
        if (isDivition)
        {
            returnStr = operadores[3];
        }
        return returnStr;
    }

    // Update is called once per frame
    void Update()
    {

        if (response)
        {
            inputField.onValueChanged.AddListener(respuesta); // lo de escribir 
            //Debug.Log("Encert");

            if (inputField.text == resultadoOperacion.ToString())
            {
                Debug.Log("Encert");
            }
        }
            
    }

    private void calculo()
    {
        if (isSum)
        {
            if (problema2)
            {
                result = Sum(numOperaciones[2], numOperaciones[3]);
            }
            else
            {
                result = Sum(numOperaciones[0], numOperaciones[1]);
            }
       
        }
        if (isRest)
        {
            if (problema2)
            {
                result = Restar(numOperaciones[2], numOperaciones[3]);
            }
            else
            {
                result = Restar(numOperaciones[0], numOperaciones[1]);
            }

        }
        if (isMultiplication)
        {
            if (problema2)
            {
                result = Multiplicar(numOperaciones[2], numOperaciones[3]);
            }
            else
            {
                result = Multiplicar(numOperaciones[0], numOperaciones[1]);
            }

        }
        if (isDivition)
        {
            if (problema2)
            {
                result = Dividir(numOperaciones[2], numOperaciones[3]);
            }
            else
            {
                result =Dividir(numOperaciones[0], numOperaciones[1]);
            }

        }
    }

    private int Sum(int value1, int value2)
    {
        return value1 + value2;
    }
    private int Restar(int value1, int value2)
    {
        return value1 - value2;
    }
    private int Multiplicar(int value1, int value2)
    {
        return value1 * value2;
    }
    private int Dividir(int value1, int value2)
    {
        return value1 / value2;
    }

    public void SeleccionarOperacionAleatoria()
    {
        // Selección aleatoria entre las operaciones
        operacionSeleccionada = (Operacion)Random.Range(0, 4);  // 0: Sumar, 1: Restar, 2: Multiplicar, 3: Dividir
        RealizarOperacionMatematica();  // Realizamos la operación seleccionada
    }


    public void RealizarOperacionMatematica()
    {
        
        switch (operacionSeleccionada)
        {
            case Operacion.Sumar:
                resultadoOperacion = (int)(numero1 + numero2);
                Debug.Log(resultadoOperacion);
                break;
            case Operacion.Restar:
                resultadoOperacion = (int)(numero1 - numero2);
                break;
            case Operacion.Multiplicar:
                resultadoOperacion = (int)(numero1 * numero2);
                break;
            case Operacion.Dividir:
                // Verificar que no se divida por cero
                if (numero2 != 0)
                {
                    resultadoOperacion = (int)(numero1 / numero2);
                }
                else
                {
                    // Si el divisor es cero, cambiamos el número2 a 1 para evitar error.
                    numero2 = 1;
                    resultadoOperacion = (int)(numero1 / numero2);
                }
                break;

        }
        Debug.Log("Operación seleccionada: " + operacionSeleccionada.ToString() + " | Resultado: " + resultadoOperacion);
    }
    



    public void PasarAlSiguienteNivel()
    {
      
      nivelCompletado = true;

      Debug.Log("¡Nivel completado! Pasando al siguiente nivel...");

        // Cambia a la escena siguiente
      SceneManager.LoadScene("PantallaWin");
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            calculoMatematico.SetActive(true);
            response = true;
            Debug.Log("Jugador entró en la zona de colisión");
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

        Debug.Log("inputField.text=" + inputField.text);
        Debug.Log("resultadoOperacion.ToString()=" + resultadoOperacion.ToString());

        if (inputField.text == resultadoOperacion.ToString()) // Aquí puedes cambiar la operación si es necesario (por ejemplo, Restar())
        {
            textoHUD.text = "¡Respuesta correcta!";
            puntajeActual += 10; // Incrementar puntaje cuando la respuesta es correcta
           
            if (puntajeActual >= puntajeRequeridoParaSiguienteNivel && !nivelCompletado)
            {
                PasarAlSiguienteNivel();  // Cambia de escena si el puntaje alcanza el umbral
            }
        }
        else
        {
            textoHUD.text = "Respuesta incorrecta. Intenta de nuevo.";  // Mensaje en caso de error
        }

    }
}