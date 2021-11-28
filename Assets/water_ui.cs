using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class water_ui : MonoBehaviour
{
    //private Transform percent;
    //public static int next = 0;
    int temp = 0;
    public Text txt;
    public static int waterfull = 0;
    //private Transform  next;
    public static int next=0;
    public static int stop_watering = 0;
    public float full = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.SetActive(false);
        //next = GameObject.Find("Canvas").transform.Find("next");
        //GameObject waterfull = transform.Find("waterfull").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        print(wateringcan_script.water);
        
        if(wateringcan_script.water == 1)
        {
            full += Time.deltaTime*15;
            txt.text = Mathf.Round(full) +" %";
        }

        if(Mathf.Round(full) == 100)
        {
            if(stop_watering==0)
            {
                stop_watering = 1;
            }
            
            StartCoroutine(Wait());
        } 
    }

    IEnumerator Wait()
    {
        //print("여기가 오긴 오나?");
        yield return new WaitForSeconds(0.0f);
        gameObject.SetActive(false);
        full = 0;
        //next = 1;
        //next.gameObject.SetActive(true);
        
    }
    
}
