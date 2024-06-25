using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform pointA , pointB;
    public float speed;
    Vector3 targetPos;


    private void Start()
    {
        targetPos = pointB.position;
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, pointA.position) < 0.5f)
        {
            targetPos = pointB.position;
        }
        if (Vector2.Distance(transform.position, pointB.position) < 0.5f)
        {
            targetPos = pointA.position;
        }
        transform.position= Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }

}
