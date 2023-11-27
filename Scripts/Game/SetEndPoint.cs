using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piece"))
        {
            other.gameObject.GetComponent<PlayerMovement>().SetFinal();
        }
    }
}
