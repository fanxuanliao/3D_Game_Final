using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password_controller : MonoBehaviour
{
    [SerializeField] Material[] password;
    //material賦值(六個圖)
    int index;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {

        index = Random.Range(0, 6);
        rend = gameObject.GetComponent<Renderer>();
        rend.material = password[index];
        //開場隨機一個圖

    }

    // Update is called once per frame
    void Update()
    { 
    }
}
