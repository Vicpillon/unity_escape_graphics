using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance_button1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    balance_work a;
    Transform top;
    Vector3 visible = new Vector3(36.95f, 0.6f, -8.7f);
    Vector3 invisible = new Vector3(36.95f, -2.0f, -8.7f);

    AudioSource clickAudio;
    void Start()
    {
        transform.position = invisible;
        top = GameObject.Find("balance_top").transform;
        clickAudio = GetComponent<AudioSource>();
    }

    void Update(){
        a = GameObject.Find("balance_top").GetComponent<balance_work>();

        if(a.clicked == 1){
            transform.position = visible;
        }
        else{
             transform.position = invisible;
        }
    }


    void OnMouseDown()
    {
        if(top.rotation.eulerAngles.x == 0.0f){
            clickAudio.Play();
            a.work();
            if(!a.onclick){
                Invoke("upBalance", 3.0f);
            }
            Debug.Log("1 button clicked");
        }
    }

    void upBalance(){
        a.onclick = true;
        a.startmoving = true;
    }


}
