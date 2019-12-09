using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Manager : MonoBehaviour
{
    private Color default_color;
    private Transform _selection;
    float raylength;

    // Start is called before the first frame update
    void Start()
    {
        raylength = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
        //Debug.DrawRay(transform.position, forward, Color.yellow);
        //Debug顯示射線

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.color = default_color;
            _selection = null;
        }
        //還原原先的material

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        //射線
        if (Physics.Raycast(ray, out hit, raylength))
        {
            var selection = hit.transform;
            default_color = selection.GetComponent<Renderer>().material.color;
            //儲存原先的color
            if (selection.CompareTag("interactive"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material.color = Color.cyan;

                }
                _selection = selection;
            }
            //互動物件是藍ㄉ
            else if (selection.CompareTag("clues"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material.color = Color.green;
                }
                _selection = selection;
            }
            //線索物件是綠ㄉ
        }
        //射線互動
    }
}
