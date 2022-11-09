using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oh no you CRASHED!!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You have picked up the pie.");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deliver the pie now");
    }


}
