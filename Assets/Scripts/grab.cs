using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    double dtor(double a){
    return a*Math.PI/180;
    }
    void OnMouseDown(){
        float[] camPo = new float[3] {Camera.main.transform.position.x, Camera.main.transform.position.y, (float)(Camera.main.transform.position.z+1.5)};

        Vector3 v = new Vector3(
            camPo[0]*(float)Math.Sin(dtor(Camera.main.transform.rotation.eulerAngles.y)), 
            camPo[1]*(float)Math.Sin(dtor(-Camera.main.transform.rotation.eulerAngles.x)), 
            camPo[2]*(float)Math.Cos(dtor(Camera.main.transform.rotation.eulerAngles.y))*(float)Math.Cos(dtor(-Camera.main.transform.rotation.eulerAngles.x)));
        Rigidbody r = GetComponent<Rigidbody>();
        transform.position = v;
        r.useGravity = false;

        Debug.Log(Math.Sin(Camera.main.transform.rotation.y*Math.PI/180));
        Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
        
    }

    void OnMouseDrag(){
        Vector3 v = new Vector3(Camera.main.transform.position.x+2, Camera.main.transform.position.y, Camera.main.transform.position.z);
        transform.position = v;
    }

    void OnMouseUp(){
        Rigidbody r = GetComponent<Rigidbody>();
        r.useGravity = true;
    }
}
