using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFleches : MonoBehaviour
{
    [SerializeField]private GameObject prefabflecha;
    private Vector2 minPantalla, maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarFleches", 1f, 1f);

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void GenerarFleches()
    {
        GameObject flecha = Instantiate(prefabflecha);

        int direccion = Random.Range(0, 2) == 0 ? -1 : 1; // Dirección aleatoria
        Debug.Log("direccion=" + direccion);
        flecha.GetComponent<Flecha>().AsignarDirecFlecha(direccion);

        if (direccion < 0)
        {
            
            flecha.transform.position = new Vector2(maxPantalla.x, Random.Range(minPantalla.y, maxPantalla.y));
        }else{
            flecha.transform.position = new Vector2(minPantalla.x, Random.Range(minPantalla.y, maxPantalla.y));
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

