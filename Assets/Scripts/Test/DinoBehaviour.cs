using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DinoBehaviour : MonoBehaviour
{
    private Animator _animator;
    private int _behaviourIndex;
    private string _behaviour;
    [SerializeField] private GameObject _cage;
    private float _speed;
    private NavMeshAgent _agent;
    public UnityEvent onDestinationReached;
    private float _eventDuration;
    private bool _isMoving;
    private int behaviourChangeCooldown;
    private int threshold = 2;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }


    private void OnEnable()
    {
        behaviourChangeCooldown = 5;
        InvokeRepeating(nameof(BehaviourDecider), 0f, behaviourChangeCooldown);
        _isMoving = false;
     
    }

    private void Update()
    {
    }

    private void BehaviourDecider()
    {
        behaviourChangeCooldown = Random.Range(1, 10);
        _behaviourIndex = Random.Range(0, 6);
        //0 = Idle, 1 = Walking to a random point in the cage, 2 = Prancing, 3 = Eating, 4 = Look Around, 5 = Roll
        switch (_behaviourIndex)
        {
            case 0:
                _behaviour = "Idle";
                break;            
            case 1:
                _behaviour = "Walk";
                break;
            case 2:
                _behaviour = "Prancing";
                break;
            case 3:
                _behaviour = "Eating";
                break;
            case 4:
                _behaviour = "Look Around";
                break;
            case 5:
                _behaviour = "Roll";
                break;
        }
        ChangeBehaviour(_behaviour);
    }

    private void ChangeBehaviour(string behaviour)
    {
        int targetState;
        //Animator value of Idle = 0, Walk = 12, Prancing = 9, Eating = 11, Look around = 14, Roll = 4

        switch (behaviour)     
        {
            case "Idle":
                targetState = 0;
                SetAnimation(targetState);
                _eventDuration = 10f;
                break;
            case "Walk":
                _isMoving = true;
                targetState = 12;
                SetAnimation(targetState);
                StartWalk();
                Debug.Log(this.name + _behaviour + _agent.velocity);

                break;
            case "Prancing":
                targetState = 9;
                SetAnimation(targetState);
                Invoke(nameof(AfterPrancing), 1f);
                break;
            case "Eating":
                targetState = 11;
                SetAnimation(targetState);
                break;
            case "Look Around":
                targetState = 14; SetAnimation(targetState);
                break;
            case "Roll":
                _isMoving = true;
                targetState = 4; SetAnimation(targetState);
                Vector3 randomPointToRoll = GetRandomPoint();
                StartCoroutine(GoToRandomPoint(randomPointToRoll));
                break;

        }

    }

    private void AfterPrancing()
    {
        SetAnimation(0);
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomPoint;
        // Assuming the targetArea is a GameObject with a Collider

        Collider areaCollider = _cage.GetComponent<BoxCollider>();
        // Get a random point within the area collider bounds
        Bounds bounds = areaCollider.bounds;
        randomPoint = new Vector3(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y),
        Random.Range(bounds.min.z, bounds.max.z)
        );

        return randomPoint;
    }

    IEnumerator CheckAgentStatus()
    {
        while (true)
        {
            if (!_agent.pathPending && !_agent.hasPath && _isMoving)
            {
                OnDestinationReached();
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetAnimation(int targetState)
    {

        if ((_animator.GetInteger("State") != 0) && (_animator.GetInteger("State") < 97)) _animator.SetTrigger("Reset");
        _animator.SetInteger("State", targetState);

    }
    private void OnDestinationReached()
    {
        _isMoving = false;
        SetAnimation(0);
    }

    private IEnumerator GoToRandomPoint(Vector3 randompoint)
    {
        yield return new WaitForSeconds(0.3f);
        _agent.destination = randompoint;
        StartCoroutine(CheckAgentStatus());

    }

    private void StartWalk()
    {
        Vector3 randomPoint = GetRandomPoint();
        if (Vector3.Distance(transform.position, randomPoint) > threshold)
            StartCoroutine(GoToRandomPoint(randomPoint));
        else
            StartWalk();
    }
}
