using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Safe : MonoBehaviour
{
    public GameObject FollowTrigger;
    public GameObject Inimigo;
    public GameObject lair;
    private NavMeshAgent navInimigo;

    private AudioSource A_safe;
    private AudioSource A_suspence;
    private AudioSource A_chase;


    // Start is called before the first frame update
    void Start()
    {
        navInimigo = Inimigo.GetComponent<NavMeshAgent>();
        A_safe = GameObject.Find("A_safe").GetComponent<AudioSource>();
        A_suspence = GameObject.Find("A_suspence").GetComponent<AudioSource>();
        A_chase = GameObject.Find("A_chase").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FollowTrigger.GetComponent<FollowTrigger>().perseguir = false;
            navInimigo.SetDestination(lair.transform.position);
            A_safe.Play();
            A_suspence.Stop();
            A_chase.Stop();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            A_safe.Stop();
            A_suspence.Play();
            A_chase.Stop();
        }
    }
}
