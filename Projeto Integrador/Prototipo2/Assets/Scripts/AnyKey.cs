using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKey : MonoBehaviour {
    void Update() {
        if (Input.anyKey) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }
}