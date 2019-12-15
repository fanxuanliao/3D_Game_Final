using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject broom_UI;
    public GameObject bucket_UI;
    public GameObject water_UI;


    void Start()
    {
        
    }


    // Update is called once per frame
    void OnGUI()
    {
        var item = GameObject.Find("Player").GetComponent<Pickup_controller>();
        if(item.ability[0])
        {
            broom_UI.SetActive(true);
        }
        if (item.ability[1])
        {
            bucket_UI.SetActive(true);
        }
        if (item.ability[2])
        {
            water_UI.SetActive(true);
            bucket_UI.SetActive(false);
        }

    }
}
