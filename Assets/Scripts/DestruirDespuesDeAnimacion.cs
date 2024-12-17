using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesDeAnimacion : MonoBehaviour
{
    void Start() {
        Invoke("Destruir", 1f);
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }
}
