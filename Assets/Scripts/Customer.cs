using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


public class Customer : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public GameObject targetArea;
    [SerializeField] private GameObject _escapePoint;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        NavigateToArea();
    }

    private void NavigateToArea()
    {
            // Assuming the targetArea is a GameObject with a Collider
            Collider areaCollider = targetArea.GetComponent<Collider>();

            if (areaCollider != null)
            {
            // Get a random point within the area collider bounds
            Bounds bounds = areaCollider.bounds;
            Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
            );
            // Set the destination for the NavMeshAgent
            _navMeshAgent.destination = randomPoint;
            }
            else
            {
            Debug.LogError("Target area does not have a Collider component.");
            }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Escape"))
        {
            gameObject.SetActive(false);
        }
    }

    public void Escape()
    {
        _navMeshAgent.destination = _escapePoint.transform.position;
    }
}





























//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class Customer : MonoBehaviour
//{
//    private NavMeshAgent _navMeshAgent;
//    [SerializeField] private GameObject _gatheringArea1;
//    [SerializeField] private GameObject _gatheringArea2;
//    [SerializeField] private GameObject _gatheringArea3;
//    [SerializeField] private GameObject _gatheringArea4;


//    private void Awake()
//    {
//        _navMeshAgent = GetComponent<NavMeshAgent>();
//    }



//    //private void OnEnable()
//    //{
//    //    MoveToRandomArea();
//    //}

//    //private void MoveToRandomArea()
//    //{
//    //    int selectedArea = Random.Range(1, 5);

//    //    switch (selectedArea)
//    //    {
//    //        case 1:
//    //            _navMeshAgent.destination = _gatheringArea1.transform.position;
//    //            break;
//    //        case 2:
//    //            _navMeshAgent.destination = _gatheringArea2.transform.position;
//    //            break;
//    //        case 3:
//    //            _navMeshAgent.destination = _gatheringArea3.transform.position;
//    //            break;
//    //        case 4:
//    //            _navMeshAgent.destination = _gatheringArea4.transform.position;
//    //            break;
//    //    }
//    //}


//}
