using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public GameObject[] enemy;
    public int countenemy,contador=0;
    public Transform[] spawnPoints;

    // Lista para almacenar los spawnPoints utilizados
    private List<int> usedSpawnPointIndexes = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        countenemy = Random.Range(5, 10);
        // Asegurarse de que la cantidad de enemigos no exceda la cantidad de puntos de spawn
        if (countenemy > spawnPoints.Length) {
            countenemy = spawnPoints.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contador!=countenemy)
        {
            SpawnEnemys();
            contador++;
        }
    }

    void SpawnEnemys()
    {
        int enemyIndex = Random.Range(0, enemy.Length);

        // Busca un spawnPointIndex que no se haya utilizado previamente
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        while (usedSpawnPointIndexes.Contains(spawnPointIndex)) {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
        }

        usedSpawnPointIndexes.Add(spawnPointIndex);

        Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
