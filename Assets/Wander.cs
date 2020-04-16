using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    [SerializeField] private Transform leftCorner;
    [SerializeField] private Transform rightCorner;
    [SerializeField] private NavMeshAgent myAgent;
    private Vector3 firstLoction;
    public void Start()
    {
        firstLoction = randomposition();
        CheckDestenation();
    }
    public Vector3 randomposition()
    {
        float randomX;
        float randomZ;
        Vector3 hoek1 = leftCorner.position;
        Vector3 hoek2 = rightCorner.position;
        if (hoek1.x < hoek2.x)
        {
            randomX = Random.Range(hoek1.x, hoek2.x);
        }
        else
        {
            randomX = Random.Range(hoek2.x, hoek1.x);
        }
        if (hoek1.y < hoek2.y)
        {
            randomZ = Random.Range(hoek1.z, hoek2.z);
        }
        else
        {
            randomZ = Random.Range(hoek2.z, hoek1.z);
        }

        return new Vector3(randomX, transform.position.y, randomZ);
    }
    public void CheckDestenation()
    {
        float dist = Vector3.Distance(transform.position, firstLoction);
        if (dist < 20)
        {
            firstLoction = randomposition();
            myAgent.SetDestination(firstLoction);
        }
        else
        {
            myAgent.SetDestination(firstLoction);
        }
    }
}
