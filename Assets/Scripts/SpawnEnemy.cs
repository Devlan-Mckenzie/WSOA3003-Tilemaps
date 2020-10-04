using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;
    public int xPos, yPos, zPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if (enemyCount == 0)
        {
            enemyCount += 1;
            StartCoroutine(EnemySpawn());
        }
    }
    IEnumerator EnemySpawn()
    {
        while (enemyCount < 10)
        {
            Instantiate(enemy,new Vector3(xPos,yPos,zPos),Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount += 1;
        }
    }

    public void EnemyDied()
    {
        enemyCount -= 1;
    }
}
