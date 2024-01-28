using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface IAttack
{
    void Attack(Transform target);
}

public class Stat : MonoBehaviour
{
    public int health;
    public int damage;
    public Slider healthSlider;
    public Text healthText;
    public int maxHealth;
    public DefaultAttack defaultAttack;
    public SuperAttack superAttack;
    public GameObject Menu;
    public ParticleSystem WinPart;
    public bool playerIs;

    void Start()
    {
        if (playerIs)
        {
            GameManager.Instance.player = this;
        }
        else
        {
            GameManager.Instance.enemy = this;
        }
    
        if(defaultAttack == null)
        {
            defaultAttack = gameObject.AddComponent<DefaultAttack>();
        }
        else
        {
            defaultAttack.dmg = damage;
        }

        if(superAttack == null)
        {
            superAttack = gameObject.AddComponent<SuperAttack>();
        }
        else
        {
            superAttack.superAttackValue = damage * 2;
        }
    }

    void Update()
    {
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString("");
        healthSlider.value = health;
    }

    public void Reset()
    {
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString("");
        healthSlider.value = health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = health.ToString("");
        healthSlider.value = health;
        if(!playerIs && health<=0f)
        {
            GameManager.Instance.end = true;
            GameManager.Instance.curLvl++;
            Menu.SetActive(true);
            WinPart.Play();
        }
        else if (playerIs && health<=0f)
        {
            GameManager.Instance.end = true;
            Menu.SetActive(true);
        }
    }
}