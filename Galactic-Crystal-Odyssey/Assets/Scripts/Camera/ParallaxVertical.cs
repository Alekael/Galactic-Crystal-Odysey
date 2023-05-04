using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxVertical : MonoBehaviour
{
    // Start is called before the first frame update
    private float width, startPosition;
private Transform cam;
public float parallaxFraction;
void Start() {
startPosition = transform.position.y;
width = GetComponent<SpriteRenderer>().bounds.size.y;
cam = Camera.main.transform;
}
void LateUpdate() {
float offset = (cam.position.y * parallaxFraction);
float moved = cam.position.y - offset;
if (moved > startPosition + width) startPosition += width;
else if (moved < startPosition - width) startPosition -= width;
transform.position = new Vector3(transform.position.x,
startPosition + offset,
transform.position.z);
}

}
