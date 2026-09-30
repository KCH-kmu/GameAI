using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement : MonoBehaviour
{
    public GameObject targetGo;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        HeadForDestination();
    }

    private void HeadForDestination()
    {
        Vector3 destination = targetGo.transform.position;
        navMeshAgent.SetDestination(destination);
        UsefulFunctions.DebugRay(transform.position, destination, Color.yellow);
    }
}
