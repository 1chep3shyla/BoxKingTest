using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public int lvlDamage;
    public int lvlHealth;
    public int curLvl;
    public int money;
    public bool work;
    public bool end;
    public Stat player;
    public Stat enemy;
    private static GameManager instance;

    private GameManager() {}

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void StartGame()
    {
        work = true;
        end = false;
        enemy.maxHealth = 200 + (curLvl * 75);
        enemy.health = 200 + (curLvl * 75);
        enemy.damage = 20 + (curLvl * 10);
        player.maxHealth = 100 + ( 25 * lvlHealth);
        player.health = player.maxHealth;
        player.damage = 10 + ( lvlDamage * 5);
    }
}