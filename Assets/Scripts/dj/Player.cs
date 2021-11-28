using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpSpeed = 5;
    public float downSpeed = 5;
    private Vector3 speed;
    private float forwardSpeed;
    private float sideSpeed;
    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;
    Animator ani;
    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        
        FPMove();
        FPRotate();

    }



    void FPMove()
    {

        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;


        if (cc.isGrounded && Input.GetButtonDown("Jump"))
            verticalVelocity = jumpSpeed;



        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;


        ani.SetBool("isWalk", (Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0));
        ani.SetBool("isJump", Input.GetButtonDown("Jump"));
        cc.Move(speed * Time.deltaTime);
    }


    void FPRotate()
    {

        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }


    // https://wemakejoy.tistory.com/43 Âü°í

}