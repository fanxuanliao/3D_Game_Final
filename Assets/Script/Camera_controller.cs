using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Camera_controller : MonoBehaviour
{
    public float x;
    public float y;
    public float xSpeed = 50f;
    public float ySpeed = 50f;

    private Quaternion rotationEuler;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        lockMouse();
        //遊戲開始時鎖定滑鼠
    }

    // Update is called once per frame
    void Update()
    {
        //鏡頭跟著滑鼠移動'

        if (flowchart.GetBooleanVariable("talking") == false)
        {
            y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;

            if (y > 85) y = 85;
            else if (y < -70) y = -70;

            rotationEuler = Quaternion.Euler(-y, x, 0);
            GameObject.Find("Player").transform.rotation = Quaternion.Euler(0, x, 0);
            transform.rotation = rotationEuler;

        }
    }
    public void unlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void lockMouse()
    {
        Cursor.visible = false;//隱藏滑鼠
        Cursor.lockState = CursorLockMode.Locked;//把滑鼠鎖定到螢幕中間
                                                 //在fungus中用call method呼叫即可直接用
    }
}