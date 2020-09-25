using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollTriggerBehavior : MonoBehaviour
{
    private Animator animator = null;
    private CharacterController controller = null;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        RagDollBehavior ragdoll = other.GetComponent<RagDollBehavior>();
        animator = other.GetComponent<Animator>();
        controller = other.GetComponent<CharacterController>();
        if (ragdoll != null)
        {
            controller.enabled = false;
            animator.enabled = false;
            ragdoll.ragdollEnabled = true;

        }
    }
}
