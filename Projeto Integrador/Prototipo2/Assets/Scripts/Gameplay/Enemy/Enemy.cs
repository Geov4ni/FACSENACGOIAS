using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase {

    protected float walkTimer;
    public float stopDistance = 1f;

    protected Transform Target => GameObject.FindGameObjectWithTag("Player").transform;
    protected Vector3 TargetDistance => Target.position - transform.position;

    private void Start() {
        maxHealth = 3;
        currentHealth = maxHealth;
    }

    private void Update() {
        walkTimer += Time.time;
        anim.SetBool("isDead", isDead);
    }

    void FixedUpdate() {
        if (isDead) { return; }

        float forcaZ;

        float forcaH = TargetDistance.x / Mathf.Abs(TargetDistance.x);
        forcaZ = TargetDistance.z / Mathf.Abs(TargetDistance.z);

        if (walkTimer > Random.Range(0f, 50f)) {
            forcaZ += Random.Range(-1, 2);
            walkTimer = 0;
        }

        if (Mathf.Abs(TargetDistance.x) < stopDistance) { forcaH = 0; }
        if (walkTimer == 0 && Mathf.Abs(TargetDistance.z) < stopDistance * .5f) { forcaZ = 0; }

        if (!damaged) { MoveHandler(forcaH, forcaZ); }

        bool attack = Mathf.Abs(TargetDistance.x) < 1.5f && Mathf.Abs(TargetDistance.z) < 1f;
        if (attack && Time.time > nextAttack) {
            Attack();
        }
    }

    public void Recover() {
        damaged = false;
    }

    public void Revive() {
        anim.Play("Die");
        rb.isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 2.525f);
    }

}