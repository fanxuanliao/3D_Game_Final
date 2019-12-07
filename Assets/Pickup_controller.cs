using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_controller : MonoBehaviour
{
    //滑鼠射線設定
    Ray ray; //射線
    RaycastHit hit; //被打到的物件
    float raylength = 5f; //射線長度
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //ray在camera中間
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
        //Debug.DrawRay(transform.position, forward, Color.yellow);


        if (Physics.Raycast(ray, out hit, raylength)) //out是被打到ㄉ
        {

            if (Input.GetMouseButtonUp(0)) //按下滑鼠
            {
                if (hit.transform.gameObject.tag == "interactive") //點到的東西可以互動
                {
                    //跳出資訊
                    //放到背包callUI
                    //子物件?

                    //消滅物件
                    //print("should destroy");
                    Destroy(hit.transform.gameObject);
                    //讓技能controller可以++
                }
                else if (hit.transform.gameObject.tag == "clues") // 線索物件
                {
                    //跳出資訊
                    //放到背包UI
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.gameObject.tag == "checking") //調查物件
                {
                    player.GetComponent<player_fungus>().send_messege(hit.transform.name); //用fungus顯示物品資訊
                }
                else if (hit.transform.gameObject.tag == "Door")
                {
                    hit.transform.gameObject.GetComponent<Door_controller>().hit();
                }
            }
        }
    }
    //outline可互動物件
    //分辨他是那一類物件
}
