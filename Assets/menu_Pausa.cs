using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_Pausa : MonoBehaviour
{
    public GameObject panelBotones;
    public GameObject panelHistoria;
    public GameObject panelControles;
    int switchPause = 0;

    // Start is called before the first frame update
    void Start()
    {
        panelBotones.SetActive(false);
        panelControles.SetActive(false);
        panelHistoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
             if(switchPause ==0){
                panelBotones.SetActive(true);
                Time.timeScale = 0.0f;
                //switchPause =1;
            }
            
        }
       /* if(Input.GetKeyDown(KeyCode.Escape)){
             if(switchPause ==1){
                panelBotones.SetActive(false);
                Time.timeScale = 1f;
                switchPause =0;
            }
            
        }*/
        
    }

    public void goToHistoria(){
        panelBotones.SetActive(false);
        panelHistoria.SetActive(true);
    }
    public void  goToControllers(){
        panelBotones.SetActive(false);
        panelControles.SetActive(true);
    }

    public void backToGame(){
        panelHistoria.SetActive(false);
        panelBotones.SetActive(false);
        panelControles.SetActive(false);
        Time.timeScale = 1f;
    }
}
