using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public Text moneyTXT;
    public Text multiplyText;
    public Text healthLvl;
    public Text dmgLvl;
    [Space]
    public DefaultAttack defAttack;
    public GameObject defAttackGM;
    void Update()
    {
        if(moneyTXT != null)
        {
            moneyTXT.text = GameManager.Instance.money.ToString("");
        }
        if(healthLvl != null)
        {
            healthLvl.text = "LVL: " + (GameManager.Instance.lvlHealth + 1).ToString("");
        }
        if(dmgLvl != null)
        {
            dmgLvl.text = "LVL: " + (GameManager.Instance.lvlDamage + 1).ToString("");
        }
        if(multiplyText != null)
        {
            if(defAttack.multiply > 1)
            {
                defAttackGM.SetActive(true);
                multiplyText.text = defAttack.multiply + "x";
            }
        }
    }
    public void Starting()
    {
        GameManager.Instance.StartGame();
    }
    public void UpHealth()
    {
        if(GameManager.Instance.money >=10)
        {
            GameManager.Instance.lvlHealth++;
            GameManager.Instance.money -= 10;
        }
    }
     public void UpDamage()
    {
        if(GameManager.Instance.money >=10)
        {
            GameManager.Instance.lvlDamage++;
            GameManager.Instance.money -= 10;
        }
    }
}