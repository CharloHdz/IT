using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public float health;//Vida del Jugador
    [SerializeField] public float maxHealth;
    [SerializeField] public int modenas;//Dinero si hay en el juego 
    [SerializeField] public float magic;//Efecto de estado
    [SerializeField] public float strength;//Fuerza
    [SerializeField] public float damage;//Dano elemental
    [SerializeField] public float defense;//Defensa
    [SerializeField] public float endurace_E;//Resistencia Elemental
    [SerializeField] public float enhancer_H;//Potenciador Habilidad
    [SerializeField] public float enhancer_E;//Potenciador Elemental
    //[SerializeField] public barra_Vida barra;
    [SerializeField] public float helmet, front, pants, boots, weapon, shield;//Casco, pechera,pantalones,botas,armas y escudo



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        modenas = 0;
        magic = 0;
        strength = 1;
        damage = 0;
        defense = 1;
        endurace_E = 0;
        enhancer_H = 0;
        enhancer_E = 0;
        helmet = 0;
        front = 0;
        pants = 0;
        boots = 0;
        weapon = 1;
        shield = 0;
        //barra.inicioBarraVida(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void tomardano(float dano)
    {
        health -= dano;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
