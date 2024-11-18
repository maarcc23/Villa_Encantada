using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool tienellave = false;  // Indica si el jugador tiene la llave
    public GameObject puerta;      // Referencia a la puerta
    public GameObject llave;       // Referencia a la llave

    void Update()
    {
        // Movimiento básico del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * 5f * Time.deltaTime);

        // Detectar si el jugador está cerca de la llave
        if (Vector2.Distance(transform.position, llave.transform.position) < 1f)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Interacción al presionar E
            {
                PickUpKey();
            }
        }

        // Detectar si el jugador está cerca de la puerta y tiene la llave
        if (Vector2.Distance(transform.position, puerta.transform.position) < 1f)
        {
            if (Input.GetKeyDown(KeyCode.E) && tienellave)
            {
                OpenDoor();
            }
        }
    }

    void PickUpKey()
    {
        tienellave = true;
        llave.SetActive(false); // Desactiva la llave una vez recogida
        Debug.Log("Has recogido la llave!");
    }

    void OpenDoor()
    {
        puerta.SetActive(false);  // Desactiva la puerta, abriéndola
        Debug.Log("Has abierto la puerta!");
    }
}