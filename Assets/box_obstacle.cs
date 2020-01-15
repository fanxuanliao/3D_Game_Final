using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class box_obstacle : MonoBehaviour
{
    public Flowchart flowchart; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("BoxTaskRecieved"))
        {
            Destroy(gameObject);
        }
    }
}
