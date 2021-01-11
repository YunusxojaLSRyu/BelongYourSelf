using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvenController : MonoBehaviour
{
    public bool Enter = false;
    public bool StartEvent;
    [SerializeField] UnityEvent AnyEvent;
    [SerializeField] UnityEvent EnterEvent;
    [SerializeField] UnityEvent ExitEvent;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && (StartEvent == true) && (Enter == true)) // получаем нажатие кнопки E
        {
           AnyEvent.Invoke();
        }   
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            Enter = true;
            EnterEvent.Invoke();
        } 
    }
    void OnTriggerExit(Collider other) {
            if (other.tag == "Player")
            {
                Enter = false;
                ExitEvent.Invoke();
            }
        }
        public void StartEven() {
            StartEvent = true;
        }

}
     
