using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    //public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ
    public GameObject chatPanel;
    AudioSource audio;
    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        Time.timeScale = 0;//Ÿ�̸� ����
        chatPanel.SetActive(true);//��ȭ �г� on
        StartCoroutine(Text());
    }
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Awake�Լ� �߰����ְ� 
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

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //Ű�� �ٽ� ���� �� ���� ������ ���
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
        yield return StartCoroutine(NormalChat("���Ⱑ �����? ���� ��ü ��þ�?"));
        yield return StartCoroutine(NormalChat("ȸ�� ��ٽð��� ���� ��� �ǰ�?"));
        yield return StartCoroutine(NormalChat("���迡�� ��ȭ�� ���߰ھ�!"));
        Time.timeScale = 1;
        chatPanel.SetActive(false);
        audio.Play();
    }
}
