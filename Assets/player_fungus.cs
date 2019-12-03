using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void send_messege(string object_name)
    {
        //比對物件名字送出相應fungus messege
        if (object_name == "helmet")
            Flowchart.BroadcastFungusMessage("pick_armor");
    }
}

