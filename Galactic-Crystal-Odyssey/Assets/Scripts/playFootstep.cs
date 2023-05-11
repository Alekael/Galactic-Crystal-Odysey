using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playFootstep : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;

    // Update is called once per frame
    void step()
    {
            _audio.Play();
    }
}
