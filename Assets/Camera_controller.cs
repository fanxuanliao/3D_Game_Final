using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鏡頭跟著滑鼠移動'
        float view_y = 1f * Input.GetAxis("Mouse Y");
        transform.Rotate(-view_y, 0, 0);

    }
}
