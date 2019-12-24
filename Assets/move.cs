using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mov_x = Input.GetAxisRaw("Horizontal");
        float mov_z = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * mov_x * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * mov_z * speed * Time.deltaTime);
    }
}
