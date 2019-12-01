using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //基本角色移動
        float mov_x = Input.GetAxisRaw("Horizontal");
        float mov_z = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * mov_x * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * mov_z * speed * Time.deltaTime);
        float view_x = 0.8f * Input.GetAxis("Mouse X");
        
        transform.Rotate(0, view_x, 0);
        //

    }


}
