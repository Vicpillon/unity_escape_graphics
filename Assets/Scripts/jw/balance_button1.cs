using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_button1 : MonoBehaviour
{
    // Start is called before the first frame update
    balance_work a;
    void Start()
    {
        a = GameObject.Find("balance_top").GetComponent<balance_work>();
    }

    void OnMouseDown()
    {
        a.work();
        if(!a.onclick){
            Invoke("upBalance", 3.0f);
        }
    }

    void upBalance(){
        a.onclick = true;
        a.startmoving = true;
    }


}
