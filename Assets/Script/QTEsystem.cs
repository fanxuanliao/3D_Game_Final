using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystem : MonoBehaviour
{
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    internal int time;

    void start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(WaitingForKey == 0)
        {
            if (time <= 7)
            {
                QTEGen = Random.Range(0, 3);
                time++;
            }
            else
            {
                gameObject.GetComponent<QTE_controller>().pass = true;
                this.enabled = false;
            }
            CountingDown = 0;
            StartCoroutine(Count());
            if(QTEGen == 0)
            {
                WaitingForKey = 1;
                print("space"); //UI
            }
            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                print("F"); //UI
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                print("G"); //UI
            }
        }
        if (QTEGen == 0)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }   

    IEnumerator KeyPressing()
    {
        QTEGen = -1;
        if(CorrectKey == 1) {
            CountingDown = 0;
            print("PASS"); //UI
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 0)
        {
            CountingDown = 0;
            print("FAIL"); //UI
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(1.5f);
        if(CountingDown == 1)
        {
            QTEGen = -1;
            CountingDown = 0;
            print("FAIL");
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
    
}
