using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class CaneCasa : MonoBehaviour
{
    public enum CaneState
    {
        Walk,
        Idle
    }

    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _stoppingDistance = 1f;
    [SerializeField] private float _minIdleDistance = 1f;

    private CaneState _currentCaneState;
    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentCaneState = CaneState.Walk;

    }

    void Update()
    {
        UpdateState();
        CheckTransition();
    }

    private void UpdateState()
    {
        switch (_currentCaneState)
        {
            case CaneState.Walk:
                SetWayPointDestination();
                break;
            case CaneState.Idle:
                Idle();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CheckTransition()
    {
        CaneState newCaneState = _currentCaneState;

        /*switch (_currentCaneState)
        {
            case CaneState.Walk:
                //if (IsTargetWithinDistance(_minIdleDistance))
                    //newCaneState = CaneState.Idle;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newCaneState != _currentCaneState)
        {
            Debug.Log($"Changing State FROM:{_currentCaneState} --> TO:{newCaneState}");
            _currentCaneState = newCaneState;
        }*/
    }

    private void Idle()
    {
        this.GetComponent<Animator>().SetBool("isIdle", true);
        //playanimationIdle
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

    private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }

    public CaneState GetCaneState()
    {
        return _currentCaneState;
    }

    public void SetCaneState(CaneState stato)
    {
        _currentCaneState = stato;
    }

}
