using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour {

    private Player player;
    private TextMeshProUGUI P_NAME;
    public TextMeshProUGUI E_NAME;
    private Slider P_HP;
    public Slider E_HP;
    public GameObject EnemyUI;

    public GameObject VOID;

    private Animator anim;

    public float EnemyUITime = 4f;
    private float EnemyTimer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        P_NAME = GameObject.Find("P_NAME").GetComponent<TextMeshProUGUI>();

        P_HP = GameObject.Find("P_HP").GetComponent<Slider>();
        P_HP.maxValue = player.maxHealth;

        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        P_HP.value = player.HP;

        EnemyTimer += Time.deltaTime;
        if (EnemyTimer >= EnemyUITime) {
            //EnemyUI.SetActive(false);

            EnemyUI.SetActive(false);
            VOID.SetActive(true);

            EnemyTimer = 0;
        }
    }

    public void EnemyUpdate(int maxHealth, int currentHealth, string name = "Enemy") {
        EnemyUI.SetActive(true);
        VOID.SetActive(false);

        E_HP.maxValue = maxHealth;
        E_HP.value = currentHealth;
        E_NAME.text = name;
        EnemyTimer = 0;
    }

    // Animation Stuff
    public void AnimGO() {
        anim.Play("Go");
    }

    public void SoundGO() {
        AudioSource tmp = GetComponent<AudioSource>();
        tmp.clip = Resources.Load<AudioClip>("SFX/gogogo");
        tmp.loop = false;
        tmp.Play();
    }
}