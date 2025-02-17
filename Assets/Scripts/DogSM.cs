using System;
using UnityEngine;
using UnityEngine.AI;


public class DogSM : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    private Transform _target;
    [SerializeField] private DogAnimator dogAnimator;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        if (_target == null) return;
        _navMeshAgent.SetDestination(new Vector3(_target.position.x, 0f, _target.position.z));
        dogAnimator.velocityX = _navMeshAgent.velocity.x;
        dogAnimator.velocityZ = _navMeshAgent.velocity.z;
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
