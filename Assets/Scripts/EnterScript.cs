using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterScript : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            OnEnter.Invoke();
        }
        
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            OnExit.Invoke();
        }
        
    }
}
