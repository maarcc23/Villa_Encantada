using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class InteractObject : MonoBehaviour
{
    public string message = "Pulsa 'E' para interactuar"; // Mensaje que aparece al acercarse
    public GameObject newObject; // Objeto al que cambiará
    public string nextScene; // Nombre de la escena a cargar

    private bool isPlayerNearby = false; // Controla si el jugador está cerca
    private GameObject currentObject; // Objeto actual que se mostrará

    void Start()
    {
        // Al inicio, muestra el objeto actual y oculta el nuevo
        currentObject = this.gameObject;
        if (newObject != null)
        {
            newObject.SetActive(false);
        }
    }

    void Update()
    {
        // Detecta si el jugador presiona "E" cuando está cerca
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador se aleja, se desactiva la posibilidad de interactuar
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void OnGUI()
    {
        // Muestra el mensaje cuando el jugador está cerca
        if (isPlayerNearby)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 30), message);
        }
    }

    void Interact()
    {
        // Cambia el objeto visible y carga la nueva escena
        if (newObject != null)
        {
            currentObject.SetActive(false);
            newObject.SetActive(true);
        }

        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
