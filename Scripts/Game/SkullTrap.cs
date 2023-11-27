using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullTrap : MonoBehaviour
{
    private BoxCollider bx;

    private void Start()
    {
        bx = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Piece"))
        {
            other.gameObject.GetComponent<PlayerMovement>().ResetPos();
        }
    }


    public void SetActiveBox()
    {

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        bx.enabled = true;
        yield return new WaitForSeconds(2f);
        bx.enabled = false;
    }
}
