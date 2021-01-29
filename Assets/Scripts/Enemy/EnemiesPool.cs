using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    private Queue<GameObject> enemiesPool;
    private Object enemyRef;

    private void Awake()
    {
        enemiesPool = new Queue<GameObject>();
        enemyRef = Resources.Load("Enemy");
        Debug.Log(enemyRef);

        Debug.Log(enemiesPool.Count);

        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = (GameObject)Instantiate(enemyRef);
            enemy.SetActive(false);
            enemiesPool.Enqueue(enemy);
        }
        Debug.Log(enemiesPool.Count);
    }

    // As a parameter we can set type of enemy
    public GameObject getEnemyFromPool()
    {
        if (enemiesPool.Count > 0)
        {
            GameObject enemy = enemiesPool.Dequeue();
            enemy.SetActive(true);

            Debug.Log(enemiesPool.Count);

            return enemy;
        }

        return null;
    }

    public void returnEnemyToPool(GameObject enemy)
    {
        enemiesPool.Enqueue(enemy);
    }
}
