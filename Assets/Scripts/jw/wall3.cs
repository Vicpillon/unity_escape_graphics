using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall3 : MonoBehaviour
{   
    Vector3 target = new Vector3(49.23f, 2.0f, -31.57f);

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
