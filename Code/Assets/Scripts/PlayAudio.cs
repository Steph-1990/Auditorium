using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource[] _audioSource; // On stock dans "Audio Manager" les components AudioSource des 3 MusicBox
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] Slider _volumeSlider;
    [SerializeField] private string _paramName;

    private int _allBoxVolumeMax = 0;
    private float _lastTime;
    private float _delay = 5;

    private void awake()
    {
        _audioSource = GetComponents<AudioSource>(); // On vient récupérer les valeurs du component Audiosource de chaque MusicBox et on la stock dans la variable
    }

    private void Start()
    {
        _audioMixer.SetFloat(_paramName, _volumeSlider.value);

        foreach (AudioSource item in _audioSource) // Pour chaque élément contenu dans cette nouvelle variable, on joue sa musique. Ce qui explique que la musique démarre automatiquement au démarrage de l'application.
        {
            item.Play();
        }
    }


    private void Update()
    {

        

        foreach (AudioSource item in _audioSource)
        {
            if (item.volume == 1)
            {             
                    _allBoxVolumeMax++;               
            }
            else
            {
                _allBoxVolumeMax = 0;
            }
        }

        if (_allBoxVolumeMax == _audioSource.Length)
        {
            _lastTime = Time.time;
        }

        if (_allBoxVolumeMax >= _audioSource.Length && Time.time > _lastTime + _delay)
        {
                Debug.Log("VICTOIRE");
        } 
    }

    public void SetValue(float value)
    {
        _audioMixer.SetFloat(_paramName, value);
    }

}

