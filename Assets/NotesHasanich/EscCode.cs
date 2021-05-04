using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EscCode : MonoBehaviour
{
    public GameObject Menu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) )
        {
            if(Menu.activeSelf == false)
            {
                Cursor.visible = true; 
                Screen.lockCursor = false;
                Menu.SetActive(true);
            }
            else
            {
                Cursor.visible = false;
                Menu.SetActive(false);
                Screen.lockCursor = true; 
            }
        }
    }

    public void CursorActiveSelf (bool active)
    {
        Cursor.visible = active; 
    }
    
}
