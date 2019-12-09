using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Puzzle_manager : MonoBehaviour
{
    float raylength;
    private GameObject underBed;
    // Start is called before the first frame update
    void Start()
    {
        raylength = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raylength)) //out是被打到ㄉ
        {


            if (hit.transform.gameObject.tag == "puzzle") //點到的東西可以互動
            {
                switch (hit.transform.gameObject.name)
                {
                    case "DIRTYFLOOR":
                        if (Input.GetMouseButtonUp(0))
                        {
                            //player.GetComponent<player_fungus>().send_messege(hit.transform.name);
                            //fungus說地板很髒
                            print("髒髒"); //debug
                        }

                        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Player").GetComponent<Pickup_controller>().ability[2])
                        //已裝水 & 按下E使用
                        {
                            Destroy(hit.transform.gameObject);
                            //把髒污給清掉
                        }

                        break;

                    case "WATER":
                        if (Input.GetMouseButtonUp(0) )
                        //點擊漏水的地方
                        {
                            //player.GetComponent<player_fungus>().send_messege(hit.transform.name);
                            //fungus這裡怎麼在漏水
                        }
                        if (Input.GetKeyDown(KeyCode.E) && GameObject.Find("Player").GetComponent<Pickup_controller>().ability[1])
                        {
                            GameObject.Find("Player").GetComponent<Pickup_controller>().ability[2] = true;
                            print("裝水水");
                            //裝水
                        }
                        break;
                    case "BED":
                        if (Input.GetMouseButtonUp(0))
                        {
                            //player.GetComponent<player_fungus>().send_messege(hit.transform.name);
                            //fungus說床下有東C
                        }

                        if (Input.GetKeyDown(KeyCode.R) && GameObject.Find("Player").GetComponent<Pickup_controller>().ability[2])
                        //有掃把 & 按下R使用
                        {
                            //underBed.SetActive(true);
                            //把線索setActive
                        }
                        break;
                }
            }

        }
    }
}
