using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    public Text keyCounterText; // El texto donde mostrar el contador
    public Image keyImage; // La imagen de la llave que aparecerá
    public Sprite keySprite; // La imagen de la llave en el Assets
    private int keyCount = 0; // Contador de llaves

    private void Start()
    {
        keyImage.enabled = false; // Al principio, la imagen está oculta
        UpdateKeyUI(); // Actualiza la UI
    }

    public void UpdateKeyUI()
    {
        // Actualizamos el contador en la UI
        keyCounterText.text = ": " + keyCount.ToString(); // Mostramos el contador
        keyImage.sprite = keySprite; // Asignamos la imagen de la llave
        keyImage.enabled = keyCount > 0; // Hacemos visible la imagen si el contador es mayor a 0
    }

    // Método para añadir llaves desde otro lugar del juego
    public void AddKey()
    {
        keyCount++;
        UpdateKeyUI();
    }
}