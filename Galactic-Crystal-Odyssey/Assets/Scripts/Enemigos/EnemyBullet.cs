using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public float speed = 5;
    public int direction = 1;
    public float timer = 5;
    public GameObject _bulletDestroy;


    public int damage;
    public string damageOnlyToTag;

    // Update is called once per frame
    void Update()
    {     
        gameObject.transform.Translate(transform.TransformDirection(Vector3.left) * speed * Time.deltaTime * direction);
            
        gameObject.transform.localScale = new Vector3(direction, 1,1);

        timer -= 2f * Time.deltaTime;
        if(timer < 0.0f) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col){
        Instantiate(_bulletDestroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Die() {
        Instantiate(_bulletDestroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (damageOnlyToTag=="Player" && other.CompareTag(damageOnlyToTag)){
            Die();
            var player = other.gameObject.GetComponent<PlayerMov_V2>();
            player.UpdateHealth(damage);
            return;
        }
        
        if (damageOnlyToTag == "" || other.CompareTag(damageOnlyToTag)) {
            
            GameEntity hit = other.gameObject.GetComponentInParent<GameEntity>();
             if (hit != null) {
                
                 hit.TakeDamage(damage);
            }
        
        }
       Die(); 
    }
}
