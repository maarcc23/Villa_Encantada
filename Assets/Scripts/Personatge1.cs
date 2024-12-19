using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena (nivel)

public class Personatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator; 
    private float _velocitatCorre;

    public float _radiContacteTerra;
    public LayerMask _layereTerra;
    //private bool _tocaTerra;
    private bool _cercaPalanca;
    public float _radiInteraccio = 2f;
    public LayerMask _layerPalanca;
    public bool tieneLlave = false;
    public GameObject menuPausa;
    private bool _palancaActivada;
    bool pjMuere=false;
    //KeyCode key = KeyCode.Esc;
    float timer = 2f;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); 
        _rigidbody2D.freezeRotation = true;
        _velocitatCorre = 5f;
        //_tocaTerra = false;
        _cercaPalanca = false;
        _palancaActivada = false;

        // Asegurarse de que la gravedad no afecte al personaje
        _rigidbody2D.gravityScale = 0;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape)){
            if(switchPause ==0){
            menuPausa.SetActive(true);
            Time.timeScale = 0.0f;
            switchPause =1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(switchPause ==1){
            menuPausa.SetActive(false);
            Time.timeScale = 1;
            switchPause =0;
            }
        }*/

        if(pjMuere){
            timer  -= 1 * Time.deltaTime;
            if(timer <=0){
                 SceneManager.LoadScene("PantallaMuerte");
                 
            }
        }
        //_tocaTerra = Physics2D.OverlapCircle(_centreZonaContacteTerra.position, _radiContacteTerra, _layereTerra);
        _cercaPalanca = Physics2D.OverlapCircle(transform.position, _radiInteraccio, _layerPalanca);

        //Debug.DrawRay(_centreZonaContacteTerra.position, Vector2.down, Color.green);

        // Captura de entradas de movimiento
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        // Normalizar para mantener velocidad constante en diagonal
        Vector2 direccioMoviment = new Vector2(inputHorizontal, inputVertical).normalized;

        // Aplicar movimiento al Rigidbody2D
        _rigidbody2D.velocity = direccioMoviment * _velocitatCorre;

        // Animaciones y orientación del personaje
        if (direccioMoviment.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direccioMoviment.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Actualiza parámetros en el Animator
        _animator.SetFloat("Speed", direccioMoviment.magnitude);
        _animator.SetFloat("Horizontal", direccioMoviment.x);
        _animator.SetFloat("Vertical", direccioMoviment.y);
    }

        private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("NoTocar"))
        {
            Muerte();
            Debug.Log("Has tocado un objeto NoTocar!");
        }

        if (collision.CompareTag("PuertaGame3"))
        {
            Debug.Log("Has tocado la puerta!");
            //GameObject.Find("fondojuego3").GetComponent<OperacionMatematica>().RealizarOperacionMatematica();
        }
        
       
        //Comprueba si el objeto que tocamos tiene el tag "PantallaFlecha"
        
        if (collision.CompareTag("flechamorir"))
        {
            pjMuere=true;
           
        }
        
        if (collision.CompareTag("llave1"))
        {
            SceneManager.LoadScene("game3");
        }
        
        if (collision.CompareTag("llave"))
        {
            Destroy(collision.gameObject); // Destruye la llave
        }
        if (collision.CompareTag("PantallaFlecha"))
        {
            SceneManager.LoadScene("game4");
        }
    }



    private void Muerte()
    {
       
        gameObject.SetActive(false);

       
        Invoke("ReiniciarNivel", 2f);  
    }
    
    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "llave")
        {
            tieneLlave = true;
        }
    }

}