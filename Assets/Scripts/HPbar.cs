using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public Player player;
    public RectTransform hp;
    // Update is called once per frame
    void Update()
    {
        float hpPercent = player.currentHealth / player.maxHealth;
        hp.localScale = new Vector3(hpPercent, 1, 1);
    }
}
