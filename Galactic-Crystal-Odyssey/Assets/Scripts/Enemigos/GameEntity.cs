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
        if (hitpoints.hitPoints <= 0) {
            hitpoints.hitPoints = 0;
            Die();
        } else {
            if (OnHitEvent != null) {
                OnHitEvent(damage);
            }
        }
    }
    public void Die() {
        if (OnDieEvent != null) {
            OnDieEvent();
        }
        enabled = false;
    }
}

