using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class QTEsystem : MonoBehaviour
{
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    internal int time;
    internal int count_success;
    internal bool pass_well;
    private GameObject player;
    public GameObject diary;
    public RawImage F;
    public RawImage G;
    public RawImage SPACE;
    public RawImage PASS;
    public RawImage FAIL;
    public RawImage SUCCESS;
    public Flowchart flowchart;
    private bool showpic;
    // Update is called once per frame
    void Update()
    {
        if (count_success < 4)
        {
            if (WaitingForKey == 0)
            {
                PASS.gameObject.SetActive(false);
                FAIL.gameObject.SetActive(false);
                QTEGen = Random.Range(0, 3);
                

                CountingDown = 1;
                StartCoroutine(Count());
                if (QTEGen == 0)
                {
                    WaitingForKey = 1;
                    SPACE.gameObject.SetActive(true);
                    print("space"); //UI
                }
                if (QTEGen == 1)
                {
                    WaitingForKey = 1;
                    F.gameObject.SetActive(true);
                    print("F"); //UI
                }
                if (QTEGen == 2)
                {
                    WaitingForKey = 1;
                    G.gameObject.SetActive(true);
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
                        count_success++;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        count_success = 0;
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
                        count_success++;
                        CorrectKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        count_success = 0;
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
                        count_success++;
                        CorrectKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else
                    {
                        count_success = 0;
                        CorrectKey = 0;
                        StartCoroutine(KeyPressing());
                    }
                }
            }
        }
        else
        {
            F.gameObject.SetActive(false);
            G.gameObject.SetActive(false);
            SPACE.gameObject.SetActive(false);
            PASS.gameObject.SetActive(false);
            FAIL.gameObject.SetActive(false);
            SUCCESS.gameObject.SetActive(true);
            //Waitmessage();
            diary.gameObject.SetActive(true);
            flowchart.BroadcastMessage("OS_WellSuccess");
        }
        if (SUCCESS.gameObject.activeSelf)
        {
            
            if (Input.anyKey && showpic)
            {
                showpic = false;
                SUCCESS.gameObject.SetActive(false);
            }
        }
    }


    IEnumerator Waitmessage()
    {
        yield return new WaitForSeconds(10.0f);
    }
    IEnumerator KeyPressing()
    {
        QTEGen = -1;
        if (CorrectKey == 1)
        {
            F.gameObject.SetActive(false);
            G.gameObject.SetActive(false);
            SPACE.gameObject.SetActive(false);
            CountingDown = 0;
            print("PASS"); //UI
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            //PASS.gameObject.SetActive(true);
        }
        if (CorrectKey == 0)
        {
            F.gameObject.SetActive(false);
            G.gameObject.SetActive(false);
            SPACE.gameObject.SetActive(false);
            CountingDown = 0;
            print("FAILKEY"); //UI
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            FAIL.gameObject.SetActive(true);

        }
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(1.0f);
        if (CountingDown == 1)
        {
            QTEGen = -1;
            CountingDown = 0;
            print("FAIL");
            FAIL.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            count_success = 0;
        }
    }

}