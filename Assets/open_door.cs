using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource opening;
    void Start()
    {
        opening = GameObject.Find("door").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        var answer = col.gameObject;
        
        if(answer.tag == "key"){
            opening.Play();
            open_clue2();
        }

    }

    void open_clue2(){
        enterDoor door ;
        door = GameObject.Find("door").GetComponent<enterDoor>();
        door.open = true;
    }

}
