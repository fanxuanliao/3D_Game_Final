using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closel_botton_click : MonoBehaviour
{
    public GameObject tutorial_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inactive_image()
    {
        tutorial_image.SetActive(false);
    }
}
