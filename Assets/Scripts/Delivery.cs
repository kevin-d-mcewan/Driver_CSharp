using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage = false;
    bool hasMail = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You have crashed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Other refers to the parameter that you are passing in for OnTriggerEnter2D() 'other' is just var name can be named anything
        // Debug.Log ("you have picked up 'anything');
        if (other.tag == "Package")
        {
            Debug.Log("You have picked up the package.");
            hasPackage = true;
        } 
        else if(other.tag == "Mail")
        {
            Debug.Log("You have picked up the mail");
            hasMail = true;

        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered the package");
            hasPackage = false;
        }
        else if (other.tag == "Customer" && hasMail)
        {
            Debug.Log("Mail delivered!");
            hasMail = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            Debug.Log("Deliver the package now");
        }
        else if (collision.tag == "Mail")
        {
            Debug.Log("Deliver the Mail fast!");
        }
    }


}
