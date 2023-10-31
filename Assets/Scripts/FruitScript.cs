using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FruitID
{
    _0 = 0,
    _1 = 1,
    _2 = 2,
    _3 = 3,
    _4 = 4,
    _5 = 5,
    _6 = 6,
    _7 = 7,
    _8 = 8,
}
public class FruitScript : MonoBehaviour
{
    public bool hasCollided = false;
    private bool hasCollidedWithSameFruit = false;

    public FruitID fruitId;

    private void Update()
    {
        if (hasCollidedWithSameFruit) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Line"))
        {
            GameManager.Instance.GameOver();
            return;
        }
        if (!hasCollided)
        {
            FruitSpawner.Instance.SetCanSpawnFruit();
            hasCollided = true;

        }

        if ( !hasCollidedWithSameFruit && collision.gameObject.CompareTag("Fruits"))
        {
            FruitScript collidedFruit = collision.gameObject.GetComponent<FruitScript>();
            if(fruitId == collidedFruit.fruitId)
            {
                collidedFruit.hasCollidedWithSameFruit = true;
                int newIndex = (int)fruitId;
                GameObject newFruit = FruitSpawner.Instance.GenerateFruit(newIndex +1, transform.position);
                newFruit.GetComponent<FruitScript>().hasCollided = true;
                GameManager.Instance.UpdateScore(newIndex+1);
         
                hasCollidedWithSameFruit = true;
            }
        }
    
    }
}
