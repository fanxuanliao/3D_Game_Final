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
        if (!pass)
        {
            if (QTEing)
            {
                QTEing = false;
            }
            else
                gameObject.GetComponent<QTEsystem>().enabled = false;
            gameObject.GetComponent<QTEsystem>().time = 0;
        }
        else
            print("PASSSSSS");
    }

    private void OnTriggerStay(Collider other)
    {
        QTEing = true;
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponent<QTEsystem>().enabled = true;
        }
    }
}
