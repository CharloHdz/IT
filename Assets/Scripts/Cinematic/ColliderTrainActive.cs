using UnityEngine;

public class ColliderTrainActive : MonoBehaviour
{
    public string objectTag = "Player"; // Etiqueta del objeto que se destruirá al atravesar el collider
    public Animator animator;
    private int blend;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que atraviesa el collider tiene la etiqueta especificada, se destruye
        if (other.CompareTag(objectTag))
        {
            blend = 1;
            animator.SetInteger("Blend", blend);
        }
    }
}
