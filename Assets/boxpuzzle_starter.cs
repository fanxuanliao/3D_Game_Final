using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class boxpuzzle_starter : MonoBehaviour
{
    public bool reset = false;
    bool first = true;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            reset = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (first)
        {
            first = false;
            Flowchart.BroadcastFungusMessage("box_explain");
            //解釋箱子運作的方式
        }
        else
        {
            print("else");
            reset = true;
        }
    }
}
