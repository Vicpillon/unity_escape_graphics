using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_work : MonoBehaviour
{
    // Start is called before the first frame update
    public int clicked = 0;
    float[] original_po = new float[3];
    //float[] original_ro = new float[3];
    
    void Start()
    {
        original_po[0] = transform.position.x;
        original_po[1] = transform.position.y;
        original_po[2] = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void work(){
        if(clicked != 2){
            Rigidbody r = GetComponent<Rigidbody>();
            r.isKinematic = false;
            clicked += 1;
        }
    }

    public void reset(){
        Rigidbody r = GetComponent<Rigidbody>();
        Vector3 v = new Vector3(original_po[0], original_po[1], original_po[2]);
        Vector3 ro = new Vector3((float)0.0, (float)0.0 ,(float)0.0);
        Quaternion ro_q = Quaternion.Euler(ro); 
        transform.position = v;
        transform.rotation = ro_q;
        r.isKinematic = true;

        clicked = 0;
    }
}
