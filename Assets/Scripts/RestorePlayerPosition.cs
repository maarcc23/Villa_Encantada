using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePlayerPosition : MonoBehaviour
{
   void Start()
    {
        // Si hay una posición guardada, restaúrala
        if (PlayerData.playerPosition != Vector3.zero)
        {
            transform.position = PlayerData.playerPosition;
        }
    }
}
