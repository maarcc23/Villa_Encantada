using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonConfig : MonoBehaviour
{
    public GameObject player;
      public void config()
    {
      PlayerData.playerPosition = player.transform.position;
      SceneManager.LoadScene("instrucciones2");
    }
}