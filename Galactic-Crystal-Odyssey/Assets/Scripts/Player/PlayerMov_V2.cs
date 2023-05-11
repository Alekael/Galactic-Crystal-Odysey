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
    public float baseDownForce = 2f;
    private float saveBase;
    public float downForce = 4f;
    public float maxDownForce = 4f;
    public bool fall= false;
    public GameObject _projectile;
    public List<GameObject> _projectileList;
    public Transform firePoint;
    public float cooldown = 0f;
    public float timer = 0.5f;
    public AudioSource _audioSource;
    public List<AudioSource> _sounds;
    private SpriteRenderer _renderer;
    public int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        //_audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
        firePoint = transform.Find("firePoint");
        saveBase = baseDownForce;

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

        if (Mathf.Abs(_body.velocity.x) > 2f && !_sounds[0].isPlaying && grounded && !PauseMenu.isPaused) {
            _sounds[0].Play();
        }
        if(Mathf.Abs(_body.velocity.x) < 2f && _sounds[0].isPlaying) { _sounds[0].Stop();}

        _body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0.0f) &&  Mathf.Abs(_body.velocity.y) < 0.1f) ? 0.0f : baseDownForce;

        if(_body.velocity.y < 0 && baseDownForce < maxDownForce){ baseDownForce += downForce * Time.deltaTime; /*print(baseDownForce);*/ } 
        else { baseDownForce = saveBase;}

        
        if (grounded && Input.GetKeyDown("w") && !PauseMenu.isPaused) {
            _sounds[3].Play();
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
             
        if(_body.velocity.y < 0){
            _anim.SetBool("isFalling", true);
        }else { _anim.SetBool("isFalling", false);}

        _anim.SetBool("isGrounded", grounded);
        
        if(Input.GetKey("space") && !PauseMenu.isPaused){
            _anim.SetBool("isShooting", true);
            //print("space key was pressed");
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
        Vector2 corner2 = new Vector2(min.x + .1f, min.y - .1f);

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
        //print("shoot");
        if(_audioSource != null) _audioSource.Play();
        Instantiate(_projectile, firePoint.position, firePoint.rotation);        
        cooldown = timer;
    }

    public void UpdateHealth(int dmg){
        /*if(dmg < 0){
            _renderer.color = Color.red;
        }*/
        lives = lives + dmg;
        if(dmg < 0){
            StartCoroutine(DamageEffect());
        }
        GameObject.Find("HUD").GetComponent<HUDscript>().updateHUD(lives);
        Debug.Log("lives updated: " + lives);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("CanBePickedUp")) {
            Item item = other.gameObject.GetComponent<Consumable>().item;
            if(item != null){
                switch(item.itemType){ 
                    case Item.ItemType.HEALTH: 
                        if(lives < 5){    
                            _sounds[1].Play();      
                            UpdateHealth(item.quantity);
                            other.gameObject.SetActive(false);
                        }break;  

                    case Item.ItemType.DAMAGE:
                        _sounds[2].Play();
                        ProjectileSwap(item.quantity, item.id);
                        other.gameObject.SetActive(false); 
                        break;

                    case Item.ItemType.SPEED:
                        _sounds[2].Play();
                        ProjectileSwap(item.quantity, item.id);
                        other.gameObject.SetActive(false); 
                        break;            
                }
            }
        }
    }
    public int getLives(){
        return lives;
    }

    void OnDrawGizmosSelected(){
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x - .1f, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x + .1f, min.y - 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(corner1, corner2);
    }

    void ProjectileSwap(int countdown, int pos){    
        _projectile = _projectileList[pos];
        _audioSource.clip = _projectileList[pos].GetComponent<AudioSource>().clip;
        StartCoroutine(DamageBoostCountdown(countdown));
    }

    IEnumerator DamageBoostCountdown(int countdown){
        yield return new WaitForSeconds(countdown);
        _projectile = _projectileList[0];
        _audioSource.clip = _projectileList[0].GetComponent<AudioSource>().clip;
    }

    IEnumerator DamageEffect(){
        _renderer.color = Color.red;
        yield return new WaitForSeconds(1);
        _renderer.color = Color.white;
    }

}
