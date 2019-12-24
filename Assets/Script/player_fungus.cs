    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus : MonoBehaviour
{
    public bool Camera_lock = true;
    public GameObject hero3;
    public Flowchart flowchart;
    private bool cantalk = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("allAnswerRight") == true)
        {
            Give_hero_3();
        }
    }

    public void OnTriggerEnter(Collider other) {
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
                case "helmet":
                    Flowchart.BroadcastFungusMessage("pick_armor");
                    break;
                case "Happy_skull":
                    Flowchart.BroadcastFungusMessage("TalkToHappySkull");
                    break;
                case "Angry_skull":
                    Flowchart.BroadcastFungusMessage("TalkToAngrySkull");
                    break;
                case "Narcissism_skull":
                    if (flowchart.GetBooleanVariable("givenHero3") == false)
                    {
                        Camera_lock = false;
                        Flowchart.BroadcastFungusMessage("TalkToNarcissismSkull");
                    }
                    break;
                case "Eater_skull":
                    Flowchart.BroadcastFungusMessage("TalkToEaterSkull");
                    break;
                case "HORNYSKULL":
                    Flowchart.BroadcastFungusMessage("TalkToHornySkull");
                    break;
                case "Props_Skeleton_Skull":
                    Flowchart.BroadcastFungusMessage("Check_Skeleton_Skull");
                    break;
                case "Props_Skeleton_Skull (1)":
                    Flowchart.BroadcastFungusMessage("Check_Skeleton_Skull");
                    break;
                case "Big_piece_web":
                    Flowchart.BroadcastFungusMessage("Check_web");
                    break;
                case "Chairs":
                    Flowchart.BroadcastFungusMessage("Check_chairs");
                    break;
                case "Potions":
                    Flowchart.BroadcastFungusMessage("Check_potions");
                    break;
                case "painting":
                    Flowchart.BroadcastFungusMessage("Check_paints");
                    break;
                case "GOLD":
                    Flowchart.BroadcastFungusMessage("Check_golds");
                    break;
                case "Chests":
                    Flowchart.BroadcastFungusMessage("Check_chests");
                    break;
                case "crown":
                    Flowchart.BroadcastFungusMessage("Check_crown");
                    break;
                case "Crystal":
                    Flowchart.BroadcastFungusMessage("Check_crystals");
                    break;
                case "wizardHat":
                    Flowchart.BroadcastFungusMessage("Check_wizardHat");
                    break;
                case "bed":
                    Flowchart.BroadcastFungusMessage("Check_bed");
                    break;
                case "suitCase":
                    Flowchart.BroadcastFungusMessage("Check_suitCase");
                    break;
                case "WATER":
                    Flowchart.BroadcastFungusMessage("Check_WATER");
                    break;
                case "UNDER_BED":
                    Flowchart.BroadcastFungusMessage("Check_UNDER_BED");
                    break;
                case "DIRTYFLOOR":
                    Flowchart.BroadcastFungusMessage("Check_DIRTYFLOOR");
                    break;
                case "sword":
                    Flowchart.BroadcastFungusMessage("Check_sword");
                    break;

                default:
                    break;
            }
            Camera_lock = true;

           
        }

    }

    public void Give_hero_3()
    {
        hero3.SetActive(true);
        flowchart.SetBooleanVariable("givenHero3", true);
    }

    public void unlockMouse()
    {
        Debug.LogWarning("lock");
        Camera_lock = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void lockMouse()
    {
        Camera_lock = true;
        Cursor.visible = false;//隱藏滑鼠
        Cursor.lockState = CursorLockMode.Locked;//把滑鼠鎖定到螢幕中間
    }
}

