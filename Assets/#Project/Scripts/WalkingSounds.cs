using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WalkingSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] foot;
    AudioSource audioSource;
    [SerializeField] PlayerMovement playerMovement;
    float timeBetweenSteps = .5f;
    float timer;
    [SerializeField] float minimumPitch;
    [SerializeField] float maximumPitch;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moving){
            timer += Time.deltaTime;
            if(timer > timeBetweenSteps){
                timer=0;
                PlayFootstep();
            }
        }
    }
    public void PlayFootstep(){
        audioSource.clip = foot[Random.Range(0,foot.Length)];
        audioSource.pitch = Random.Range(minimumPitch, maximumPitch);
        audioSource.Play();
    }
}
