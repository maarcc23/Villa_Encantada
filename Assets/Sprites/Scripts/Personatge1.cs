using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personatge1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _velocitatCorre;
    private float _velocitatSaltar;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = false;
        _velocitatCorre = 5f;
        _velocitatSaltar = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal")*_velocitatCorre;
        float inputVertical = Input.GetAxisRaw("Vertical") * _velocitatCorre;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,_velocitatSaltar);
        }

        _rigidbody2D.velocity = new Vector2(inputHorizontal,_rigidbody2D.velocity.y);
    }
}
