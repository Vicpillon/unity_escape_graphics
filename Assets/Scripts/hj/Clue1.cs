using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue1 : MonoBehaviour
{
   public  bool check; 
    //올바른 방향을 향하고 있으면 true 
    public bool one_way;
    // 1자 회선 puzzle 은 true
    public bool end;  
    // puzzle clue 가 완전히 끝났음을 알려줌 
    bool onclick;   
    // click 되었는지 ? 
    bool startmoving; 
    // click 되어서 rotate 를 시작하는지?
    float angle;
    // target rotation 값과의 회전각 차이를 없애기 위한 변수 
    public int dir = 0;
    // dir 값에따라 방향을 나타냄 
    AudioSource rotate_audio;
    // 퍼즐이 회전하는소
    Transform origin;
    Transform target;

    Quaternion OriginalRotation;
    Quaternion plusRotation = Quaternion.Euler(new Vector3(90, 0, 0));
    // x 축을 기준으로 90 도 회전하기위해 plusRotation 값을 설정 
    Quaternion targetRotation;

    public GameObject[] bottle;

    private void Start()
    {
        end = false;
        onclick = false;
        startmoving = false;
        rotate_audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!end) { // puzzle clue 가 끝나지 않았는가?
        if (onclick)// click event 가 이루어 졌는가? 
        {
            if (startmoving)
            {
                origin = GetComponent<Transform>(); 
                OriginalRotation = origin.rotation; // 현재 회전각도 구함
                targetRotation = OriginalRotation * plusRotation;// target 회전각 구함
                startmoving = false;

            }
            origin = GetComponent<Transform>();
            OriginalRotation = origin.rotation;
            transform.rotation = Quaternion.Lerp(OriginalRotation, targetRotation ,0.2f); // target rotation 값까지 0.2 값으로 선형보간
            angle = Quaternion.Angle(OriginalRotation, targetRotation); // target 과 object 의 현재 rotation 의 회전각의 차이를 구함 
            if (angle <= 0.01) {// 각도차이가 일정값 이하로 떨어졌을때 마무리
                    onclick = false; transform.rotation = targetRotation; }
        }
        }
    }

    private void OnMouseDown()
    {
        if (!end) { 
            if (onclick == false) {
                onclick = true;
                startmoving = true;
                rotate_audio.Play();
                if (dir != 3) dir++;
                else dir = 0;
            }
          }

    }

}
    
   

