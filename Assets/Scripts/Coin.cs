using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]private AudioSource _audio;
    [SerializeField] private GameObject Particle;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audio.Play();
            Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.SumCoin();
        }
    }
}
