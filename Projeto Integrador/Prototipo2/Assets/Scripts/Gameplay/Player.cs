using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Leandro Peres, ABR de 2019
    Jorge2.0, beta.2
*/

public class Player : CharacterBase {
    private Transform EnemyChecker;
    public int qtoInimigos;

    private void Start() {
        EnemyChecker = transform.Find("EnemyChecker");
    }

    void Update() {

    }

    void FixedUpdate() {
        if (isDead) { return; }

        MoveHandler(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), rb.velocity.y);

        if (Input.GetButtonDown("Jump") && OnGround) {
            Jump();
        }

        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }

        //JumpControl();
    }
}