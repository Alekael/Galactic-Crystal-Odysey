using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    //Color colorSemitransparente = new Color(1f, 1f, 1f, 0.5f); // Crear un nuevo objeto de color semitransparente con un valor de alfa de 0.5
    Color colorOpaco = new Color(1f, 1f, 1f, 1f); // Crear un nuevo objeto de color semitransparente con un valor de alfa de 0.5


    void Start(){
        health = GameObject.FindWithTag("Player").GetComponent<PlayerMov_V2>().getLives();
        numOfHearts = health;
        //Debug.Log(health);
        
        for (int i = 0; i < hearts.Length; i++){
            if(i< numOfHearts){
                hearts[i].enabled = true;
                hearts[i].material.color = colorOpaco;
            } else {
                hearts[i].enabled = false;
            }

        }
    }

    public void Update(){

        if(health > numOfHearts){
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].enabled = true;
                hearts[i].sprite = fullHeart;
                hearts[i].material.color = colorOpaco;
            } else {
                hearts[i].enabled = false;
                //hearts[i].sprite = emptyHeart;
                //hearts[i].material.color = colorSemitransparente;
            
            }
        }
    }

    public void updateHUD(int lvs){
        health = lvs;
    }

}
