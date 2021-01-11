using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventStart : MonoBehaviour
{
    [SerializeField] UnityEvent AnyEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnyEvent.Invoke();
    }
}
