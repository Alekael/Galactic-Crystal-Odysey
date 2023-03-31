using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov_V2 : MonoBehaviour
{

    public float speed = 4.5f;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    public float jumpForce = 10.0f;
    public float downForce = 4f;
    private float gravity = 2f;
    public bool fall= false;
    public bool shooting = false;
    public GameObject _projectile;
    public Transform firePoint;
    public float cooldown = 0f;
    public float timer = 0.5f;
    private AudioSource _audioSorce;
    private SpriteRenderer _renderer;
    public int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        _audioSorce = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
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
        
        _body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0.0f) &&  Mathf.Abs(_body.velocity.y) < 0.1f) ? 0.0f : gravity;

        if(_body.velocity.y < 0 && gravity < 6f){ gravity += downForce; } 
        else { gravity = 2f;}

        
        if (grounded && Input.GetKeyDown("w")) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        if(_body.velocity.y < 0){
            _anim.SetBool("isFalling", true);
        }else { _anim.SetBool("isFalling", false);}
        _anim.SetBool("isGrounded", grounded);
        
        if(Input.GetKey("space")){
            _anim.SetBool("isShooting", true);
            print("space key was pressed");
            if(cooldown <= 0){
                Shoot();
            }
            cooldown -= Time.deltaTime;
        }else {_anim.SetBool("isShooting", false); if(cooldown > 0f){ cooldown -= Time.deltaTime;} else{cooldown = 0f;}}



        if(lives <= 0){
            SceneManager.LoadScene("Game Over");
        }
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
        print("shoot");
        if(_audioSorce != null) _audioSorce.Play();
        Instantiate(_projectile, firePoint.position, firePoint.rotation);        
        cooldown = timer;
    }

    public void UpdateHealth(int dmg){
        /*if(dmg < 0){
            _renderer.color = Color.red;
        }*/
        lives = lives + dmg;
        GameObject.Find("HUD").GetComponent<HUDscript>().updateHUD(lives);
        Debug.Log("lives updated: " + lives);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("CanBePickedUp") && lives < 5) {
            Item item = other.gameObject.GetComponent<Consumable>().item;
            if(item != null){                
                UpdateHealth(item.quantity);
                other.gameObject.SetActive(false);
            }
        }
    }

    public int getLives(){
        return lives;
    }


}
