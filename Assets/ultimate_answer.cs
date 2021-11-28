using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ultimate_answer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        var answer = col.gameObject;
        
        if(answer.tag == "ultimate_key"){
            ultimate_end();
        }

    }

    void ultimate_end()
    {
        SceneManager.LoadScene("GameClear");
    }
}
