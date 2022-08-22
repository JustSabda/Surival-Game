using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject Info_Object;
    Text interaction_text;


    private void Start()
    {
        interaction_text = Info_Object.GetComponent<Text>();
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>())
            {

                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                Info_Object.SetActive(true);

            }
            else
            {
                Info_Object.SetActive(false);
            }

        }


    }
}
