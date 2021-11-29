using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone_script : MonoBehaviour
{
    private bool onclick;
    private int count;
    private GameObject target;

    public static int hello = 0;

    float rotateSpeed = 10.0f;
    Vector3 offset;

    AudioSource audio;

    
    // Start is called before the first frame update
    void Start()
    {
        onclick = false;
        count = 0;
        
    }

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);


        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if(target.Equals(gameObject))
            {
                hello = 1;
                audio.Play();
            }
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(true == (Physics.Raycast(ray.origin, ray.direction*10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}