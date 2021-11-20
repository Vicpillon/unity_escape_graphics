using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float gravity = -9.81f;
    public float jumpPower = 2.5f;
    float yVelocity;
    bool sDown;

    CharacterController cc;
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
        yVelocity += gravity * Time.deltaTime;
        sDown = Input.GetButtonDown("Jump");
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        ani.SetBool("isWalk", dir != Vector3.zero);
        ani.SetBool("isJump", sDown);

        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        dir.y = 0;
        //transform.LookAt(transform.position + dir);

        dir.y = yVelocity;
        cc.Move(dir * speed * Time.deltaTime);



    }
}
