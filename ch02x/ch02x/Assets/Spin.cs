using System.Collections;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Rotate(0, speed, 0);        
    }
}
