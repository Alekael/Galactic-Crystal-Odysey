using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectils : MonoBehaviour
{
    public GameObject _projectile;
    public Transform firePoint;
    float timeoutDuration = 1;
    float timeout = 1;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("bossfirePoint");
        Instantiate(_projectile, firePoint.position, firePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout > 0)
        {   
            timeout -= Time.deltaTime;
            return;
        }
        Instantiate(_projectile, firePoint.position, firePoint.rotation);
        timeout = timeoutDuration;
    }
}
