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
        //게임 오버시 gameover scene으로 넘어감
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
            // Count 0일때 동작할 함수 삽입
            LoadOver();

        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }

    }
}
