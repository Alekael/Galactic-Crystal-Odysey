using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    public Transform target;
   public float smoothTime = 0.2f;
   public float xAxis = 2.0f;
   public float yAxis = 2.0f;
   public int statik = 0;

   private Vector3 _velocity = Vector3.zero;
    void Update () {
        if(statik == 1){
            Vector3 targetPosition = new Vector3(xAxis, yAxis, transform.position.z);
            transform.position = Vector3.SmoothDamp(targetPosition,transform.position, ref _velocity, smoothTime);
        }
        if(statik == 0){
            Vector3 targetPosition = new Vector3(xAxis, target.position.y + yAxis, transform.position.z);
            transform.position = Vector3.SmoothDamp(targetPosition,transform.position, ref _velocity, smoothTime);
        }
    }
}
