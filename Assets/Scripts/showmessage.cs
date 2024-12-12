using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class ShowMessage : MonoBehaviour
{
    public GameObject messageText; // Arrastra el objeto del texto aquí
    public float displayTime = 3f; // Tiempo que el mensaje estará visible

    void Start()
    {
        // Asegúrate de que el texto esté oculto al principio
        messageText.SetActive(true);

        // Invoca el método HideMessage después del tiempo especificado
        Invoke("HideMessage", displayTime);
    }

    void HideMessage()
    {
        // Oculta el mensaje
        messageText.SetActive(false);
    }
}