using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class saveVariables : MonoBehaviour
{
    public static bool haveSword = true;
    public GameObject saveVariable;
    public Flowchart roadfun;
    
    private GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(saveVariable);
        roadfun.SetBooleanVariable("Ending", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
