using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController player;

    public float horizontalMove;
    public float verticalMove;
    public bool dash;
    public bool attack;
    private Vector3 playerInput;
    public float speed;
    public Camera playerCam;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public Animator animator;

    void start(){
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // Detectar si el jugador presionó la tecla designada
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            dash = true;
        }*/

        if (Input.GetButton("Fire2"))
        {
            attack = true;
            Debug.Log("Atacando");
            animator.SetBool("attack", true);
        }
        else
        {
            attack = false;
            Debug.Log("Dejó de atacar");
            animator.SetBool("attack", false);
        }

        if (Input.GetButton("Jump"))
        {
            dash = true;
            Debug.Log("Dash");
            animator.SetBool("dash", true);
        }
        else
        {
            dash = false;
            Debug.Log("Sin dash");
            animator.SetBool("dash", false);
        }


        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        animator.SetFloat("animHorizontal", horizontalMove);
        animator.SetFloat("animVertical", verticalMove);

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        if (attack){

        }else{
            player.Move(movePlayer * speed * Time.deltaTime);
        }


    }

    void camDirection(){

        camForward = playerCam.transform.forward;
        camRight = playerCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity(){

        movePlayer.y = -gravity * Time.deltaTime;
    }
}
