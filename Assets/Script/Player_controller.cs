using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Player_controller : MonoBehaviour
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
    //基本角色移動
    if (Input.GetKey("left shift")) speed = 10;
    else speed = 6;
        if (flowchart.GetBooleanVariable("talking") == false)
        {
            float mov_x = Input.GetAxisRaw("Horizontal");
            float mov_z = Input.GetAxisRaw("Vertical");
            transform.Translate(Vector3.right * mov_x * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * mov_z * speed * Time.deltaTime);
            float view_x = 0.8f * Input.GetAxis("Mouse X");

            transform.Rotate(0, view_x, 0);


        }

}
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.name == "Obstacle")
        {          
            Flowchart.BroadcastFungusMessage("Collision_Obstacle");
            //GameObject.Find("magic_lock").SetActive(true);
        }
        else if (other.gameObject.name == "Check_magic_lcok")
        {
            Flowchart.BroadcastFungusMessage("Check_magic_lcok");
            Destroy(other.gameObject);
        }
    }




}