using System;
using UnityEngine;
using UnityEngine.AI;


public class DogSM : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform target;
    [SerializeField] private DogAnimator dogAnimator;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        _navMeshAgent.SetDestination(new Vector3(target.position.x, 0f, target.position.z));
        dogAnimator.velocityX = _navMeshAgent.velocity.x;
        dogAnimator.velocityZ = _navMeshAgent.velocity.z;
    }
}
