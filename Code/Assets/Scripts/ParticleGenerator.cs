using System.Collections;
using System.Collections.Generic;
using UnityEngine;


                                                                                                        // PARTICLE GENERATOR

public class ParticleGenerator: MonoBehaviour
{
    [SerializeField] private GameObject _particulePrefab; 
    [SerializeField] float _Delay;
    [SerializeField] float _particuleSpeed;
    [SerializeField] float _radius;
    
    Transform _transform;
    float _lastParticuleTime;
    

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        if (Time.time > _lastParticuleTime + _Delay)
        {
            _lastParticuleTime = Time.time;
            
           Vector3 _spawnPoint = _transform.position + (Vector3) Random.insideUnitCircle * _radius;  // Cr�e un point de spaw dans un rayon de valeur "_radius". On lui ajoute ensuite le transform du g�n�rateur de particules pour que la particule soit cr��e dans un rayon autour du g�n�rateur et non au centre de la sc�ne.                 
            GameObject particule = Instantiate(_particulePrefab, _spawnPoint, _transform.rotation);
            Rigidbody2D _rigidbody = particule.GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(transform.right * _particuleSpeed, ForceMode2D.Impulse); // Applique une impulsion pour faire partir la particule vers la droite
           _rigidbody.drag = 0.1f;
        }    
    }
}
