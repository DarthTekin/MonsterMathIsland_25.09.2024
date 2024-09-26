using System.Collections;
using System.Collections.Generic;
using TutorialAssets.Scripts;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private int amountOfMonsters = 10;
    [SerializeField] private Transform monsterSpawnPoint;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform queuePoint;
    [SerializeField] GameObject[] monsterPrefabs;
    [SerializeField] private float waveDifficulty;

    public List<GameObject> monsters;

    void Start()
    {
        for (int i = 0; i < amountOfMonsters; i++)
        {
            InstantiateMonster();
        }

        MonsterAttacks(0);
        MoveNextMonsterToQueue();

        waveDifficulty = CalculateWaveDifficulty();
    }

    public void MonsterAttacks(int monsterIndex)
    {
        if (monsters.Count <= monsterIndex)
        {
            return;
        }

        Transform monster = monsters[monsterIndex].transform;
        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Attack);
        monster.position = attackPoint.position;
        monster.rotation = attackPoint.rotation;
    }  
    
    public void MoveMonsterToQueue(int monsterIndex)
    {
        if (monsters.Count <= monsterIndex)
        {
            return;
        }

        Transform monster = monsters[monsterIndex].transform;
        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Queue);
        monster.position = queuePoint.position;
        monster.rotation = queuePoint.rotation;
    }

    public void MoveNextMonsterToQueue()
    {
        MoveMonsterToQueue(1);
    }

    public void KillMonster(int monsterIndex)
    {
        Destroy(monsters[monsterIndex]);
        monsters.RemoveAt(monsterIndex);
    }

    private void InstantiateMonster()
    {
        int monsterIndex = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[monsterIndex], monsterSpawnPoint.position, Quaternion.identity);
        monsters.Add(monster);
    }

    void Update()
    {
        
    }

    float CalculateWaveDifficulty()
    {
        float difficulty = 0;

        foreach (GameObject monster in monsters)
        {
            difficulty += monster.GetComponent<Points>().points;
        }

        difficulty /= amountOfMonsters * 3; 
        return difficulty;
    }
}
