using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue1 : MonoBehaviour
{
    public bool end;
    bool onclick;
    bool startmoving;
    float angle;
    public int dir = 0;
    AudioSource rotate_audio;
    Transform origin;
    Transform target;

    Quaternion OriginalRotation;
    Quaternion plusRotation = Quaternion.Euler(new Vector3(90, 0, 0));
    Quaternion targetRotation;

    public GameObject[] bottle;

    private void Start()
    {
        end = false;
        onclick = false;
        startmoving = false;
        rotate_audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!end) { 
        if (onclick)
        {
            if (startmoving)
            {
                origin = GetComponent<Transform>();
                OriginalRotation = origin.rotation;
                targetRotation = OriginalRotation * plusRotation;
                startmoving = false;

            }
            origin = GetComponent<Transform>();
            OriginalRotation = origin.rotation;
            transform.rotation = Quaternion.Lerp(OriginalRotation, targetRotation ,0.2f);
            angle = Quaternion.Angle(OriginalRotation, targetRotation);
            if (angle <= 0.01) { onclick = false; transform.rotation = targetRotation; }
        }
        }
    }

    private void OnMouseDown()
    {
        if (!end) { 
            if (onclick == false) {
                onclick = true;
                startmoving = true;
                rotate_audio.Play();
                if (dir != 3) dir++;
                else dir = 0;
            }
          }

    }

}
    
   

