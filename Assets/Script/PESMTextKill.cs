using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PESMTextKill : MonoBehaviour
{
    public AudioSource laughAudio;

    void Start()
    {
        Destroy(gameObject, 2.0f);
        laughAudio = GetComponent<AudioSource>();
        laughAudio.Play();
    }

    void Update()
    {
        
    }
}
