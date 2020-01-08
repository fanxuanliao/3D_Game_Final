using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public bool End = false;
    public GameObject ob;
    public GameObject portal;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void splitWood()
    {
        Destroy(ob);
    }
    public void Restart() {
        SceneManager.LoadScene(1);
    }
    public void End()
    {
        Application.Quit();
    }
}
 
