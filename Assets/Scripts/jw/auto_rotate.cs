using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    float y = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        y += 0.05f;
        transform.rotation = Quaternion.Euler((float)0,y,(float)0);
    }
}
