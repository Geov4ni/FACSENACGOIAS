using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTrigger : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject player;
    private NavMeshAgent navInimigo;
    public bool perseguir;

    private Animator Anim;

    public AudioSource A_safe;
    public AudioSource A_suspence;
    public AudioSource A_chase;

    // Start is called before the first frame update
    void Start()
    {
        perseguir = false;
        navInimigo = inimigo.GetComponent<NavMeshAgent>();
        Anim = inimigo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (perseguir == true)
        {
            navInimigo.SetDestination(player.transform.position);
            Anim.SetBool("Chase", true);
        }
        else
        {
            Anim.SetBool("Chase", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            perseguir = true;
            A_safe.Stop();
            A_suspence.Stop();
            A_chase.Play();
        }
    }
}
