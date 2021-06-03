using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerDeadScript : MonoBehaviour
{
    public UnityEvent DeadEvent;
    public UnityEvent RespEvent;
    Transform PlayerTrans;
    public GameObject Camera;
    public GameObject Canvas;
    Animator anim;
    public Transform checkPoint;
    public Transform CameraPosition;
    void Start() {
        PlayerTrans = this.GetComponent<Transform>();
        anim = Camera.GetComponent<Animator>();
    }
    public void SetCheckPoint(Transform Point)
    {
        checkPoint = Point;
    }
    public void Dead()
    {
        DeadEvent.Invoke();
        anim.Play("CameraDeath");
        
        Canvas.GetComponent<Animator>().Play("CanvasEnable");
    }
    public void reSpawn()
    {
        PlayerTrans.position = checkPoint.position;
        Camera.transform.position = CameraPosition.position;
    }


}
