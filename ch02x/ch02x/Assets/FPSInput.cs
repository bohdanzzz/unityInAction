using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 0.01f;

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime); 
        Debug.Log(Time.deltaTime);
    }
}
