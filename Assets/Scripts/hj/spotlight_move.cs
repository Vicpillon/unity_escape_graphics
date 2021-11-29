using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spotlight_move : MonoBehaviour
{

    bool end;
    // puzzle 이 complite 되었는가? 
    public GameObject  puzzle;
    // 16 개의 퍼즐이 모두 올바른 방향을 향해 있는지 확인하기 위한 object
    Transform me;
    Transform target;

    Light light_on;
    // spotlight 를 켜기위한 Light 변수
    public Text txt;
    // 퍼즐 완료시 화면 UI 우측상단에 숫자를 표시하기위한 Text 변수 
    
    AudioSource rotate_audio;
    //spot light 회전시 소리
    bool rotate_start;
   //회전이 이미 시작했음을 알려주는 변수 

    Quaternion OriginalRotation;
    Quaternion targetRotation;

    float angle;

    bool puzzle_gravity_on;
    public GameObject[] bottle;// 퍼즐에 중력작용 위함
    public GameObject battery;
    public GameObject key;


    /*
     GameObject goImage = GameObject.Find("Canvas/Image");
        Color color = goImage.GetComponent<Image>().color;
        color.a = 0.5f;
        goImage.GetComponent<Image>().color = color;*/

    // Start is called before the first frame update
    void Start()
    {
        end = false;
        bottle = GameObject.FindGameObjectsWithTag("puzzle");
        battery = GameObject.FindGameObjectWithTag("battery");
        key = GameObject.FindGameObjectWithTag("key");
        puzzle_gravity_on = false;
        // puzzle 완료시 중력작용을 하기위한 bool 변수 
        me = transform;
        target = GameObject.FindGameObjectWithTag("spotlight_target").GetComponent<Transform>();
        targetRotation  = Quaternion.LookRotation(target.position - me.position);
        light_on = GameObject.FindGameObjectWithTag("spotlight_hj").GetComponent<Light>();
        rotate_audio = GetComponent<AudioSource>();
        rotate_start = false;

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            puzzle = GameObject.FindGameObjectWithTag("is_right");
            if (puzzle.GetComponent<check_right>().seed == true)
            {

                if (rotate_start == false) // spotlight 회전시 audio 는 한번만 나야함 .
                {
                    rotate_start = true;
                    rotate_audio.Play();

                }
                OriginalRotation = me.rotation;
                transform.rotation = Quaternion.Lerp(OriginalRotation, targetRotation, 0.02f);// 현재 OriginalRotation 값에서 TargetRotation 값까지 선형보간 
                angle = Quaternion.Angle(OriginalRotation, targetRotation);// 현재 OriginalRotation 값에서 TargetRotation 값의 각도차이 
                if (angle <= 10)// 각도차이가 일정 값 이하로 떨어지면 마무리 
                { 
                    transform.rotation = targetRotation;
                    light_on.enabled = true; // 회전 완료후  spotlight 켜주기 
                    if (!puzzle_gravity_on)
                    {
                        for (int i = 0; i < 16; i++) // 퍼즐 16개에 중력작용 
                        {

                            
                            bottle[i].AddComponent<Rigidbody>();
                            bottle[i].GetComponent<Clue1>().end = true;
                            puzzle_gravity_on = true;
                            end = true;
                        }
                        key.AddComponent<BoxCollider>(); 
                        battery.AddComponent<Rigidbody>(); //battery 에 rigidbody(중력) 더함 
                    }
                    txt.text = "4";

                }
            }
            else
            {
                light_on.enabled = false;
            }
        }
        }
        
    }
