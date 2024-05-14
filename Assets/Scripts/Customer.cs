using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject _gatheringArea1;
    [SerializeField] private GameObject _gatheringArea2;
    [SerializeField] private GameObject _gatheringArea3;
    [SerializeField] private GameObject _gatheringArea4;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        MoveToRandomArea();
    }

    private void MoveToRandomArea()
    {
        int selectedArea = Random.Range(1, 5);

        switch (selectedArea)
        {
            case 1:
                _navMeshAgent.destination = _gatheringArea1.transform.position;
                break;
            case 2:
                _navMeshAgent.destination = _gatheringArea2.transform.position;
                break;
            case 3:
                _navMeshAgent.destination = _gatheringArea3.transform.position;
                break;
            case 4:
                _navMeshAgent.destination = _gatheringArea4.transform.position;
                break;
        }
    }
}
