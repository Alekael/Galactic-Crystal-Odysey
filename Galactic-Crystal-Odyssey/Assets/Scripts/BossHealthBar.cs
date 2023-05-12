using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public HitPoints Points;
    public Image meterImage;
    public Slider slider;
    // Update is called once per frame
    void Start(){
        /*Points = GameObject.Find("Boss").GetComponent<GameEntity>().hitpoints;
        Debug.Log("hitpoints Gotted");*/
    }
    
    void Update()
    {
        Points = GameObject.Find("Boss").GetComponent<GameEntity>().getHp();
        //meterImage.fillAmount = (float)Points.hitPoints / Points.maxHitPoints;
        slider.value = Points.hitPoints;
        Debug.Log(Points.hitPoints.ToString());       
    }

    /*public void setHitPoints(HitPoints s){
        Points = s;
        Debug.Log("hitpoints set healthbar");
    }*/
}
