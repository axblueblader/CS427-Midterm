using UnityEngine;
using System.Collections;

public class BtnClickSound : MonoBehaviour
{

    public AudioSource audioSource;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound() {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
