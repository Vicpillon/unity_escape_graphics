using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    public float time = 9f;
    private float selectCountdown;

    public string sceneName = "GameOver";


    public void LoadOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneName);
        //���� ������ gameover scene���� �Ѿ
    }

    // Start is called before the first frame update
    void Start()
    {
        selectCountdown = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            // Count 0�϶� ������ �Լ� ����
            LoadOver();

        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }

    }
}
