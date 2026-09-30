using UnityEngine;

public class UsefulFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DebugRay(Vector3 origin, Vector3 destination, Color c)
    {
        Vector3 direction = destination - origin;
        Debug.DrawRay(origin, direction, c);
    }
}
