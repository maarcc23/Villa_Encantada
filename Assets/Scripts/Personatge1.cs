using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator; // Referencia al Animator
    private float _velocitatCorre;

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
        _animator = GetComponent<Animator>(); // Obtiene el Animator
        _rigidbody2D.freezeRotation = true;
        _velocitatCorre = 5f;
        _tocaTerra = false;
        _cercaPalanca = false;
        _palancaActivada = false;

    }

    void Update()
    {
        _tocaTerra = Physics2D.OverlapCircle(_centreZonaContacteTerra.position, _radiContacteTerra, _layereTerra);
        _cercaPalanca = Physics2D.OverlapCircle(transform.position, _radiInteraccio, _layerPalanca);

        Debug.DrawRay(_centreZonaContacteTerra.position, Vector2.down, Color.green);
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _velocitatCorre;
        float inputVertical = Input.GetAxisRaw("Vertical") * _velocitatCorre;

        _rigidbody2D.velocity = new Vector2(inputHorizontal, _rigidbody2D.velocity.y);

        if (inputHorizontal > 0) { // Es mou a la dreta.
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } else if (inputHorizontal < 0) { // Es mou a l'esquerra.
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Actualiza el parámetro de velocidad en el Animator
        _animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
    }
}