using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;   // Make sure to change these in the Inspector or else car wont move.
    [SerializeField] float steerSpeed = 1.0f;   // These speeds are without Time.dT those nums are more like 15 m.s. & 225 s.s.
    [SerializeField] float slowSpeed = 15.0f;   // Is the 'moveSpeed' adjustment if going over a bump
    [SerializeField] float boostSpeed = 35.0f;  // Is a speed boost that increase 'moveSpeed like arrows in MarioKart
    [SerializeField] float normalSpeed = 20.0f; // Speed Car can go after boost or bump or crash
    [SerializeField] float timeToNormal = 3.0f; // This is how long they have the speedBoost or speedBump for. Time amount can be changed in Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var in here bc it needs to be updated every frame
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Both framerate indep bc of dT

        // To turn the vehicle Left & Right
        transform.Rotate(0, 0, -steerAmount);
        // To make the vehicle move Up & Down
        transform.Translate(0, moveAmount, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Logic for speeding up or slowing down
        if (collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            StartCoroutine(Back_To_Normal(timeToNormal));
        }

        if (collision.tag == "Bump")
        {
            moveSpeed = slowSpeed;
            StartCoroutine(Back_To_Normal(timeToNormal));
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Building" || other.gameObject.tag == "TreeAndPlant")
        {
            moveSpeed = slowSpeed;
            StartCoroutine(Back_To_Normal(timeToNormal));
        }
    }


    // This CoRoutine is used to change the speed back to the normal speed after a certain amount of time instead
    // of just hitting another speedBoost or speedBump
    IEnumerator Back_To_Normal(float time) 
    {
        yield return new WaitForSeconds(time);
        moveSpeed = normalSpeed;
    }
}
