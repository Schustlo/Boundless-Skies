using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private int scorevalue = 1;
    [SerializeField]
    private AudioClip _effect;
    private AudioSource audioSource;

    private bool hasbeenPickedUp = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasbeenPickedUp == false)
        {
            GameManager.Instance.UpdateScore(scorevalue);
            if (_effect)
            {
                audioSource.PlayOneShot(_effect);
            }
            hasbeenPickedUp = true;
            Destroy(this.gameObject);
        }

    }

}
