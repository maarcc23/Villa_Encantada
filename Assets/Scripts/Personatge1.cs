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

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); // Obtiene el Animator
        _rigidbody2D.freezeRotation = true;
        _velocitatCorre = 5f;
        _tocaTerra = false;
    }

    void Update()
    {
        _tocaTerra = Physics2D.OverlapCircle(_centreZonaContacteTerra.position, _radiContacteTerra, _layereTerra);
        Debug.DrawRay(_centreZonaContacteTerra.position, Vector2.down, Color.green);

        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _velocitatCorre;
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