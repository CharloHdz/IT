using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActive : MonoBehaviour
{
    //public AudioSource audioSource;
    public GameObject arma;
    public GameObject item;
    //public GameObject signObject;

    private bool activated = false;


    private void OnTriggerEnter(Collider other){
        Debug.Log("Arma activada");

        if (other.tag == "Player"){

            //signObject.SetActive(true);
            if(!activated){

                //audioSource.enabled = true;
                arma.SetActive(true);
                item.SetActive(false);
            }
        }
    }

    //private void OnTriggerExit(Collider other){
        //Debug.Log("OnTriggerExit Event");

        //if (other.tag == "Player"){

            
            //signObject.SetActive(false);
        //}
    //}

}
