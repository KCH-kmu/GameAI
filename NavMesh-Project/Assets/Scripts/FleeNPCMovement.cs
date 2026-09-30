using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
public class FleeNPCMovement : MonoBehaviour
{
    public float runAwayDistance = 10;
    public GameObject targetGO;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = targetGO.transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if(distanceToTarget < runAwayDistance) FleeFromTarget(targetPosition);
    }

    private void FleeFromTarget(Vector3 targetPosition)
    {
        Vector3 destination = PositionToFleeTowards(targetPosition);
        HeadForDestination(destination);
        UsefulFunctions.DebugRay(transform.position, destination, Color.yellow);
    }

    private void HeadForDestination(Vector3 destinationPosition)
    {
        navMeshAgent.SetDestination(destinationPosition);
    }

    private Vector3 PositionToFleeTowards(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(transform.position - targetPosition);
        Vector3 runToPosition = targetPosition + (transform.forward * runAwayDistance);
        return runToPosition;
    }
}
