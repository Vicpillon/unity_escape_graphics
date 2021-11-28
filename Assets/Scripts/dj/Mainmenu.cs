using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public string sceneName = "GameStage";
    public GameObject menuPanel;//submenu
    bool stop;
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickExit()
    {
        //���� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Menu_button()
    {   //esc ������ submenu ����
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!stop)
            {
                stop = true;
                Time.timeScale = 0;//Ÿ�̸� ����
                menuPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                stop = false;
                Time.timeScale = 1;//Ÿ�̸� ����
                menuPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
                    
                    
          }
       
    }

    public void Continue()
    {
        //��ư ������ ���� ����
        Time.timeScale = 1;//Ÿ�̸� ����
        menuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called before the first frame update
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Menu_button();
       
    }
}
