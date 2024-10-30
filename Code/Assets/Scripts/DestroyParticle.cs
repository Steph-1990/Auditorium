using System.Collections;
using System.Collections.Generic;
using UnityEngine;


                                                                                            // PARTICLE PREFAB

public class DestroyParticle : MonoBehaviour
{

    [SerializeField] private float _destroySpeed;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude < _destroySpeed)
        {
            
            Destroy(gameObject);
        }
    }
}