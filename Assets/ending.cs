using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public GameObject ob;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void init()
    {
        Destroy(portal);
    }
    public void splitWood()
    {
        Destroy(ob);
    }
}
