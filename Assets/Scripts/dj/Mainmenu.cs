using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public string sceneName = "GameStage";
    public GameObject menuPanel;//submenu

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
            Time.timeScale = 0;//Ÿ�̸� ����
            menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
           
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Menu_button();
       
    }
}
