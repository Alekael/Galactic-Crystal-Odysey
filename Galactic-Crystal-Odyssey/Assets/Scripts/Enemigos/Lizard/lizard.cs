using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class lizard : Enemy
{
private GameObject player;
    private Rigidbody2D rb2d;
    public float speed;
    private Animator anim;
    private SpriteRenderer _renderer;
    public GameObject _projectile;
  

    protected override void OnWake() {
        Debug.Log("Detected");
        
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (!player) {
            Debug.LogError("Cannot find the player");
        }
        anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        anim.SetTrigger("Detected");
        if (_renderer == null){
        Debug.LogError("Sprite is missing a renderer");
        }
    }
   /* void Atacks(){
        var heading = this.transform.position - Atacking.gameObject.transform.position;
        if (Atacking.CompareTag("Player") && !sleeping && heading.sqrMagnitude < maxRange * maxRange) {
            var player = Atacking.gameObject.GetComponent<PlayerMov_V2>();
            player.UpdateHealth(atDmg);
            }
        
        }*/

    void Update() {
        player = GameObject.FindGameObjectWithTag("Player");
        var heading = gameObject.transform.position - player.transform.position;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        if (sleeping || player == null) return;
        if(heading.sqrMagnitude < maxRange/2 * maxRange/2) {
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Detected");
            rb2d.velocity = direction * 0;
            return;
            }
            rb2d.velocity = direction * speed;
            anim.ResetTrigger("Detected");
            anim.SetTrigger("Walk");
            
            
          

        if ( direction.x < 0){
        _renderer.flipX = false;
        }
        else if (direction.x > 0){
        _renderer.flipX = true;
        } 
        }

        protected override void OnHit(int damage) {
            Debug.Log("flyEye hit");
            anim.SetTrigger("Hit");
        }

        protected override void OnDie() {
            Debug.Log("flyEye dies");
            
            anim.SetTrigger("Die");

        }



        public Transform bulletSource;
    public float bulletForce = 10.0f;

public void Shoot() {
ShootWave(1, Random.Range(100, 110), Random.Range(190, 210));
/*StartCoroutine(WaitAndShootWave(0.2f, 1, Random.Range(100, 110), Random.Range(150, 170)));
StartCoroutine(WaitAndShootWave(0.4f, 1, Random.Range(140, 160), Random.Range(180, 220)));*/
}

IEnumerator WaitAndShootWave(float delay, int numBullets, float minAngle, float maxAngle) {
yield return new WaitForSeconds(delay);
ShootWave(numBullets, minAngle, maxAngle);
}

private void ShootWave(int numBullets, float minAngle, float maxAngle) {
float incrAngle = (maxAngle - minAngle) / (numBullets - 1);
for (int i = 0; i < numBullets; i++) {
GameObject bullet = Instantiate(_projectile, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
float angle = Mathf.Deg2Rad * (minAngle + incrAngle * i);
//var heading = this.transform.position - Atacking.gameObject.transform.position;
//Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
Vector2 dir = new Vector2(player.gameObject.transform.position.x - this.transform.position.x  ,player.gameObject.transform.position.y - this.transform.position.y);
rb.velocity = Vector2.zero;
rb.angularVelocity = 0.0f;
rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);
}
}


}
