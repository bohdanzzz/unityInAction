using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    
    void Update(){
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings(){
        Debug.Log("open setttings");
    }

    public void OnPointerDown(){
        Debug.Log("pointer down");
    }
}
