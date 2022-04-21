using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    private Animator _animator;
   
    
    public float JumpForce = 10;
    public float velocity = 10;
    public Text _text;
    public Text _text2;
    public Text _puntaje;
    
    public int modena1 = 0;
    public int modena2 = 0;
    public int Puntuacion = 0;
    
    public GameObject bulletPrefabs;
    
    private static readonly int right = 1;
    private static readonly int left = -1;
    
    private static readonly int Animation_Ilde = 0;
    private static readonly int Animation_run = 1;
    private static readonly int Animation_Slide = 2;
    private static readonly int Animation_jump = 3;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _puntaje.text="PUNTAJE : "+Puntuacion;
        _text.text = "MONEDA 1: "+modena1;
        _text2.text= "MONEDA 2: "+modena2;
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        ChangeAnimation(Animation_Ilde);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(right);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(left);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
            ChangeAnimation(Animation_jump);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            ChangeAnimation(Animation_Slide);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }
        
    }
    
    private void Desplazarse(int position)
    {
        _rigidbody2D.velocity = new Vector2(velocity * position, _rigidbody2D.velocity.y);
        _renderer.flipX = position == left;
        ChangeAnimation(Animation_run);
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger("Estado",animation);
    }
    public void Puntaje(int puntos)
    {
        Puntuacion += puntos;
        
        Debug.Log(Puntuacion);
    }
    private void Disparar()
    {
        //crear elementos en tiempo de ejecuccion
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bullgo=Instantiate(bulletPrefabs,new Vector2(x,y),Quaternion.identity) as GameObject;
        var controller = bullgo.GetComponent<BolaController>();
        
        controller.SetController(this);
        
        if (_renderer.flipX)
        {
            
            controller.velocity = controller.velocity * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag=="MonedaSilver" )
        {
            Debug.Log("silver");
            Destroy(other.gameObject);
            modena1 += 10;
        }
        if (tag=="MonedaGold" )
        {
            Debug.Log("gold");
            Destroy(other.gameObject);
            modena2 += 20;

        }
    }
}
