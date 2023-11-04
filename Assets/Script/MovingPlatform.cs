using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> point;
    [SerializeField] private Transform platform;
    private int goalpoint = 0;
    [SerializeField] private float moveSpeed =  2;


    private void Update()
    {
        MoveToNextPoint();
    }
    private void MoveToNextPoint()
    {
        platform.position = Vector2.MoveTowards(platform.position, point[goalpoint].position, Time.deltaTime * moveSpeed);

        if (Vector2.Distance(platform.position, point[goalpoint].position) < 0.1f)
        {
            if (goalpoint ==  point.Count - 1)
            {
                goalpoint = 0;
            }
            else
            {
                goalpoint++;
            }
        }
    }
}
