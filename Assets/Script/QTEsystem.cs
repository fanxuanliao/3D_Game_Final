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
    internal int count_success;
    internal bool pass_well;
    private GameObject player;

    void start()
    {
        WaitingForKey = 0;
        count_success = 0;
        player = GameObject.Find("player");
    }
    // Update is called once per frame
    void Update()
    {
        if (count_success < 8)
        {
            if (WaitingForKey == 0)
            {
                QTEGen = Random.Range(0, 3);
                CountingDown = 1;
                StartCoroutine(Count());
                if (QTEGen == 0)
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
            print("成功desu");
            player.GetComponent<player_fungus_village>().send_messege("OS_WellSuccess");
        }
    }


    IEnumerator KeyPressing()
    {
        QTEGen = -1;
        if (CorrectKey == 1)
        {
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
            print("FAILKEY"); //UI
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
        if (CountingDown == 1)
        {
            QTEGen = -1;
            CountingDown = 0;
            print("FAIL");
            yield return new WaitForSeconds(0.5f);
            CorrectKey = -1;
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            count_success = 0;
        }
    }

}