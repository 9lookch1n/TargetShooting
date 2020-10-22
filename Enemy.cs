using UnityEngine;

public class Enemy : MonoBehaviour
{
    //set up speed
    private float speed = 50f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        //target on waypoint
        target = Waypoints.points[0];
    }
    private void Update()
    {
        //diraction target - transform
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime * 0.1f ,Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            //next waypoint 
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        //conditions of arrival
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            // Destroy Object when arrived
            Destroy(gameObject);
            return;
        }
        //wavepoint more and more
        wavepointIndex++;
        //set target by waypoint
        target = Waypoints.points[wavepointIndex];
    }

}
