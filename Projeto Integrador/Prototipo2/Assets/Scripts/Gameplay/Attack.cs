using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private CharacterBase character;

    private void Awake() {
        character = gameObject.GetComponentInParent<CharacterBase>();
    }

    void OnTriggerEnter(Collider other) {
        //Destroy(other.gameObject);

        if (other.GetComponent<CharacterBase>()) {
            other.GetComponent<CharacterBase>().TookDamage(character.damage);
            if (gameObject.CompareTag("Player")) { GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>().anim_.SetTrigger("Hited"); }

        } else if (other.name == "Bouncing") {

            var p = GameObject.FindGameObjectWithTag("Player");
            int multi = other.transform.position.x > p.transform.position.x ? 1 : -1;

            other.attachedRigidbody.AddForce(new Vector3(15 * multi, 5, 0), ForceMode.Impulse);
        }
    }

}