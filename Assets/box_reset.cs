using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_reset : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 origin;
    void Start()
    {
        origin = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("box_starter").GetComponent<boxpuzzle_starter>().reset)
        {
            transform.position = origin;
        }
    }
}
