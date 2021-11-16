using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinet_open : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    int speed = 100;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            float fMove = Time.deltaTime * speed;
            transform.Translate(Vector3.forward*fMove);
        }
    }
    

}
