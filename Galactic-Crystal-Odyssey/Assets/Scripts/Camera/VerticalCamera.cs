using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    public Transform target;
   public float smoothTime = 0.2f;
   public float xAxis = 2.0f;
   public float yAxis = 2.0f;

   private Vector3 _velocity = Vector3.zero;
    void Update () {
        Vector3 targetPosition = new Vector3(xAxis, target.position.y + yAxis, transform.position.z);
        transform.position = Vector3.SmoothDamp(targetPosition,transform.position, ref _velocity, smoothTime);
    }
}
