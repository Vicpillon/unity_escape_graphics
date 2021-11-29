using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public Text ChatText; // 실제 채팅이 나오는 텍스트
    //public Text CharacterName; // 캐릭터 이름이 나오는 텍스트
    public GameObject chatPanel;
    AudioSource audio;
    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        Time.timeScale = 0;//타이머 멈춤
        chatPanel.SetActive(true);//대화 패널 on
        StartCoroutine(Text());
    }
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Awake함수 추가해주고 
    void Update()
    {
        if (order_ui.activate == 1)
        {
            chatPanel.SetActive(true);
        }
        if(total_clue.end ==1)
        {
            chatPanel.SetActive(false);
        }
     

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isButtonClicked = true;
        }
        if (phone_script.hello == 1)
        {
            audio.Stop();
        }
    }


    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        //CharacterName.text = narrator;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를 때 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;

        }
        
    }

    IEnumerator Text()
    {
        yield return StartCoroutine(NormalChat("여기가 어디지? 지금 대체 몇시야?"));
        yield return StartCoroutine(NormalChat("회사 퇴근시간에 깜박 잠든 건가?"));
        yield return StartCoroutine(NormalChat("선배에게 전화해 봐야겠어!"));
        Time.timeScale = 1;
        chatPanel.SetActive(false);
        audio.Play();
    }
}
