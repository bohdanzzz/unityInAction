using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{    
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    void Awake() {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    
    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void Start(){
        _score = 0;
        scoreLabel.text = _score.ToString();
        
        settingsPopup.Close();
    }

    public void OnOpenSettings(){
        settingsPopup.Open();
    }

    private void OnEnemyHit(){
        _score += 1;
        scoreLabel.text = _score.ToString();
    }

    public void OnPointerDown(){
        Debug.Log("pointer down");
    }
}
