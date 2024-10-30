using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                                                                        // MUSIC BOX

public class MusicBoxCollision : MonoBehaviour
{
    [SerializeField] float _notParticuleDelay;
    [SerializeField] float _volumeDownSpeed;
    float _lastCollisionEnter;

    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Particule"))
        {
            _lastCollisionEnter = Time.time;
            _audioSource.volume += 0.125f;
        }         
    }

    private void Update()
    {
     
        if (Time.time > _lastCollisionEnter + _notParticuleDelay)
        {      
                _audioSource.volume -= _volumeDownSpeed * Time.deltaTime; // On multiplie la variable _volumeDownSpeed par Time.deltaTime pour convertir cette variable en vitesse/seconde
        }
    }
}