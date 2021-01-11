using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashLight : MonoBehaviour
{
    [SerializeField] UnityEvent On;
    [SerializeField] UnityEvent Off;
    bool LightBool = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && LightBool == true )
        {
            Off.Invoke();
            LightBool = false;
        }else
        if (Input.GetKeyDown(KeyCode.Mouse0) && LightBool == false )
        {
            On.Invoke();
            LightBool = true;
        }
        
        
    }
}
