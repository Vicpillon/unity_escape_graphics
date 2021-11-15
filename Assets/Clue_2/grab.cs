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
        float[] camPo = new float[3] {Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z};

        Vector3 v = new Vector3(
            camPo[0]+(float)Math.Sin(dtor(Camera.main.transform.rotation.eulerAngles.y))*2, 
            camPo[1]-(float)Math.Sin(dtor(Camera.main.transform.rotation.eulerAngles.x))*2, 
            camPo[2]+(float)Math.Cos(dtor(Camera.main.transform.rotation.eulerAngles.y))*(float)Math.Cos(dtor(-Camera.main.transform.rotation.eulerAngles.x))*2
            );
        Rigidbody r = GetComponent<Rigidbody>();
        transform.position = v;
        r.useGravity = false;
    }

    void OnMouseDrag(){
        float[] camPo = new float[3] {Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z};
        

        Vector3 v = new Vector3(
            camPo[0]+(float)Math.Sin(dtor(Camera.main.transform.rotation.eulerAngles.y))*2, 
            camPo[1]-(float)Math.Sin(dtor(Camera.main.transform.rotation.eulerAngles.x))*2, 
            camPo[2]+(float)Math.Cos(dtor(Camera.main.transform.rotation.eulerAngles.y))*(float)Math.Cos(dtor(-Camera.main.transform.rotation.eulerAngles.x))*2
            );

        transform.position = v;
    }

    void OnMouseUp(){
        Rigidbody r = GetComponent<Rigidbody>();
        r.useGravity = true;
    }
}
