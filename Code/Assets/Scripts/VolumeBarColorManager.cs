using System.Collections;
using System.Collections.Generic;
using UnityEngine;


                                                                                            // MUSICBOX


public class VolumeBarColorManager : MonoBehaviour
{
    [SerializeField] Material[] _material; // Contient les deux materials "allumée", "éteinte"
    [SerializeField] MeshRenderer[] _volumeBar;  // Contient les 8 barres de couleurs contenu dans chaque Box musical
    [SerializeField] AudioSource _audioSource; // On récupère l'AudioSource de la MusicBox

   // AudioSource _audioSource;


    /*private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }*/

    private void Update()
    {
        for (int i = 1; i <= _volumeBar.Length; i++) // Pour chaque barre de volume...
        {
            if (_audioSource.volume >= (i / (float)_volumeBar.Length)) //... Si le volume est supérieur ou égal à la valeur à laquelle on souhaite
            {
                _volumeBar[i-1].material.color = _material[0].color; // On modifie la couleur de la barre
            }
            else
            {
                _volumeBar[i-1].material.color = _material[1].color; // Sinon on laisse la couleur de la barre tel quel
            }
        }
    }
}