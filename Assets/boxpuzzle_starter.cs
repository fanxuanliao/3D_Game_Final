using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class boxpuzzle_starter : MonoBehaviour
{
    internal bool reset = false;
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
            flowchart.BroadcastMessage("box_explain");
            //解釋箱子運作的方式
        }
        else
        {
            reset = true;
        }
    }
}
