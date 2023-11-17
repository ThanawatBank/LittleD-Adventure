using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private List<Transform> point;
    [SerializeField] private int nextID = 0;
    [SerializeField] private GameObject vfx;
    private int idChangeValue = 1;
    private float speed = 2f;


    private void Reset()
    {
        Init();
    }
    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("Waypoint");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position; ;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;
        point = new List<Transform>();
        point.Add(p1.transform); point.Add(p2.transform);
    }



    void Start()
    {

    }
    void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalpoint = point[nextID];
        if (goalpoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalpoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, goalpoint.position) < 1f)
        {
            if (nextID == point.Count - 1)
            {
                idChangeValue = -1;
            }
            if (nextID == 0)
            {
                idChangeValue = 1;
            }
            nextID += idChangeValue;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<HealthBar>().Lostlife();
            VFXD();
        }
    }
    void VFXD()
    {
        Instantiate(vfx, transform.position, transform.rotation);
    }
}
