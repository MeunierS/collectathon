using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    private int count=0;
    public UnityEvent<int> onPickUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Token")){
            count++;
            Destroy(other.transform.parent.gameObject);
            //deparente le son pour le jouer et le detruire à la fin de sa durée
            AudioSource audio = other.GetComponentInChildren<AudioSource>();
            audio.Play();
            audio.transform.parent = null;
            Destroy(audio.gameObject, audio.clip.length);
            // if (onPickUp !=null){
            //     onPickUp.Invoke();
            // }
            // devient vvv
            onPickUp?.Invoke(count);
        }
    }
}
