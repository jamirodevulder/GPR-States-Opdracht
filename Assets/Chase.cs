using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class Chase : MonoBehaviour
{
    private Collider detector;
    public playerDetection _playerDetection;
    private NavMeshAgent myAgent;
    public Transform target;


    public delegate void OnTargetNotSet();
    public event Action onTargetNotSet;

    // Start is called before the first frame update
    void Start()
    {
        detector = GetComponentInChildren<Collider>();
 
        myAgent = GetComponent<NavMeshAgent>();


        _playerDetection.onPlayerNotDetected += Unchase;

        
    }

    // Update is called once per frame


    private void Unchase()
    {
        onTargetNotSet?.Invoke();
    }

    public void ChaseNow()
    {
        myAgent.SetDestination(target.position);
    }


}
