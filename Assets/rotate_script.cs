using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rotate_script : MonoBehaviour
{
    private Vector3 m_Offset;
    private float m_ZCoord;

    public static bool ultimateEnd = false;

    Vector3 offset;

    private bool onclick;
    private GameObject target;

    void OnMouseDown()
    {
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


    float rotateSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.Rotate(Vector3.down * rotateSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target.Equals(gameObject))
            {
                if (onclick = true)
                {
                    ultimateEnd = true;
                }
                else
                {
                    onclick = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col){
        var answer = col.gameObject;
        Debug.Log("온트리거 확인");

        if(answer.tag == "door_1" && ultimateEnd){
            Debug.Log("여기 되냐고!!!");
            ultimate_end();
        }

    }

    void ultimate_end()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameClear");

    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
