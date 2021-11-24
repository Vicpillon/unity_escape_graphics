using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_rotate : MonoBehaviour
{
    balance_work a;
    // Start is called before the first frame update
    float y = 0.0f;
    // Update is called once per frame
    void Update()
    {
        y += 0.05f;
        transform.rotation = Quaternion.Euler((float)0,y,(float)0);
    }

    void OnTriggerEnter(Collider col){
        a = GameObject.Find("balance_top").GetComponent<balance_work>();
        var answer = col.gameObject;
        
        if(answer.tag == "clue2_answer"){
            Debug.Log("I made it!!");
            move_walls();
        }
        else if(answer.tag == "clue2_nonAnswer"){
            a.reset();
            Debug.Log(answer.tag);
        }
    }

    void move_walls(){
        wall0 a0;
        a0 = GameObject.Find("wall0").GetComponent<wall0>();
        a0.a = true;
        wall1 a1;
        a1 = GameObject.Find("wall1").GetComponent<wall1>();
        a1.a = true;
        wall2 a2;
        a2 = GameObject.Find("wall2").GetComponent<wall2>();
        a2.a = true;
        wall3 a3;
        a3 = GameObject.Find("wall3").GetComponent<wall3>();
        a3.a = true;
        wall4 a4;
        a4 = GameObject.Find("wall4").GetComponent<wall4>();
        a4.a = true;
        wall6 a6;
        a6 = GameObject.Find("wall6").GetComponent<wall6>();
        a6.a = true;
        wall7 a7;
        a7 = GameObject.Find("wall7").GetComponent<wall7>();
        a7.a = true;
        wall8 a8;
        a8 = GameObject.Find("wall8").GetComponent<wall8>();
        a8.a = true;
        wall9 a9;
        a9 = GameObject.Find("wall9").GetComponent<wall9>();
        a9.a = true;
    }
}
