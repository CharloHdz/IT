using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public string objectTag = "arma";
    public float health = 100f;
    public bool attack;
    public bool die;
    public float damage = 1.5f;
    public float damagePlayer = 1.5f;
    public Animator anim;
    public GameObject canvasDie;
    public GameObject healthIndice;
    public GameObject playerGO;
    public GameObject arma;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (health >= 0.001f)
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
                canvasDie.SetActive(true);
                healthIndice.SetActive(false);
                Invoke("DestroyPlayer", 3f);
            }
        }
    }
    void DestroyPlayer(){
        playerGO.SetActive(false);
        arma.SetActive(false);
    }
}
