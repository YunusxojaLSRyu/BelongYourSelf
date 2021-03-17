using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieController : MonoBehaviour
{   
    [SerializeField] UnityEvent Idle;
    [SerializeField] UnityEvent Attack;
    [SerializeField] UnityEvent Run;
    [SerializeField] string idleAnimationName;
    [SerializeField] string AttackAnimationName;
    [SerializeField] string RunAnimationName;
    [SerializeField] string dieAnimationName;
    public string targetTag = "Player";
    public int rays = 8;
    public int distance = 33;
    public float angle = 40;
    public Vector3 offset;
    public Transform target;
    public float _health = 100;
    private bool _game = true;
    public float _dist;
    [SerializeField] float _radius;
    [SerializeField] float _hitRadius;
    [SerializeField] GameObject _player;
    NavMeshAgent _nav;
    Animator _anim;
    public GameObject[] Points;
    int i = 0;
    float Dist_to;
    

    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    void Update()
    {
        if (_game == true)
        {
            _dist = Vector3.Distance(_player.transform.position, transform.position);
                if (_dist > distance )
                {
                    _anim.SetTrigger(idleAnimationName);
                    Idle.Invoke();
                    _nav.enabled = false;
                }
                if (_dist < _radius && _dist > _hitRadius)
                {
                    Run.Invoke();
                    _anim.SetTrigger(RunAnimationName);
                    _nav.enabled = true;
                    _nav.SetDestination(_player.transform.position);
                }
                if (_dist < _radius && _dist < _hitRadius)
                {
                    Attack.Invoke();
                    _anim.SetTrigger(AttackAnimationName);
                    _nav.enabled = true;
                }
                if (_dist < distance)
                {
                    if (RayToScan())
                    {
                       _nav.enabled = true;
                       _nav.SetDestination(_player.transform.position);
                          // Контакт с целью
                    }
                    else
                    {
                        Brojdeniye();
                    }
                }  
        
    } 
    void Brojdeniye(){
        _nav.enabled = true;
        
        _nav.SetDestination(Points[i].transform.position);
        if (Vector3.Distance(Points[i].transform.position, gameObject.transform.position) < 2)
        {
            i = (UnityEngine.Random.Range(0, 4)); 
        }
    }
  }
}
