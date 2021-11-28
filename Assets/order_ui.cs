using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class order_ui : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;
    public static int activate = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        print(wateringcan_script.order);
    
        if(wateringcan_script.order == 1)
        {
            activate = 1;
            txt.text = "드래그를 이용해 물을 채워주세요 ...";
            StartCoroutine(Wait());
            //print("코루틴 되나?");
        }

            // if (wateringcan_script.order == 2)
            // {
            //     //gameObject.SetActive(false);
            //     txt.text = " ";
            // }
        print("stop watering" + water_ui.stop_watering);

        if (water_ui.stop_watering == 1)
        {
            activate = 1;
            //gameObject.SetActive(false);
            txt.text = "물을 더이상 채우지 않아도 됩니다.";
            StartCoroutine(Wait2());
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        txt.text = " ";
        wateringcan_script.order = 2;
        activate = 0;
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.0f);
        txt.text = "모든 화분에 물을 주세요 ...";
        water_ui.stop_watering = 2;
        wateringcan_script.water = 2;
        collider_clue.touch = 1;
        collider_clue_1.touch = 1;
        collider_clue_2.touch = 1;
        collider_clue_3.touch = 1;
        activate = 0;
    }
}
