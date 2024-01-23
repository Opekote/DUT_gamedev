using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP_Player : MonoBehaviour

{
    public Image hpPlayer;
    int damage1 = 20;
    int damage2 = 30;
    int damage3 = 50; 
    int hp = 100;
    

    void HPbar(int _hp)
    {
        hpPlayer.fillAmount = (float)hp / 100;
    }

    public void DMG1()
    {
        hp -= damage1;
        HPbar(hp);
    }
    public void DMG2()
    {
        hp -= damage2;
        HPbar(hp);
    }
    public void DMG3()
    {
        hp -= damage3;
        HPbar(hp);
    }

    
    
}
