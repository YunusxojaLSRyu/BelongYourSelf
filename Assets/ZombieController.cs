using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieController : MonoBehaviour
{
    [SerializeField] UnityEvent Idle;
    [SerializeField] UnityEvent Run;
    [SerializeField] UnityEvent Attack;
    [SerializeField] string idleAnimationName;
    [SerializeField] string AttackAnimationName;
    [SerializeField] string RunAnimationName;
    [SerializeField] string dieAnimationName;
    public float _health = 100;
    private bool _game = true;
    public float _dist;
    [SerializeField] float _radius;
    [SerializeField] float _hitRadius;
    [SerializeField] GameObject _player;
    NavMeshAgent _nav;
    Animator _anim;

    void Start() {
        _nav = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    { 
        if (_game == true)
        {
            _dist = Vector3.Distance(_player.transform.position, transform.position);
        if (_dist > _radius )
        {
            _anim.SetTrigger(idleAnimationName);
            Idle.Invoke();
            _nav.enabled = false;
        }
        if (_dist < _radius && _dist > _hitRadius)
        {
            _anim.SetTrigger(RunAnimationName);
            _nav.enabled = true;
            Run.Invoke();
            _nav.SetDestination(_player.transform.position);
        }
        if (_dist < _radius && _dist < _hitRadius)
        {
            Attack.Invoke();
            _anim.SetTrigger(AttackAnimationName);
            _nav.enabled = true;
        }
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet")
        {
            _health = _health - 30;
            if (_health < 0)
            {
                _game = false;
                _anim.SetTrigger(dieAnimationName);
            }
        }
    }
}
