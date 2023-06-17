using System;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private Transform _spawnPosition;
    
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SpawnAndPlay()
    {
        _audio.Play();
        GameObject createdParticle = Instantiate(_particle, transform);
        createdParticle.transform.position = _spawnPosition.position;
        Destroy(createdParticle, 1.5f);
    }
}
