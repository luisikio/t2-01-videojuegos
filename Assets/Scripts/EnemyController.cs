using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 5;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private bool coli = false;
    private int cont = 0;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(velocity, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = false;
        if (coli==true)
        {
            _spriteRenderer.flipX = true;
            _rigidbody2D.velocity = new Vector2(velocity*-1, _rigidbody2D.velocity.y);
        }
    }

   /* private void OnCollisionEnter2D(Collision2D col)
    {
        var tag = col.gameObject.tag;
        if (tag == "tope")
        {
            Debug.Log("colision");
            coli = true;
            cont += 1;
            if (cont==2)
            {
                coli = false;
                cont = 0;
            }
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D col)
    {
        var tag = col.gameObject.tag;
        if (tag == "tope")
        {
            Debug.Log("colision");
            coli = true;
            cont += 1;
            if (cont==2)
            {
                coli = false;
                cont = 0;
            }
        }
    }
}
