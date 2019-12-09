using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_controller : MonoBehaviour
{
    public GameObject puzzleLock;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.Find("Player").GetComponent<Pickup_controller>().stairs)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //把collider關掉
            puzzleLock.SetActive(true);
            //把門上的謎題打開
        }
        */
        if (GameObject.Find("Player").GetComponent<Pickup_controller>().ability[0])
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzleLock.SetActive(true);
             
        }
        //測試用上面才是真條件

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            //player.GetComponent<player_fungus>().send_messege("back");
            //撞到fungus不能過
            print("撞牆");
        }
    }
}
