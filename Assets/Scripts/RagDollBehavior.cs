using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollBehavior : MonoBehaviour
{

    private Animator _animator = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    // Start is called before the first frame update

    public bool ragdollEnabled
    {
        get
        {
            return !_animator.enabled;
        }
        set
        {
            _animator.enabled = !value;
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = !value;
            }
        }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        ragdollEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
