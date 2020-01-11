using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Pickup_controller : MonoBehaviour
{
    //滑鼠射線設定
    Ray ray; //射線
    RaycastHit hit; //被打到的物件
    float raylength = 4f; //射線長度
    public GameObject player;
    public GameObject magic;
    public GameObject transport;
    public Flowchart flowchart;
    public Button diary;
    public GameObject diary_effect;
    private bool clear;

    enum intereactiveIndex : int
    {
        BROOM,
        BUCKET,
        WATER
    }

    enum cluesIndex : int
    {
        HELMET,
        UNDERBED,
        SKELETON,
        DIARY
    }

    internal bool[] ability = new bool[]{ false, false, false };
    internal bool[] backpack = new bool[]{ false, false, false, false ,false};
    internal bool stairs = false;

    // Start is called before the first frame update
    void Start()
    {
        clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(backpack[0] && backpack[1] && backpack[2] && backpack[3])
        {
            stairs = true;
        }
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
                    ability[index] = true;
                    //檢查點到東西的名稱，把ability的真假值改掉 
                    //print(ability[index]); //debug
                    Destroy(hit.transform.gameObject);
                    GameObject.Find("UI_manager").GetComponent<UI_controller>().itembool[index] = true;

                }
                else if (hit.transform.gameObject.tag == "clues") // 要蒐集的物件
                {
                    if (hit.transform.gameObject.name == "DIARY")
                    {
                        
                        if(backpack[0] && backpack[1] && backpack[2])
                        {
                            if (!clear)
                            {
                                GameObject.Find("Obstacle").GetComponent<BoxCollider>().enabled = false;
                                magic.SetActive(true);
                                transport.SetActive(true);
                                backpack[4] = true;
                                player.GetComponent<player_fungus>().send_messege("basement_door");
                                //fungus多說亮起了奇怪的光
                                diary_effect.SetActive(true);
                                clear = true;
                            }
                            else
                            {
                                diary.gameObject.SetActive(true);
                            }
                        }
                        else
                        {
                            backpack[3] = true;
                            GameObject.Find("UI_manager").GetComponent<Backpack_controller>().backpackbool[3] = true;
                            player.GetComponent<player_fungus>().send_messege("diary_explaination");//到這一行之前都有執行 只有fungus出不來 whywhywhyhow
                            //解釋要有所有勇者ㄉ證明才能打開
                        }
                    }
                    else
                    {
                        int index = (int)Enum.Parse(typeof(cluesIndex), hit.transform.gameObject.name);
                        backpack[index] = true;
                        //檢查點到東西的名稱，把backpack的真假值改掉
                        Destroy(hit.transform.gameObject);
                        GameObject.Find("UI_manager").GetComponent<Backpack_controller>().backpackbool[index] = true;

                    }
                }
                else if (hit.transform.gameObject.tag == "checking") //調查物件
                {
                        player.GetComponent<player_fungus>().send_messege(hit.transform.name);//用fungus顯示物品資訊
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
            {
                diary.gameObject.SetActive(false);
            }
        }
    }
    //outline可互動物件
    //分辨他是那一類物件
}
