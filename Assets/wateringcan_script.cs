using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateringcan_script : MonoBehaviour
{
    private Vector3 m_Offset;
    private float m_ZCoord;

    void OnMouseDown()
    {
        //ui 발생했다 끄기
        m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + m_Offset;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_ZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void Update()
    {

    }
}




