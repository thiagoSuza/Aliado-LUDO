using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponentInParent<PlayerRow>().soma != 2 || GetComponentInParent<PlayerRow>().soma != 6)
        {
            GetComponentInParent<PlayerMovement>().Move(GetComponentInParent<PlayerRow>().soma);
            GetComponentInParent<PlayerRow>().DesactiveSelector();
        }
        else
        {
            GetComponentInParent<PlayerMovement>().Move2();
            GetComponentInParent<PlayerRow>().DesactiveSelector();
        }
        
    }


    public void Btn()
    {
        GetComponentInParent<PlayerMovement>().Move(GetComponentInParent<PlayerRow>().soma);
        GetComponentInParent<PlayerRow>().DesactiveSelector();

    }
    
}
