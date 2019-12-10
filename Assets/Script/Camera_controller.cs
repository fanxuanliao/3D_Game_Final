using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Camera_controller : MonoBehaviour
{
    public float Camera_move = 4f;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鏡頭跟著滑鼠移動'
        if (flowchart.GetBooleanVariable("talking") == false)
        {
            float view_y = Camera_move * Input.GetAxis("Mouse Y");
            transform.Rotate(-view_y, 0, 0);
        /*    
            if (GameObject.Find("Player").GetComponent<player_fungus>().Camera_lock == true)
            {
                Cursor.visible = false;//隱藏滑鼠
                Cursor.lockState = CursorLockMode.Locked;//把滑鼠鎖定到螢幕中間
            } else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
          */  
        }

    }
}
