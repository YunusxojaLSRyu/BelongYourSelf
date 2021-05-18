using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ShadowController : MonoBehaviour
{
    
    public float _dist;
    NavMeshAgent _nav;
    [SerializeField] GameObject _player;
        [SerializeField] float _radius;
    [SerializeField] float _hitRadius;
    public bool light = false;
    public UnityEvent onlight;
    public UnityEvent kill;
    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light)
        {
            onlight.Invoke();
        }
        if(!light)
        {
        _dist = Vector3.Distance(_player.transform.position, transform.position);
                if (_dist > _radius )
                {
                    _nav.enabled = false;
                }
                if (_dist < _radius && _dist > _hitRadius)
                {
                    _nav.enabled = true;
                    _nav.SetDestination(_player.transform.position);
                }
                if (_dist < _radius && _dist < _hitRadius)
                {
                    _nav.enabled = false;
                    kill.Invoke();
                }
        }
    }
    public void Light()
    {
        if (_dist < 5)
        {
            light = true;
        _nav.enabled = false;
        this.transform.Translate(-Vector3.back*Time.deltaTime);
        }
        
    }
}
