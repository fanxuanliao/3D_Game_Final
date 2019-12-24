using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class player_fungus_village : MonoBehaviour
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
        switch (other.gameObject.name)
        {
            /*
            case "Scene_Boundary":
                Flowchart.BroadcastFungusMessage("Bumped_Boundary");
                break;
                */
            default:
                break;
        }
    }

}

