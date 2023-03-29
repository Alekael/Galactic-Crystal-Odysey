using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMov_V2 : MonoBehaviour
{

    public float speed = 4.5f;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    public float jumpForce = 10.0f;
    public bool fall= false;
    public bool shooting = false;
    public GameObject _projectile;
    public Transform firePoint;
    private int cooldown = 120;
    private AudioSource _audioSorce;
    public int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        _audioSorce = GetComponent<AudioSource>();
        firePoint = transform.Find("firePoint");

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
    
        if(!Mathf.Approximately(deltaX,0f)){
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1f, 1f);
            _anim.SetFloat("speed",  Mathf.Abs(deltaX));
        }

        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        
        _body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0.0f) &&  Mathf.Abs(_body.velocity.y) < 0.1f) ? 0.0f : 2.0f;

        if (grounded && Input.GetKeyDown("w")) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        if(_body.velocity.y < 0){
            _anim.SetBool("isFalling", true);
        }else { _anim.SetBool("isFalling", false);}
        _anim.SetBool("isGrounded", grounded);
        
        if(grounded && Input.GetKey("space")){
            _anim.SetBool("isShooting", true);
            print("space key was pressed");
            cooldown--;
            if(cooldown < 0){
                Shoot();
                cooldown = 120;
            }

        }else {_anim.SetBool("isShooting", false);}

    }

    private (Vector2, Vector2) getGroundCheckCorners() {
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x - .1f, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x + .1f, min.y - .2f);
        return (corner1, corner2);
    }

    public bool grounded {
        get {
            var (corner1, corner2) = getGroundCheckCorners();
            Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
            return (hit != null);
        }
    }

    void Shoot(){
        if(_audioSorce != null) _audioSorce.Play();
        Instantiate(_projectile, firePoint.position, firePoint.rotation);
    }

    public void TakeDamage(int dmg){
        lives = lives - dmg;
        Debug.Log("take damage");
    }

}
