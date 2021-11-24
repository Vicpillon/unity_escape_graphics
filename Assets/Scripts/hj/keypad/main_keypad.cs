using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class main_keypad : MonoBehaviour
{
    public int a, b, c, d;
    int[] password = new int[4]; // 정답 비밀번호 
    public int[] input = new int[4];  //입력비밀번호
    public int count = 0;

    bool result;
   public  bool open;
    bool move;

    Transform target;
   
    Transform door;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        password[0] = a;
        password[1] = b;
        password[2] = c;
        password[3] = d;
        input[0] = -1;
        input[1] = -1;
        input[2] = -1;
        input[3] = -1;

        door = GameObject.FindGameObjectWithTag("door").GetComponent<Transform>();
        open = false;
        move = false;
        target = GameObject.FindGameObjectWithTag("target").GetComponent<Transform>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            if (count == 4)
            {

                result = password.SequenceEqual(input);
                if (result)
                {
                    move = true;
                    open = true;
                }
                else
                {
                    audio.Play();
                    count = 0;
                }
            }
        }
        if (move)// 문 움직임 시작 
        {
            door.position = Vector3.Lerp(door.position, target.position, Time.deltaTime);
        }
    }
}
