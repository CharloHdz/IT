using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo : MonoBehaviour
{

    public Animator anim;
    public Enemy enemigo;

    void OnTriggerEnter(Collider coll){
        if (coll.CompareTag("Player")){
            if (!enemigo.stuneado){
                anim.SetBool("walk", false);
                anim.SetBool("run", false);
                anim.SetBool("attack", true);
                enemigo.atacar = true;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
