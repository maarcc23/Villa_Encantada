using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TocarPiston : MonoBehaviour
{
    public GameObject pistonPrefab; // Arrastra aquí el prefab del pistón
    public Sprite newPistonImage;  // Nueva imagen del pistón
    public string sceneToLoad;     // Nombre de la escena a cargar

    private bool isNearPiston = false;
    private SpriteRenderer pistonRenderer;

    void Start()
    {
        pistonRenderer = pistonPrefab.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isNearPiston && Input.GetKeyDown(KeyCode.E))
        {
            ChangePistonImage();
            LoadNextScene();
        }
    }

    private void ChangePistonImage()
    {
        if (pistonRenderer != null && newPistonImage != null)
        {
            pistonRenderer.sprite = newPistonImage;
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == pistonPrefab)
        {
            isNearPiston = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == pistonPrefab)
        {
            isNearPiston = false;
        }
    }
}


