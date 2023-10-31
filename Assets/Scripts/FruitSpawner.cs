using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    static FruitSpawner instance;
    public static FruitSpawner Instance => instance;

    [SerializeField] List<Sprite> fruitSprites = new List<Sprite>();
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] Transform spawnPos;


    [SerializeField] GameObject nextFruitImg;
    int randomFruit;

    bool canSpawnFruit = true;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Only 1 instance of this");
            return;
        }
        instance = this;
    }


    private void Start()
    {
        RandomFruit();

    }



    private void Update()
    {
        CheckInput();
   
    }

    private void CheckInput()
    {
        if (canSpawnFruit && Input.GetMouseButtonDown(0))
        {
            canSpawnFruit = false;
            float xSpawnPosition = GetInputPosX();
            GenerateFruit(randomFruit, new Vector3(xSpawnPosition, spawnPos.position.y));
            nextFruitImg.GetComponent<SpriteRenderer>().sprite = null;

        }
    }

    public GameObject GenerateFruit(int randomFruit, Vector2 pos)
    {

        if (randomFruit > fruitSprites.Count) {
            GameManager.Instance.UpdateWaterMelonScore();
            return null;
        }
        GameObject newFruit = Instantiate(fruitPrefab, pos, Quaternion.identity, transform);
        newFruit.GetComponent<FruitScript>().fruitId = (FruitID)randomFruit;
        newFruit.GetComponent<SpriteRenderer>().sprite = fruitSprites[randomFruit];
        newFruit.AddComponent<CircleCollider2D>();

        return newFruit;

    }

    public void SetCanSpawnFruit(){
        if (!canSpawnFruit)
        {
            RandomFruit();
        }
    
        canSpawnFruit = true;

    }

    private void RandomFruit()
    {
        randomFruit = Random.Range(0, 4);
        nextFruitImg.GetComponent<SpriteRenderer>().sprite = fruitSprites[randomFruit];
    }

    float GetInputPosX()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldMousePosition.x;
    }

}
