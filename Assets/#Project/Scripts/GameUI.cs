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
            Destroy(other.gameObject);
            // if (onPickUp !=null){
            //     onPickUp.Invoke();
            // }
            // devient vvv
            onPickUp?.Invoke(count);
        }
    }
}
