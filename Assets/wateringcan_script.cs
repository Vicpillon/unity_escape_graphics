using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wateringcan_script : MonoBehaviour
{
    private Vector3 m_Offset;
    private float m_ZCoord;

    //private bool watercan_touched = false;
    //public int waterfull = 0;
    public static int order = 0;
    public static int water = 0;
    // public static int num = 0;
    // public static int next = 0;

    float rotateSpeed = 3.0f;
    Vector3 offset;

    private bool onclick;
    private GameObject target;
    private Transform obj1;
    private Transform obj2;

    
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

    void Start()
    {
        obj1 = GameObject.Find("Canvas").transform.Find("order");
        obj2 = GameObject.Find("Canvas").transform.Find("water");
    }

    void Update()
    {
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
                    transform.Rotate(Vector3.down*0);
                    obj1.gameObject.SetActive(true);
                    //print("체크");

                    if(order == 0)
                    {
                        order = 1;
                        //print(order);
                    }
                    //Debug.Log("제발");
                    //print(order);
                }
                else
                {
                    onclick = true;
                }
            }
        }
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

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "mob_WaterCooler_Y")
        {
            Debug.Log("enter");
            if(water==0)
            {
                obj2.gameObject.SetActive(true);
                Debug.Log("물로 넘어감");
            }
            
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.name== "mob_WaterCooler_Y")
        {
            Debug.Log("stay");
            print("water " + water);
            if(water== 0)
            {
                water = 1;
            }
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.name== "mob_WaterCooler_Y")
        {
            Debug.Log("exit");
            //order = 2;
        }
    }

}




