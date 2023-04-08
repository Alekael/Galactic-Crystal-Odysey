using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
   public Transform target;
   public float smoothTime = 0.2f;
   public float yAxis;
   private Vector3 _velocity = Vector3.zero;
    void Update () {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yAxis, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
}

}
