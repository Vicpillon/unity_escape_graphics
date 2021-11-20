using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_button2 : MonoBehaviour
{
    // Start is called before the first frame update
   balance_work a;
    void Start()
    {
        a = GameObject.Find("balance_top").GetComponent<balance_work>();
        //Rigidbody r = GameObject.Find("balance_top").GetComponent<Rigidbody>();

    }

    void OnMouseDown()
    {
        Debug.Log("clicked!!!");
        a.reset();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(a);
    }
}