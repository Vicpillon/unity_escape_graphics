// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class next_ui : MonoBehaviour
// {

//     private Transform WateringCan;
//     public Text txt;
//     // Start is called before the first frame update
//     void Start()
//     {
//         WateringCan = GameObject.Find("Clue_3").transform.Find("WateringCan");
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(water_ui.next == 1)
//         {
//             //txt.text = "모든 화분에 물을 주세요 ...";
//             //WateringCan.transform.Rotate(Vector3.down * 0);
//             StartCoroutine(Wait());
//         }
//     }
    
//     IEnumerator Wait()
//     {
//         yield return new WaitForSeconds(3.0f);
//         txt.text = " ";
//         water_ui.next = 0;
//         wateringcan_script.water = 2;
//     }

// }
