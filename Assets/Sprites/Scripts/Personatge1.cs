using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocitatCorre;
    private float _velocitatSaltar;

    public Transform _centreZonaContacteTerra;
    public float _radiContacteTerra;
    public LayerMask _layereTerra;
    private bool _tocaTerra;
    private bool _cercaPalanca;
    public float _radiInteraccio = 2f;
    public LayerMask _layerPalanca;

    private bool _palancaActivada;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
        _velocitatCorre = 5f;
        _velocitatSaltar = 5f;
        _tocaTerra = false;
        _cercaPalanca = false;
        _palancaActivada = false;

    }

    // Update is called once per frame
    void Update()

    {
        _tocaTerra = Physics2D.OverlapCircle(_centreZonaContacteTerra.position, _radiContacteTerra, _layereTerra);
        _cercaPalanca = Physics2D.OverlapCircle(transform.position, _radiInteraccio, _layerPalanca);

        Debug.DrawRay(_centreZonaContacteTerra.position, Vector2.down, Color.green);
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _velocitatCorre;
        float inputVertical = Input.GetAxisRaw("Vertical") * _velocitatCorre;

        

            Debug.Log("Palanca activada");
            _rigidbody2D.velocity = new Vector2(inputHorizontal, _rigidbody2D.velocity.y);
    }

    

}