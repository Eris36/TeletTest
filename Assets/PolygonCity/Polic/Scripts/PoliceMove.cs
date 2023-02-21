using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceMove : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator myAnimator;
    
    public int spot = 0;
    public int next = 1;
    [SerializeField] private Transform[] moveSpots;
    
    
    
    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        myAgent.SetDestination(moveSpots[spot].position);
        
        if (Vector2.Distance(transform.position, moveSpots[spot].position) < 0.15f)
        {
            if(spot == moveSpots.Length-1)
            {
                Run();
                spot = 0;
            }
            else
            {
                spot += next;
            }
            
            
            if (spot == 2 || spot == 4)
            {
                Run();
            }
            
            if (spot == 1 || spot == 3)
            {
                Wald();
            }
        }
        
        
        void Run()
        {
            myAnimator.SetBool("IsRunning", true);
            myAgent.speed = 1;
        }
        
        void Wald()
        {
            myAnimator.SetBool("IsRunning", false);
            myAgent.speed = 0.4f;
        }
        
        
        
        /*
        if (spot == 1 || spot == 0)
        {
            myAnimator.Play("Wald");
        }
        
        
        
        
        for (int i = 0; i < target.Count; i++)
        {
            myAgent.SetDestination(target[i].position);
        }
        myAgent.SetDestination(target.position);
        distance = Vector3.Distance(target.position, transform.position);
        */
        
        
        
        
        /*if (distance > 10)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAgent.speed = 2;
            myAnimator.Play("Run");
        }
        
        if (distance < 10 && distance > 3)
        {
            myAgent.speed = 1;
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAnimator.Play("Walk");
        }
        if (distance <2)
        {
            myAgent.enabled = false;
            myAnimator.Play("Idle");
        }*/
    }
}
