using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class collider_clue_1 : MonoBehaviour
{
    public static int touch = 0;


    public Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(touch == 1 && collision.name == "WateringCan")
        {
            txt.text = "2번 화분에 물을 주었습니다.";
            Transform plant = gameObject.transform.GetChild(0);
            plant.gameObject.SetActive(true);
            total_clue.second = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        
    }

    private void OnTriggerExit(Collider collision)
    {
        
    }
}
