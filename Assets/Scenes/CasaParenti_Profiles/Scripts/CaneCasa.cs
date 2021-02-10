using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CaneCasa : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _stoppingDistance = 1f;
    [SerializeField] private float _minFoundDistance = 1f;
    private int _currentWayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetWayPointDestination();
    }
    private void SetWayPointDestination()
    {
        _navMeshAgent.isStopped = false;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 2f)
        //if (_navMeshAgent.transform.position == _waypoints[_currentWayPointIndex].position)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    }
}
