using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayAgain : MonoBehaviour
{
    public void AgainPlay()
    {
       SceneManager.LoadScene("principal");
    }
}

