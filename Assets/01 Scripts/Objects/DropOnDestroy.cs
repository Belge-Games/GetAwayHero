using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject diamond;
    [SerializeField] private int heartAmount; 
    [SerializeField] private int coinAmount; 
    [SerializeField] private int diamondAmount; 
    [SerializeField] [Range(0f, 1f)] private float heartChance; 
    [SerializeField] [Range(0f, 1f)] private float coinChance; 
    [SerializeField] [Range(0f, 1f)] private float diamondChance; 
    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if(isQuitting) return;

        if(Random.value < heartChance)
        {
            SpawnHearts(heartAmount, Random.Range(20, 100) * 5);
        }
        if(Random.value < coinChance)
        {
            SpawnCoins(coinAmount, Random.Range(2, 8) * 5);
        }
        if(Random.value < diamondChance)
        {
            SpawnDiamonds(diamondAmount, Random.Range(20, 100) * 5);
        }
    }

    private void SpawnCoins(int quantity, int value)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject instantiatedCoin = Instantiate(coin);
            instantiatedCoin.transform.position = new Vector3(transform.position.x + quantity - i/2, transform.position.y - 1, 0f);
            instantiatedCoin.transform.parent = transform.parent;
            instantiatedCoin.GetComponent<ICollectableObject>().SetAmount(value);
        }
    }

    private void SpawnHearts(int quantity, int value)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject instantiatedHeart = Instantiate(heart);
            instantiatedHeart.transform.position = new Vector3(transform.position.x + quantity - i/2, transform.position.y - 1, 0f);
            instantiatedHeart.transform.parent = transform.parent;
            instantiatedHeart.GetComponent<ICollectableObject>().SetAmount(value);
        }
    }

    private void SpawnDiamonds(int quantity, int value)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject instantiatedDiamond = Instantiate(diamond);
            instantiatedDiamond.transform.position = new Vector3(transform.position.x + quantity - i/2, transform.position.y - 1, 0f);
            instantiatedDiamond.transform.parent = transform.parent;
            instantiatedDiamond.GetComponent<ICollectableObject>().SetAmount(value);
        }
    }
}
