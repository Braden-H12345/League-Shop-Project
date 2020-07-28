using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemArt;

    public int goldCost;
    public int sellAmount;

    //Stats
    public int AD;
    public int AP;
    public int armor;
    public int magic_resist;
    public int health;
    public int movespeedFlat;
    public int movespeedPercent;
    public int crit_chance;
    public int attack_speed;
    public int mana;
    public int cooldown_reduce;
}
