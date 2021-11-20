using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_model : MonoBehaviour
{
    public float speed;
    public float gravity = -9.81f;
    public float jumpPower = 10;

    float yVelocity=0;
    float xAxis;
    float zAxis;
    bool sDown;

    CharacterController cc;
    Vector3 moveVec;

    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //yVelocity += gravity * Time.deltaTime;
        /*
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");
        */
        sDown = Input.GetButtonDown("Jump");
        //moveVec = new Vector3(xAxis, 0, zAxis);

        //transform.position += moveVec *gravity * Time.deltaTime;
        yVelocity += gravity * Time.deltaTime;

        if (sDown)
        {
            yVelocity = jumpPower;
            //transform.position += moveVec * jumpPower;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        dir.y = yVelocity;
        

        /*
        moveVec = Camera.main.transform.TransformDirection(moveVec);
        moveVec.Normalize();

        moveVec.y = yVelocity;
        */
        //move
        //transform.position += moveVec * speed * Time.deltaTime;
        /*
        cc.Move(moveVec * speed * Time.deltaTime);
        */
        
        cc.Move(dir * speed * Time.deltaTime);
        //transform.LookAt(transform.position + dir);
        //animation
        ani.SetBool("isWalk", dir != Vector3.zero);
        ani.SetBool("isJump", sDown);

    }
  
    

}
