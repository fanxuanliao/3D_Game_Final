using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Pickup_controller_village : MonoBehaviour
{
    //滑鼠射線設定
    Ray ray; //射線
    RaycastHit hit; //被打到的物件
    float raylength = 4f; //射線長度
    public GameObject player;
    public Flowchart flowchart;
    public Button diary;

    
    enum intereactiveIndex : int
    {

    }

    enum cluesIndex : int
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ray在camera中間
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
        Debug.DrawRay(transform.position, forward, Color.yellow);


        if (Physics.Raycast(ray, out hit, raylength)) //out是被打到ㄉ
        {

            if (Input.GetMouseButtonUp(0)) //按下滑鼠
            {
                if (hit.transform.gameObject.tag == "interactive") //可以使用的道具
                {

                    int index = (int)Enum.Parse(typeof(intereactiveIndex), hit.transform.gameObject.name);

                    //檢查點到東西的名稱，把ability的真假值改掉 
                    //print(ability[index]); //debug
                    Destroy(hit.transform.gameObject);

                }
                else if (hit.transform.gameObject.tag == "clues") // 要蒐集的物件
                {
                    if(hit.transform.gameObject.name == "diary")
                    {
                        diary.gameObject.SetActive(true);
                    }
                }
                else if (hit.transform.gameObject.tag == "checking") //調查物件
                {
                    if (flowchart.GetBooleanVariable("talking") == false)
                    {
                        player.GetComponent<player_fungus_village>().send_messege(hit.transform.name);//用fungus顯示物品資訊
                    }
                    if (hit.transform.gameObject.name == "Target_Box")
                    {
                        print("拿到貨物");
                        Flowchart.BroadcastFungusMessage("check_targetbox");
                        flowchart.SetBooleanVariable("DoneBoxTask", true);
                    }
                }
                
                else if (hit.transform.gameObject.tag == "Door")
                {
                    hit.transform.gameObject.GetComponent<Door_controller>().hit();
                }
            }
        }
        if (diary.gameObject.activeSelf)
        {
            if (Input.anyKey)
                diary.gameObject.SetActive(false);
        }
    }
    //outline可互動物件
    //分辨他是那一類物件
}
