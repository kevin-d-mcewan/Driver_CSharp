using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float steerSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var in here bc it needs to be updated every frame
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;

        // To turn the vehicle Left & Right
        transform.Rotate(0, 0, -steerAmount);
        // To make the vehicle move Up & Down
        transform.Translate(0, moveAmount, 0);
    }
}
