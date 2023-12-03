using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject[] objetos;
    public Transform[] puntos_O;
    public GameObject[] Enemy;
    public Transform[] puntos_E;
    public int C_Enemy=5;
    //public float xo, xf;
    //public float zo = 1, zf = 15;
    //public int room;
    private void Update()
    {
        
       
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < puntos_O.Length; i++) {
            int numeroAleatorio = Random.Range(0, objetos.Length);
            Instantiate(objetos[numeroAleatorio],puntos_O[i].position,Quaternion.identity);
                }
        for (int i = 0; i < (puntos_E.Length) - C_Enemy; i++)
        {
            int numeroAleatorio = Random.Range(0, Enemy.Length);
            int RPosition = Random.Range(0, puntos_E.Length);
            Instantiate(Enemy[numeroAleatorio], puntos_E[RPosition].position, Quaternion.identity);
        }
        }

   
}
