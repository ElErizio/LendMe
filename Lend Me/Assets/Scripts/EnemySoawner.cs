using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoawner : MonoBehaviour
{
    public GameObject enemy;

    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy,transform.position,Quaternion.identity);
        newEnemy.SetActive(true);
    }
}
