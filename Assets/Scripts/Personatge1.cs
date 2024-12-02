using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocitatCorre;
    private float _velocitatSaltar;

    public float _radiContacteTerra;
    public LayerMask _layereTerra;
    private bool _tocaTerra;
    public float _velocitatVertical;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocitatCorre = 5f;
        _velocitatSaltar = 5f;
        _velocitatVertical = 3f;
        _tocaTerra = false;

    }

    // Update is called once per frame
    void Update()

    {
        //_tocaTerra = Physics2D.OverlapCircle(_centreZonaContacteTerra.position, _radiContacteTerra, _layereTerra);

        //Debug.DrawRay(_centreZonaContacteTerra.position, Vector2.down, Color.green);
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _velocitatCorre;
        float inputVertical = Input.GetAxisRaw("Vertical") * _velocitatCorre;

        /*if (Input.GetKeyDown(KeyCode.Space))
        {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,_velocitatSaltar);
        }*/

        _rigidbody2D.velocity = new Vector2(inputHorizontal, inputVertical);
    }

        private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("NoTocar"))
        {
            Muerte();
            Debug.Log("¡Has tocado un objeto NoTocar!");
        }

        if (collision.CompareTag("PuertaGame3"))
        {
            Debug.Log("¡Has tocado la puerta!");
            //GameObject.Find("fondojuego3").GetComponent<OperacionMatematica>().RealizarOperacionMatematica();
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
}
