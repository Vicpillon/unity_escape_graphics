using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    public float turnSpeed = 3.0f; 
    public float moveSpeed = 2.0f; 

    private float xRotate = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
        //KeyboardMove();
    }
    void MouseRotation()
    {   
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;

        float yRotate = transform.eulerAngles.y + yRotateSize;

        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 20);
       
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
    /*
    void KeyboardMove()
    {
        
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    */
}
