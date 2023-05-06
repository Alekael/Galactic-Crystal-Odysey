using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectils : MonoBehaviour
{
    public GameObject _projectile;
    public GameObject firepoint;
    float timeoutDuration = 3;
    float timeout = 3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_projectile,firepoint.transform.position,firepoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout > 0)
        {   
            timeout -= Time.deltaTime;
            return;
        }
        Instantiate(_projectile,firepoint.transform.position,firepoint.transform.rotation);
        timeout = timeoutDuration;
    }
}
