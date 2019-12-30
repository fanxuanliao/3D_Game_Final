using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus_village : MonoBehaviour
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

    public void OnCollisionEnter(UnityEngine.Collision other)
    {
        switch (other.gameObject.name)
        {
            case "Scene_Boundary":
                Flowchart.BroadcastFungusMessage("Bumped_Boundary");
                break;
            default:
                break;
        }
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
                case "VillagerA":
                    Flowchart.BroadcastFungusMessage("talkToVillagerA");
                    break;
                case "VillagerB":
                    Flowchart.BroadcastFungusMessage("talkToVillagerB");
                    break;
                case "VillagerC":
                    Flowchart.BroadcastFungusMessage("talkToVillagerC");
                    break;
                case "VillagerD":
                    Flowchart.BroadcastFungusMessage("talkToVillagerD");
                    break;
                case "talkToVillageHead_init":
                    Flowchart.BroadcastFungusMessage("talkToVillageHead_init");
                    break;
                case "talkToWeaponKeeper_init":
                    Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_init");
                    break;
                case "talkToGroceryKeeper_init":
                    Flowchart.BroadcastFungusMessage("talkToGroceryKeeper_init");
                    break;
                case "talkToInnKeeper_init":
                    Flowchart.BroadcastFungusMessage("talkToInnKeeper_init");
                    break;
                case "talkToVillageHead_DoneWellTask":
                    Flowchart.BroadcastFungusMessage("talkToVillageHead_DoneWellTask");
                    break;
                case "talkToVillageHead_EnteredHouse":
                    Flowchart.BroadcastFungusMessage("talkToVillageHead_EnteredHouse");
                    break;
                case "talkToWeaponKeeper_invastigated":
                    Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_invastigated");
                    break;
                case "talkToWeaponKeeper_TalkedToReligion":
                    Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_TalkedToReligion");
                    break;
                case "talkToWeaponKeeper_DoneDelievery":
                    Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_DoneDelievery");
                    break;
                case "OpenSmallRoom":
                    Flowchart.BroadcastFungusMessage("OpenSmallRoom");
                    break;
                case "OS_GoInHeadHouse":
                    Flowchart.BroadcastFungusMessage("OS_GoInHeadHouse");
                    break;
                case "OS_EmptyChest":
                    Flowchart.BroadcastFungusMessage("OS_EmptyChest");
                    break;
                case "OS_Invastigated":
                    Flowchart.BroadcastFungusMessage("OS_Invastigated");
                    break;

                default:
                    break;
            }
        }
    }
 }
