using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        var answer = col.gameObject;
        
        if(answer.tag == "key"){
            open_clue2();
        }
    }

    void open_clue2(){
        enterDoor door ;
        door = GameObject.Find("door").GetComponent<enterDoor>();
        door.open = true;
    }
}
