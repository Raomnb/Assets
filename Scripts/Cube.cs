using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
   
    
   
    public bool click = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            click = true;
        }
    }

}
