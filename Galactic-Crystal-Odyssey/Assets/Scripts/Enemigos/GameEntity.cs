using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour {
    public delegate void Notify();
    public event Notify OnWakeEvent;
    public event Notify OnDieEvent;
    public delegate void NotifyDamage(int damage);
    public event NotifyDamage OnHitEvent;
    public HitPoints hitpoints;



    protected virtual void Start() {
        hitpoints = Instantiate(hitpoints);
        hitpoints.hitPoints = hitpoints.initialHitPoints;
        Debug.Log("hitpoints SET gameEntity");
    }


    public HitPoints getHp(){
        return hitpoints;
    }

    public void Wake() {
        enabled = true;
        if (OnWakeEvent != null) {
            OnWakeEvent();
        }
    }
    public void TakeDamage(int damage) {
        if (!enabled) return;
            hitpoints.hitPoints -= damage;
            StartCoroutine(FlickerCharacter());

        if (hitpoints.hitPoints <= 0) {
             Debug.Log("Muere boss");
            hitpoints.hitPoints = 0;
            Die();
        } else {
            if (OnHitEvent != null) {
                OnHitEvent(damage);
            }
        }
    }
    public virtual IEnumerator FlickerCharacter() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    public void Die() {
        if (OnDieEvent != null) {
            Debug.Log("Muere game entity");
            OnDieEvent();
        }
        enabled = false;
    }
}

