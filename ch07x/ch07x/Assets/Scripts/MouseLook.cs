using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAces
    {
        MouseXAndY = 0,
        MouseX,
        MouseY        
    }

    public RotationAces axes = RotationAces.MouseXAndY;

    public float sensitivityHor = 5f;
    public float sensitivityVert = 5f;

    public float minimumVert = -45.0f;
    public float maximunVert = 45.0f;
    
    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null){
            body.freezeRotation = true;
        }    
    }

    void Update()
    {
        if (axes == RotationAces.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);    
        }
        else if(axes == RotationAces.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximunVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximunVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        
    }
}
