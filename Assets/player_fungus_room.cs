using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus_room : MonoBehaviour
{
    public Flowchart flowchart;
    private bool cantalk = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "talk_zone")
            cantalk = true;
    }


    public void send_messege(string object_name)
    {
        //比對物件名字送出相應fungus messege
        if (cantalk)
        {
            cantalk = false;
            switch (object_name)
            {
                case "OpenSmallRoom":
                    Flowchart.BroadcastFungusMessage("OpenSmallRoom");
                    break;
                case "EmptyChest":
                    Flowchart.BroadcastFungusMessage("OS_EmptyChest");
                    break;
                case "Bed":
                    Flowchart.BroadcastFungusMessage("CheckBed");
                    break;
                case "Plants":
                    Flowchart.BroadcastFungusMessage("CheckPlants");
                    break;
                case "WineBoxes":
                    Flowchart.BroadcastFungusMessage("CheckWinesBoxes");
                    break;
                
            case "DeerStick":
                Flowchart.BroadcastFungusMessage("CheckDeerStick");
                break;
            case "CornerBoxes":
                Flowchart.BroadcastFungusMessage("CheckCornerBoxes");
                break;
            case "FoodsStock":
                Flowchart.BroadcastFungusMessage("CheckFoodsStock");
                break;
                case "FoodsOnDesk":
                    Flowchart.BroadcastFungusMessage("CheckFoodsOnDesk");
                    break;
                case "Banana":
                    Flowchart.BroadcastFungusMessage("CheckBanana");
                    break;
                case "Books":
                    Flowchart.BroadcastFungusMessage("CheckBooks");
                    break;
                case "Gambling":
                    Flowchart.BroadcastFungusMessage("CheckGambling");
                    break;
                case "Cactus":
                    Flowchart.BroadcastFungusMessage("CheckCactus");
                    break;

                default:
                    break;
            }
        }
    }
}

