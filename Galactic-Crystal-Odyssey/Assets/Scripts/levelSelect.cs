using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelSelect : MonoBehaviour
{
    public List<GameObject> planets;
    private int index = 0;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = planets[index].transform.position;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d")){
            if(index == planets.Count-1) {
                index = 0;
            } 
            else{
                index++;
            }
            _audio.Play();
            gameObject.transform.position = planets[index].transform.position;
        }

        if(Input.GetKeyDown("a")){
            if(index == 0) {
                index = planets.Count-1;
            } 
            else{
                index--;
            }
            _audio.Play();
            gameObject.transform.position = planets[index].transform.position;
        }


        if(Input.GetKeyDown("space")){
            Select();
        }
    }

    public void Select(){
        SceneManager.LoadScene(planets[index].name);
    }
}
