using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string objectTag = "arma";
    public float health = 50f;
    public bool attack;
    public bool die;
    public float damage;
    public float damagePlayer = 1.5f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        damage = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que atraviesa el collider tiene la etiqueta especificada, se destruye
        if (other.CompareTag(objectTag))
        {
            health = health - damage;
            
            Debug.Log(health);
            
            if (health <= 0.001f){
                anim.SetBool("die", true);
                
                Invoke("DestroyObject", 3f);
            }
        }
    }
    void DestroyObject(){
        Destroy(gameObject);
        EnemyCounterScript enemyCounterScript = GameObject.Find("EnemyCounter").GetComponent<EnemyCounterScript>();
        enemyCounterScript.UpdateEnemyCounter();
    }
}
