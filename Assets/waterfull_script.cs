using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfull_script : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(water_ui.waterfull == 1)
        {
            for(int w=0; w<708; w++)
            {
                RectTransform rt = this.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(w, 100);
            }
            
            StartCoroutine(Wait());    
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        water_ui.waterfull = 0;
    }
}
