using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CannonBallBehavior : MonoBehaviour
{
    public float forceOnFire = 300;

    bool fire = false;
    bool canFire = true;

    Rigidbody rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && canFire)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(transform.forward * forceOnFire);
            canFire = false;
        }
    }
}
