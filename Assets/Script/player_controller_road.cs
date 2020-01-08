using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class player_controller_road : MonoBehaviour
{
    public float speed = 6.0f;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left shift")) speed = 12;
        else speed = 6;

            float mov_x = Input.GetAxisRaw("Horizontal");
            float mov_z = Input.GetAxisRaw("Vertical");
            transform.Translate(Vector3.right * mov_x * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * mov_z * speed * Time.deltaTime);
            float view_x = 0.8f * Input.GetAxis("Mouse X");

            transform.Rotate(0, view_x, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Portal")
        {
            SceneManager.LoadScene(3);  //傳送至村莊
        }
        if (other.gameObject.name == "obstacle_Ending")
        {
            Flowchart.BroadcastFungusMessage("Ending");
        }
    }

}
