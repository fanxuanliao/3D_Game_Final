using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_controller : MonoBehaviour
{
    internal bool pass = false;
    internal bool QTEing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*debug
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<QTEsystem>().enabled = true;
    }
    */
    internal void start_QTE()
    {
        this.GetComponent<QTEsystem>().enabled = true;
    }

    internal void stop_QTE()
    {
        this.GetComponent<QTEsystem>().enabled = false;
    }
}

