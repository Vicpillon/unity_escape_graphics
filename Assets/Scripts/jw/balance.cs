using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown(){
        Rigidbody r = GetComponent<Rigidbody>();
        r.useGravity = true;
    }
}
