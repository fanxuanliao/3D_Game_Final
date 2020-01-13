using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class player_fungus_village : MonoBehaviour
{
    public Flowchart flowchart;
    private bool cantalk = false;
    private bool OS_Invastigated_avialible = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetIntegerVariable("InvestigatedNum") == 4 && OS_Invastigated_avialible == true)
        {
            Flowchart.BroadcastFungusMessage("OS_Invastigated");
            OS_Invastigated_avialible = false;
        }
    }

    public void OnCollisionEnter(UnityEngine.Collision other)
    {
        switch (other.gameObject.name)
        {
            case "Scene_Boundary":
                if (flowchart.GetIntegerVariable("InvestigatedNum") < 4)
                    Flowchart.BroadcastFungusMessage("Bumped_Boundary");
                else
                    Flowchart.BroadcastFungusMessage("Bumped_Boundary_Invastigated");
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

    public void GoInToHeadHouse()
    {
        SceneManager.LoadScene(4);
    }

    public void send_messege(string object_name)
    {
        //比對物件名字送出相應fungus messege
        if (cantalk)
        {
            cantalk = false;
            switch (object_name)
            {
                case "villagerA":
                    Flowchart.BroadcastFungusMessage("talkToVillagerA");
                    break;
                case "villagerB":
                    Flowchart.BroadcastFungusMessage("talkToVillagerB");
                    break;
                case "villagerC":
                    Flowchart.BroadcastFungusMessage("talkToVillagerC");
                    break;
                case "villagerD":
                    Flowchart.BroadcastFungusMessage("talkToVillagerD");
                    break;
                case "village_head":         
                    if (flowchart.GetBooleanVariable("finishedWellTask") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToVillageHead_DoneWellTask");
                    }
                    else if (flowchart.GetBooleanVariable("BeenToHeadHouse") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToVillageHead_EnteredHouse");
                    }
                    else {
                        Flowchart.BroadcastFungusMessage("talkToVillageHead_init");
                    }
                    break;
                case "weapon_keeper":
                    if (flowchart.GetIntegerVariable("InvestigatedNum") > 3 && flowchart.GetBooleanVariable("MailTaskRecieved") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_invastigated");
                    }
                    else if (flowchart.GetBooleanVariable("BeenToHeadHouse") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_DoneDelievery");
                    }
                    else {
                        Flowchart.BroadcastFungusMessage("talkToWeaponKeeper_init");
                    }
                    break;
                case "grocery_keeper":
                    if (flowchart.GetBooleanVariable("OrderTaskRecieved") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToGroceryKeeper_OrderTaskRecieved");
                    }
                    else
                    {
                        Flowchart.BroadcastFungusMessage("talkToGroceryKeeper_init");
                    }
                    break;
                case "inn_keeper":
                    if (flowchart.GetBooleanVariable("DoneOrderTask") == true)
                    {
                        Flowchart.BroadcastFungusMessage("talkToInnKeeper_DoneOrderTask");
                    }
                    else
                    {
                        Flowchart.BroadcastFungusMessage("talkToInnKeeper_init");
                    }
                    break;
                case "OpenSmallRoom":
                    Flowchart.BroadcastFungusMessage("OpenSmallRoom");
                    break;
                case "OS_GoInHeadHouse":
                    Flowchart.BroadcastFungusMessage("OS_GoInHeadHouse");
                    break;
                case "EmptyChest":
                    Flowchart.BroadcastFungusMessage("OS_EmptyChest");
                    break;
                case "Inn_sign":
                    Flowchart.BroadcastFungusMessage("CheckInnSign");
                    break;
                case "Grocery_sign":
                    Flowchart.BroadcastFungusMessage("CheckGrocerySign");
                    break;
                case "Rabbit":
                    Flowchart.BroadcastFungusMessage("Rabbit");
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
                case "religion_manA":
                    Flowchart.BroadcastFungusMessage("talkToReligionA");
                    break;
                case "religion_manB":
                    Flowchart.BroadcastFungusMessage("talkToReligionB");
                    break;
                case "religion_manC":
                    Flowchart.BroadcastFungusMessage("talkToReligionC");
                    break;
                case "religion_manD":
                    Flowchart.BroadcastFungusMessage("talkToReligionD");
                    break;
                case "Well":
                    if (flowchart.GetBooleanVariable("WellTaskRecieved") == true)
                        Flowchart.BroadcastFungusMessage("OS_DoWellTask");
                break;
                case "WellSuccess":
                    Flowchart.BroadcastFungusMessage("OS_WellSuccess");
                    break;
                case "headDoor":
                    Flowchart.BroadcastFungusMessage("EnterHeadHouse");
                    break;
                default:
                    break;
            }
        }
    }
 }
