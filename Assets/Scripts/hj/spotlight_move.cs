using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spotlight_move : MonoBehaviour
{
    bool end;
    public GameObject  puzzle;
    Transform me;
    Transform target;
    Light light_on;
    
    AudioSource rotate_audio;
    bool rotate_start;
  

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

                if (rotate_start == false)
                {
                    rotate_start = true;
                    rotate_audio.Play();

                }
                OriginalRotation = me.rotation;
                transform.rotation = Quaternion.Lerp(OriginalRotation, targetRotation, 0.005f);
                angle = Quaternion.Angle(OriginalRotation, targetRotation);
                if (angle <= 10)
                {
                    transform.rotation = targetRotation;
                    light_on.enabled = true;
                    if (!puzzle_gravity_on)
                    {
                        for (int i = 0; i < 16; i++)
                        {

                            
                            bottle[i].AddComponent<Rigidbody>();
                            bottle[i].GetComponent<Clue1>().end = true;
                            puzzle_gravity_on = true;
                            end = true;
                        }
                        key.AddComponent<BoxCollider>();
                        battery.AddComponent<Rigidbody>();
                    }

                }
            }
            else
            {
                light_on.enabled = false;
            }
        }
        }
    }
