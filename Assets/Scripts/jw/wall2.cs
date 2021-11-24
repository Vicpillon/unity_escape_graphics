using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall2 : MonoBehaviour
{   
    Vector3 target = new Vector3(46.78f, 4.37f, -27.9f);

    public bool a;
    // Start is called before the first frame update
    void Start()
    {
        bool a = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(a) transform.position = Vector3.Lerp(transform.position, target, 0.005f);
    }
}
