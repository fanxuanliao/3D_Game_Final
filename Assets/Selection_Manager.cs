using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Manager : MonoBehaviour
{
    [SerializeField]private Material interactive_hl;
    [SerializeField]private Material checking_hl;
    [SerializeField] private Material default_material;
    private Transform _selection;
    float raylength;

    // Start is called before the first frame update
    void Start()
    {
        raylength = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = default_material;
            _selection = null;
        }
        var mouse = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(mouse, out hit, raylength))
        {
            var selection = hit.transform;
            if(selection.CompareTag("interactive"))
            {
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
    }
}
