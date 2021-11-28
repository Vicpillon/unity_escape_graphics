using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class total_clue : MonoBehaviour
{
    //public static int check = 0;
    public Text txt;
    public Text txt1;
    public static int end =0;

    public static bool first = false;
    public static bool second = false;
    public static bool third = false;
    public static bool fourth = false;

    AudioSource audio;


    private Transform waterCan;
    // Start is called before the first frame update
    void Start()
    {
        waterCan = GameObject.Find("CornerCabinet1").transform.Find("WateringCan");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(first && second && third && fourth)
        {   
            //print("여기 왔는가");
            //audio.Play();
            txt1.text = " 힌트 : 이진수 입니다.";
            txt.text = "?";
            StartCoroutine(Wait());
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        end = 1;
    }
}
