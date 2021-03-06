using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const float baseSpeed = 3.0f;
    public float speed = 3.0f;

    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    void Update()
    {
        if(_enemy == null){
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);            
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

            
            WanderingAI wanderingAI = _enemy.GetComponent<WanderingAI>();
            wanderingAI.speed = baseSpeed * speed;
        }
    }

    void Awake(){
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Destroy(){
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value){
        speed = baseSpeed * value;
    }
}
