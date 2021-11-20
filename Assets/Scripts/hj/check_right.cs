using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_right : MonoBehaviour
{
   
    public GameObject[] bottle;
    public int[] answer = { 3, 3, 3, 3, 1, 3, 3, 1, 3, 1, 3, 1, 3, 1, 3, 3 };

    public bool seed;
    public int bottlenumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seed = true;
        check();
    }
    
    void check()
    {
        bottle = GameObject.FindGameObjectsWithTag("puzzle");
        for (int i = 0; i < 16; i++)
        {
            if (i == 4 || i == 7 || i == 9 || i == 11 || i == 13 || i == 15)
            {
                if (bottle[i].GetComponent<Clue1>().dir == 1 || bottle[i].GetComponent<Clue1>().dir == 3) seed = seed && true;
                else seed = seed && false;
                continue;

            }
            if (bottle[i].GetComponent<Clue1>().dir == answer[i])
            {
                seed = seed && true;
            }
            else { seed = seed && false; }

            
        }
        
    }
}
