using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacar;

    public GameObject arma;
    public bool stuneado;
    public RangoEnemigo rango;
    
    public float speed;

    public NavMeshAgent agente;
    public float distanciaAtaque;
    public float radioVision;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    public void Comportamiento(){

        if (Vector3.Distance(transform.position, target.transform.position) > radioVision) {

            agente.enabled = false;
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4){
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina){
                case 0:
                    anim.SetBool("walk", false);
                break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                break;

            }
        }else{

            var lookPos = target.transform.position - transform.position;
                //lookPos = Vector3.zero;
            var rotation = Quaternion.LookRotation(lookPos);

            agente.enabled = true;
            agente.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > distanciaAtaque && !atacar){
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
            }else{
                if (!atacar){
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);
                }
            }

        if (atacar){
            agente.enabled = false;
        }

            /*if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacar) {
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);

                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                anim.SetBool("attack", false);
            }else{

                if (!stuneado && !atacar){
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);
                }
            }*/
        }
    }

    public void finalAnim(){
        if (Vector3.Distance(transform.position, target.transform.position) > distanciaAtaque + 0.2f){
            anim.SetBool("attack", false);
        }

        atacar = false;
        stuneado = false;
        rango.GetComponent<CapsuleCollider>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }
}
