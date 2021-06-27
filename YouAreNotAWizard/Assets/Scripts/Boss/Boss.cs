using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Slider healthBar;
    public Image HaraldPic;

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if(health < 10)
        {
          deleteHB(healthBar, HaraldPic);
        }

    }

    private void deleteHB(Slider healthBar, Image HaraldPic)
    {
        Destroy(healthBar.gameObject);
        Destroy(HaraldPic.gameObject);
    }
}
