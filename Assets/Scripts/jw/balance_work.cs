using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_work : MonoBehaviour
{
    // Start is called before the first frame update
    public int clicked = 0;
    public bool onclick;
    public bool startmoving;
    float angle;
    Transform origin;
    Transform target;
    Quaternion OriginalRotation;
    Quaternion targetRotation;
    public float[] original_po = new float[3];
    public int ranBall;
    public Rigidbody ballR;
    public string ballName;
    public Vector3[] place = new Vector3[9];
    public GameObject answer, nonAnswer, ball;
    
    void Start()
    {
        original_po[0] = transform.position.x;
        original_po[1] = transform.position.y;
        original_po[2] = transform.position.z;

        for(int i=0; i<9; i++){
            ballR = GameObject.Find("ball" + i).GetComponent<Rigidbody>();
            nonAnswer = GameObject.Find("ball" + i);
            ballR.mass = 2;
            nonAnswer.tag = "clue2_nonAnswer";
            place[i] = nonAnswer.transform.position;
        }
        
        ranBall = (int)UnityEngine.Random.Range(0,9);
        ballR = GameObject.Find("ball" + ranBall).GetComponent<Rigidbody>();
        ballR.mass = 2.5f;
        Debug.Log("ball"+ ranBall + " is Answer.");

        answer = GameObject.Find("ball" + ranBall);
        answer.tag = "clue2_answer";
    }

    private void Update()
    {
        if (onclick)
        {
            if (startmoving)
            {
                origin = GetComponent<Transform>();
                OriginalRotation = origin.rotation;
                targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                startmoving = false;

                Rigidbody r = GetComponent<Rigidbody>();
                Vector3 v = new Vector3(original_po[0], original_po[1], original_po[2]);

                r.isKinematic = true;
                transform.position = v;
            }  
            origin = GetComponent<Transform>();
            OriginalRotation = origin.rotation;
            transform.rotation = Quaternion.Slerp(OriginalRotation, targetRotation , 0.01f);
            angle = Quaternion.Angle(OriginalRotation, targetRotation);
            if (angle <= 0.1) { onclick = false; transform.rotation = targetRotation; }
        }
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

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.position = v;
        r.isKinematic = true;
        
        
        clicked = 0;

        for(int i=0; i<9; i++){
            ballName = "ball" + i;
            ballR = GameObject.Find("ball" + i).GetComponent<Rigidbody>();
            nonAnswer = GameObject.Find("ball" + i);
            ballR.mass = 2;
            nonAnswer.tag = "clue2_nonAnswer";
        }
        
        ranBall = (int)UnityEngine.Random.Range(0,9);
        ballR = GameObject.Find("ball" + ranBall).GetComponent<Rigidbody>();
        ballR.mass = 2.5f;
        Debug.Log("ball"+ ranBall + " is Answer.");

        answer = GameObject.Find("ball" + ranBall);
        answer.tag = "clue2_answer";

        ballBackToPlace();
    }

    public void ballBackToPlace(){
        for(int i=0;i<9;i++){
            ball = GameObject.Find("ball" + i);
            ball.transform.position = place[i];
            ballR = GameObject.Find("ball" + i).GetComponent<Rigidbody>();
            ballR.isKinematic = true;
            ballR.isKinematic = false;
        }
    }
}
