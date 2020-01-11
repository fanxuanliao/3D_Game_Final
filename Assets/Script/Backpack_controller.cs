using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class Backpack_controller : MonoBehaviour
{
    public GameObject Backpack;
    private bool situation;
    public Button ARMOR;
    public Button SKULL;
    public Button BED;
    public Button DIARY;
    public Button PROOF;
    [SerializeField] GUISkin backpackSkin;
    [SerializeField] RawImage[] backpackpic;

    public Flowchart flowchart;
    public GameObject maincamera;

    internal bool[] backpackbool = new bool[5];

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
        
    }

    void OnGUI()
    {
        GUI.skin = backpackSkin;
        var item = GameObject.Find("Player").GetComponent<Pickup_controller>();

        if (item.backpack[0])
        {
            ARMOR.gameObject.SetActive(true);
        }
        if (item.backpack[1])
        {
            BED.gameObject.SetActive(true);
        }
        if (item.backpack[2])
        {
            SKULL.gameObject.SetActive(true);
        }
        if (item.backpack[3])
        {
            DIARY.gameObject.SetActive(true);
        }
        if (item.backpack[4])
        {
            PROOF.gameObject.SetActive(true);
            ARMOR.gameObject.SetActive(false);
            SKULL.gameObject.SetActive(false);
            BED.gameObject.SetActive(false);
            DIARY.gameObject.SetActive(false);
        }


        ARMOR.onClick.AddListener(() => { backpackbool[0] = true; });
        SKULL.onClick.AddListener(() => { backpackbool[2] = true; });
        BED.onClick.AddListener(() => { backpackbool[1] = true; });
        DIARY.onClick.AddListener(() => { backpackbool[3] = true; });
        PROOF.onClick.AddListener(() => { backpackbool[4] = true; });
        
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
                GUI.TextField(textPosition, "一件破舊的盔甲，上面有奇怪的碎片。");
                break;
            case 1:
                GUI.TextField(textPosition, "在床底下發現的碎片，似乎能和其他碎片組合。");
                break;
            case 2:
                GUI.TextField(textPosition, "從骷髏手中拿到的碎片，似乎能和其他碎片組合。");
                break;
            case 3:
                GUI.TextField(textPosition, "在神秘日記本上的碎片，似乎是勇者之證的一部分？");
                break;

        }
    }
    */
}
