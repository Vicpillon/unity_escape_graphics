using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    //public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ
    public GameObject chatPanel;

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        Time.timeScale = 0;//Ÿ�̸� ����
        chatPanel.SetActive(true);//��ȭ �г� on
        StartCoroutine(Text());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isButtonClicked = true;
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
    }
}
