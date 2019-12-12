using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Fungus;

public class Lock_controller : MonoBehaviour
{
    [SerializeField] Material[] password;
    float raylength = 4.0f;
    int index;
    //哪個圖
    int ID;
    //位置
    int[] inputPassword = new int[4];
    //記每個圖是哪個圖
    enum doorLock : int
    {
        Plane_1,
        Plane_2,
    //    Plane_3,
    //    Plane_4,
        Plane_5,
        Plane_6,
    }
    //索引
    // Start is called before the first frame update
    void Start()
    {
        index = -1;
        //從0開始但會先+所以設-1
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        //射線
        if (Physics.Raycast(ray, out hit, raylength))
        {
            if (hit.transform.tag == "doorpuzzle")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (index < 5) index++;
                    else index = 0;
                    //index = ( 0, 6 )
                    hit.transform.gameObject.GetComponent<Renderer>().material = password[index];
                    //改變material
                    ID = (int)Enum.Parse(typeof(doorLock), hit.transform.name);
                    inputPassword[ID] = index;
                    //print(inputPassword[0] +" "+ inputPassword[1]+" " + inputPassword[2] +" "+ inputPassword[3]);
                    //把密碼記下來
                }
            }
        }
        if (inputPassword[0] == 3 && inputPassword[1] == 2 &&
            inputPassword[2] == 5 && inputPassword[3] == 4)
        {
            Flowchart.BroadcastFungusMessage("magic_Unlock");
            gameObject.SetActive(false);
        }
    }
}
