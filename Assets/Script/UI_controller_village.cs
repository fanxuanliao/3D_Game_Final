using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
//using System;

public class UI_controller_village : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject Backpack;
    public GameObject maincamera;
    private bool situation;
    public Button PROOF;
    public Button LIST;
    public Button PACKAGE;
    public Button BOOK;
    public Button CHARM;
    [SerializeField] RawImage[] backpackpic;
    internal bool[] backpackbool = new bool[5];
    internal bool[] backpackswitch = new bool[5];

    private Rect windowPosition;
    private Rect buttonPosition;
    private float windowwidth;
    private float buttonwidth;
    private float windowheight;
    private float buttonheight;

    // Start is called before the first frame update
    void Start()
    {
        situation = false;
        windowwidth = (float)(Screen.width * 0.8f);
        windowheight = (float)(Screen.height * 0.8f);
        buttonwidth = windowwidth * 0.3f;
        buttonheight = windowheight * 0.1f;
        windowPosition = new Rect((float)((Screen.width - windowwidth) * 0.5), (float)((Screen.height - windowheight) * 0.5), windowwidth, windowheight);
        buttonPosition = new Rect((windowwidth - buttonwidth) * 0.5f, (windowheight - buttonheight * 2f), buttonwidth, buttonheight);
        backpackbool[0] = false;
        backpackbool[1] = false;
        backpackbool[2] = false;
        backpackbool[3] = false;
        backpackbool[4] = false;
        backpackswitch[0] = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            situation = !situation;
            Backpack.SetActive(situation);
            //開關背包
            if (situation)
            {
                flowchart.SetBooleanVariable("talking", true);
                maincamera.GetComponent<Camera_controller>().unlockMouse();
            }
            else
            {
                flowchart.SetBooleanVariable("talking", false);
                maincamera.GetComponent<Camera_controller>().lockMouse();
            }

        }
        backpackswitch[1] = flowchart.GetBooleanVariable("OrderTaskRecieved");
        backpackswitch[2] = flowchart.GetBooleanVariable("DoneBoxTask");
        //backpackswitch[3] = flowchart.GetBooleanVariable(""); //推完箱子之後

    }
    public void getCharm()
    {
        backpackswitch[4] = true;
    }

    void OnGUI()
    {

        if (backpackswitch[0])
        {
            PROOF.gameObject.SetActive(true);
        }
        if (backpackswitch[1])
        {
            LIST.gameObject.SetActive(true);
        }
        if (backpackswitch[2])
        {
            PACKAGE.gameObject.SetActive(true);
        }
        if (backpackswitch[3])
        {
            BOOK.gameObject.SetActive(true);
        }
        if (backpackswitch[4])
        {
            CHARM.gameObject.SetActive(true);
        }



        PROOF.onClick.AddListener(() => { backpackbool[0] = true; });
        LIST.onClick.AddListener(() => { backpackbool[2] = true; });
        PACKAGE.onClick.AddListener(() => { backpackbool[1] = true; });
        BOOK.onClick.AddListener(() => { backpackbool[3] = true; });
        CHARM.onClick.AddListener(() => { backpackbool[4] = true; });
        
        if (backpackbool[0])
        {
            backpackpic[0].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                backpackpic[0].gameObject.SetActive(false);
                backpackbool[0] = false;
            }
        }     
        if (backpackbool[1])
        {
            backpackpic[1].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                backpackpic[1].gameObject.SetActive(false);
                backpackbool[1] = false;
            }
        }
        if (backpackbool[2])
        {
            backpackpic[2].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                backpackpic[2].gameObject.SetActive(false);
                backpackbool[2] = false;
            }
        }
        if (backpackbool[3])
        {
            backpackpic[3].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                backpackpic[3].gameObject.SetActive(false);
                backpackbool[3] = false;
            }
        }


    }
    /*
    private void backpackWindow(int id)
    {
        Rect textPosition = new Rect(100, 300, 0, 0);
        if (GUI.Button(buttonPosition, "CLOSE"))
        {
            backpackbool[id] = false;
        }
        switch (id)
        {
            case 0:
                GUI.TextField(textPosition, "似乎是勇者的證明，用不知名金屬打造的徽章，看上去很有質感。");
                break;
            case 1:
                GUI.TextField(textPosition, "武器店老闆交付的雜貨清單。");
                break;
            case 2:
                GUI.TextField(textPosition, "沉甸甸的箱子，裝滿了蔬菜水果。");
                break;
            case 3:
                GUI.TextField(textPosition, "看上去有一定年代的一本經典，上面寫著：");
                break;
            case 4:
                GUI.TextField(textPosition, "奇怪的紅衣人給的項鍊，上面的印記看起來有點熟悉。");
                break;

        }
    }
    */
}
