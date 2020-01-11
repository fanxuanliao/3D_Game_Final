using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus_road : MonoBehaviour
{
    public Flowchart flowchart;
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
        switch (other.gameObject.name)
        {
            case "Obstacle_jail":
                Flowchart.BroadcastFungusMessage("GO_jail");
                break;
            case "Obstacle_ending":
                Flowchart.BroadcastFungusMessage("GO_ending");
                break;
            case "Obstacle_villa":
                Flowchart.BroadcastFungusMessage("GO_villa");
                break;
            case "Ending":
                Flowchart.BroadcastFungusMessage("Ending");
                break;
            default:
                break;
        }
    }

}

