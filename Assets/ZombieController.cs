using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
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
            _nav.enabled = false;
        }
        if (_dist < _radius && _dist > _hitRadius)
        {
            _anim.SetTrigger(RunAnimationName);
            _nav.enabled = true;
            _nav.SetDestination(_player.transform.position);
        }
        if (_dist < _radius && _dist < _hitRadius)
        {
            _anim.SetTrigger(AttackAnimationName);
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
