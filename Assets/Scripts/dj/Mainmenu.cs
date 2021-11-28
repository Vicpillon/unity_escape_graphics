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
        //게임 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Menu_button()
    {   //esc 누르면 submenu 나옴
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;//타이머 멈춤
            menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
           
        }
    }

    public void Continue()
    {
        //버튼 누르면 게임 지속
        Time.timeScale = 1;//타이머 지속
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
