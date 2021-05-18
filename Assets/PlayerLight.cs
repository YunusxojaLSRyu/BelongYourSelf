using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 100);//Запуск Луча(Позиция, Направление, RaycastHit, длинна луча )
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if(hit.transform.tag == "Shadow")
        {
            hit.transform.GetComponent<ShadowController>().Light();
        }
    }
}
