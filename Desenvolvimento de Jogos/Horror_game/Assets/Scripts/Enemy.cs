using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Inimigo;
    public float speed;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = Inimigo.GetComponent<Animator>();
        speed = Inimigo.GetComponent<NavMeshAgent>().velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat("Speed", speed);
        print("Velocidade: "+ speed);
    }
}
