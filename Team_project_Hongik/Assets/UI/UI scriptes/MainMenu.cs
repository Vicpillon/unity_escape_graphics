using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public void OnClickNewGame()
    {
        //Debug.Log("�� ����");
    }

    public void OnClickLoad()
    {
        //Debug.Log("�ε�");
    }

    public void OnClickOption()
    {
        //Debug.Log("�ɼ�");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    } 





}
