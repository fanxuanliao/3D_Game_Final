using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_controller : MonoBehaviour
{
    public float Camera_move = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鏡頭跟著滑鼠移動'
        float view_y = Camera_move * Input.GetAxis("Mouse Y");
        transform.Rotate(-view_y, 0, 0);
        
        Cursor.visible = false;//隱藏滑鼠
        Cursor.lockState = CursorLockMode.Locked;//把滑鼠鎖定到螢幕中間

    }
}
