using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinet_script_2 : MonoBehaviour
{
    private bool onclick;
    private int count;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        onclick = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target.Equals(gameObject))
            {
                if (onclick = true)
                {
                    if (count == 0)
                    {
                        transform.Translate(0.5f, 0, 0.5f);
                        onclick = false;
                        count = 1;
                    }
                    else
                    {
                        transform.Translate(-0.5f, 0, -0.5f);
                        count = 0;
                    }
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
}