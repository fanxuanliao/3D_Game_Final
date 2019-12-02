using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Manager : MonoBehaviour
{
    [SerializeField]private Material interactive_hl;
    [SerializeField]private Material checking_hl;
    [SerializeField] private Material default_material;
    private Color default_color;
    private Transform _selection;
    float raylength = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //raylength = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
        Debug.DrawRay(transform.position, forward, Color.yellow);
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            //selectionRenderer.material = default_material;
            selectionRenderer.material.color = default_color;
            _selection = null;
        }
        //儲存原先的material
        var mouse = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        //射線
        if(Physics.Raycast(mouse, out hit, raylength))
        {
            var selection = hit.transform;
            if(selection.CompareTag("interactive"))
            {
            //    print("interactive");
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    //selectionRenderer.material = checking_hl;
                    selectionRenderer.material.color = Color.cyan;

                }
                _selection = selection;
            }
            else if (selection.CompareTag("checking"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    //selectionRenderer.material = checking_hl;
                    selectionRenderer.material.color = Color.yellow;
                }
                _selection = selection;
            }
        }
        //射線互動
    }
}
