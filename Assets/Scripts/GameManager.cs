// using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject enemyPrefab;
   public float minInstantiateValue;
     public float maxInstantiateValue;
    public float enemyDestroyTime = 10f;
   void Start()
    {
        InvokeRepeating("InstantiateEnemy",1f,1f);
    }

    void InstantiateEnemy()
    {
        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateValue,maxInstantiateValue),4f);
        GameObject enemy =  Instantiate(enemyPrefab, enemyPos,Quaternion.Euler(0f,0f,180f));
        Destroy(enemy,enemyDestroyTime);
    }
}
