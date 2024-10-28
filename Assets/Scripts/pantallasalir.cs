using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pantallasalir : MonoBehaviour
{
public void Update(){
    if (Input.GetKey("escape"))
    Application.Quit();
    }
}