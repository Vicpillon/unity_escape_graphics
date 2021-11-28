using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool open;
    Vector3 target = new Vector3(29.993f, -2.95f, -8.98f);
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(open) transform.position = Vector3.Lerp(transform.position, target, 0.002f);
    }
}
