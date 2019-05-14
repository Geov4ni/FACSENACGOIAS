using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy {

    public GameObject boomerang;
    public float minBoomerangTime, maxBoomerangTime;

    // Use this for initialization
    void Start() {
        Invoke("ThrowBoomerang", Random.Range(minBoomerangTime, maxBoomerangTime));
    }

    void ThrowBoomerang() {
        if (isDead) { return; }

        anim.SetTrigger("Throw");

        Vector3 tmp = transform.position;
        //tmp.y += 3;

        GameObject tempBoomerang = Instantiate(boomerang, tmp, transform.rotation);

        tempBoomerang.GetComponent<Boomerang>().direction = facingRight ? 1 : -1;

        Invoke("ThrowBoomerang", Random.Range(minBoomerangTime, maxBoomerangTime));

    }

    void BossDefeated() {
        //Invoke("LoadScene", 8f);
    }

    void LoadScene() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
