using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class Village_controller : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
            SceneManager.LoadScene(5);   
    }
    public void OpenPortal() {
        if (flowchart.GetBooleanVariable("hasSword") == true)
        {
            portal.SetActive(true);
        }
    }
}
