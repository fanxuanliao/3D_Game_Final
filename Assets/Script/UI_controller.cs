using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Button broom_UI;
    public Button bucket_UI;
    public Button water_UI;
    [SerializeField] RawImage[] itempic = new RawImage[3];

    private Rect windowPosition;
    private Rect buttonPosition;

    private float windowwidth;
    private float buttonwidth;
    private float windowheight;
    private float buttonheight;

    internal bool[] itembool = new bool[3];

    enum itemIndex
    {
        BROOM,
        BUCKET,
        WATER
    }

    void Start()
    {
        windowwidth = (float)(Screen.width * 0.8f);
        windowheight = (float)(Screen.height * 0.8f);
        buttonwidth = windowwidth * 0.3f;
        buttonheight = windowheight * 0.1f;
        windowPosition = new Rect((float)((Screen.width - windowwidth) * 0.5), (float)((Screen.height - windowheight) * 0.5), windowwidth, windowheight);
        buttonPosition = new Rect((windowwidth - buttonwidth) * 0.5f, (windowheight - buttonheight * 2f), buttonwidth, buttonheight);
        itembool[0] = false;
        itembool[1] = false;
        itembool[2] = false;

    }


    // Update is called once per frame
    void OnGUI()
    {

        var item = GameObject.Find("Player").GetComponent<Pickup_controller>();
        if (item.ability[0])
        {
            broom_UI.gameObject.SetActive(true);
        }
        if (item.ability[1])
        {
            bucket_UI.gameObject.SetActive(true);
        }
        if (item.ability[2])
        {
            water_UI.gameObject.SetActive(true);
            bucket_UI.gameObject.SetActive(false);
        }

        broom_UI.onClick.AddListener(() => { itembool[0] = true; });
        bucket_UI.onClick.AddListener(() => { itembool[1] = true; });
        water_UI.onClick.AddListener(() => { itembool[2] = true; });


        if (itembool[0])
        {
            itempic[0].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                itempic[0].gameObject.SetActive(false);
                itembool[0] = false;
            }
        }
        if (itembool[1])
        {
            itempic[1].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                itempic[1].gameObject.SetActive(false);
                itembool[1] = false;
            }
        }
        if (itembool[2])
        {
            itempic[2].gameObject.SetActive(true);
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                itempic[2].gameObject.SetActive(false);
                itembool[2] = false;
            }
        }
    }
    /*
    private void ItemWindow(int id)
    {
        Rect textPosition = new Rect(100, 300, 0, 0);
        if (GUI.Button(buttonPosition, "CLOSE"))
        {
            itembool[id] = false;
        }
        switch (id)
        {
            case 0:
                GUI.TextField(textPosition, "看起來不怎麼好用的掃把，上面的稻草都岔得亂七八糟了。");
                break;
            case 1:
                GUI.TextField(textPosition, "空的水桶，看起來可以裝不少水。");
                break;
            case 2:
                GUI.TextField(textPosition, "裝滿水的水桶，掃除時能夠派上用場。");
                break;
        }
        //GUI.DrawTexture(new Rect(0,0,400,400), itempic[id]);

    }
    */
}
