using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EscCode : MonoBehaviour
{
    public UnityEvent Esc;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.Invoke();
        }
    }
    
}
