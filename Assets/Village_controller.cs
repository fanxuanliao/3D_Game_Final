using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village_controller : MonoBehaviour
{
    internal bool leave = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leave)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }   
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Player").GetComponent<player_fungus_village>().send_messege("Scene_Boundary");
    }
}
