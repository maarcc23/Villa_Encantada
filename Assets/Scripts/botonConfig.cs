using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonConfig : MonoBehaviour
{
    public GameObject player;
      public void config()
    {
      SceneManager.LoadScene("instrucciones2");
    }
}