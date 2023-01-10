using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<Enemy> enemyList;

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    private void Start()
    {
        for(int i = 0; i < size; i++)
            CreatePool();
    }

    private void SetActiveEnemy(GameObject _enemy)
    {
        _enemy.gameObject.SetActive(true);
    }

    private void CreatePool()
    {
        Enemy temp = Instantiate(enemy, transform);
        enemyList.Add(temp);
    }

    public Enemy PopUnit()
    {
        Enemy temp = null;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].gameObject.activeSelf == false)
            {
                temp = enemyList[i];
                break;
            }
        }
        if (temp == null)
        {
            CreatePool();
            temp = enemyList[enemyList.Count - 1];
        }
        return temp;
    }

}
