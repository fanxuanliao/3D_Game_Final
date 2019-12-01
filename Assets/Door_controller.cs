using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_controller : MonoBehaviour
{
    public GameObject door; //取得門
    bool open = false; //是否可以開門
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(open==true && door.transform.eulerAngles.y < 60) // 可以開門 & 門開到一半
        {
         //   float v = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            door.transform.Rotate(new Vector3(0, 1, 0));
        }
    }
    /*
    public void hit() //點到門
    {
        bool key = GameObject.Find("Inventory").GetComponent<Item_manager>().has_key; //是否持有key
        if (key) //若玩家持有key則開門
        {
            open = true; //可開門
            GameObject.Find("Inventory").GetComponent<Item_manager>().door_opened(); //呼叫物品欄，已開門

        }
        else //若沒有持有key則提示"需要Key"
        {
            locked_message.SetActive(true);
            StartCoroutine(DelayTime());  //三秒後文字再次消失(樓下)
        }
        IEnumerator DelayTime()
        {
            yield return new WaitForSeconds(3f);
            locked_message.SetActive(false);
        }
    }
    */
}
//(以door_axis當軸來讓門"打開")(function可以設為public以讓player呼叫)
