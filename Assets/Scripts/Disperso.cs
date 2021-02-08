using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class Disperso : MonoBehaviour
{
    public enum DispersoState
    {
        Wander,
        Found
    }

    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _stoppingDistance = 1f;
    [SerializeField] private float _minFoundDistance = 1f;

    private DispersoState _currentDispersoState;
    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentDispersoState = DispersoState.Wander;

    }

    void Update()
    {
        UpdateState();
        CheckTransition();
    }

    private void UpdateState()
    {
        switch (_currentDispersoState)
        {
            case DispersoState.Wander:
                SetWayPointDestination();
                break;
            case DispersoState.Found:
                Found();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void CheckTransition()
    {
        DispersoState newDispersoState = _currentDispersoState;

        switch (_currentDispersoState)
        {
            case DispersoState.Wander:
                if (IsTargetWithinDistance(_minFoundDistance))
                    newDispersoState = DispersoState.Found;
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newDispersoState != _currentDispersoState)
        {
            Debug.Log($"Changing State FROM:{_currentDispersoState} --> TO:{newDispersoState}");
            _currentDispersoState = newDispersoState;
        }
    }

    private void Found()
    {
        _navMeshAgent.isStopped = true;
        //playanimationfound
    }

    private void SetWayPointDestination()
    {
        _navMeshAgent.isStopped = false;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance&& _navMeshAgent.velocity.sqrMagnitude <= 2f)
        //if (_navMeshAgent.transform.position == _waypoints[_currentWayPointIndex].position)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    }

    private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }

    public DispersoState GetDispersoState()
    {
        return _currentDispersoState;
    }


}
