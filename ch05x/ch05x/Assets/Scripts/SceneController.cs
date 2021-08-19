using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMesh scoreLabel;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;    

    private int _score;

    private int _state;//todo to enum
    private int _lastID;
    private GameObject _lastCardBack;

    public void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
        numbers = ShuffleArray(numbers);

        for(int i = 0; i < gridCols; i++){
            for(int j = 0; j < gridRows; j++){
                MemoryCard card;
                if(i == 0 && j == 0){
                    card = originalCard;
                }else{
                    card = Instantiate(originalCard) as MemoryCard;
                }                

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetX * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }            

        }
    }

    private int[] ShuffleArray(int[] numbers){
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++){
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }

        return newArray;
    }

    public void CheckLast(int id, GameObject lastCardBack){
        if(_state == 0){
            _lastID = id;
            _lastCardBack = lastCardBack;
            _state = 1;
        }else if(_state == 1){
            if(_lastID != id){
                StartCoroutine(HideCard(_lastCardBack));
                StartCoroutine(HideCard(lastCardBack));
            }else{
                _score++;
                scoreLabel.text = "Score: " + _score;
            }

            _state = 0;
        }
    }

    private IEnumerator HideCard(GameObject card)
    {
        yield return new WaitForSeconds(1.0f);

        card.SetActive(true);//todo to card method
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene");
    }
}
