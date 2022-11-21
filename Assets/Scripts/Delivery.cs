using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Color variable for car depending of having package or not
    //   *** Make sure that in Inspector the 'hasPackage' & 'noPackage' the alpha is not zero or it will appear as if vanished ***
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);

    // Reference to SpriteRender so we can GetComponent
    SpriteRenderer spriteRenderer;
    
    bool hasPackage = false;
    bool hasMail = false;
    
    [SerializeField] float destroyDelay = 0.5f;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You have crashed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Other refers to the parameter that you are passing in for OnTriggerEnter2D() 'other' is just var name can be named anything
        // Debug.Log ("you have picked up 'anything');
        if (other.tag == "Package" && !hasPackage && !hasMail)
        {
            Debug.Log("You have picked up the package.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            
        } 
        else if(other.tag == "Mail" && !hasMail & !hasPackage)
        {
            Debug.Log("You have picked up the mail");
            hasMail = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);

        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered the package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else if (other.tag == "Customer" && hasMail)
        {
            Debug.Log("Mail delivered!");
            hasMail = false;
            spriteRenderer.color = noPackageColor;
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
