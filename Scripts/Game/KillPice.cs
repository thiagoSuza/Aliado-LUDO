using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillPice : MonoBehaviour
{
    public int ignoreLayerIndex;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != ignoreLayerIndex && other.gameObject.CompareTag("Piece"))
        {
            other.gameObject.GetComponent<PlayerMovement>().KillPos();
        }
        else
        {
            if(other.gameObject.GetComponent<PlayerMovement>().id < GetComponentInParent<PlayerMovement>().id)
            {
                GetComponentInParent<PlayerMovement>().UpPiece(other.gameObject.GetComponent<PlayerMovement>().value);
                other.gameObject.GetComponent<PlayerMovement>().DesactivePiece();
            }
           
            
        }
        
    }
}
