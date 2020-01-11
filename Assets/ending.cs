using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public GameObject ob;

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
}
