using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemArt;
    public Sprite outlineArt;

    public int goldCost;
    public int sellAmount;

    //Stats
    public Item buildsInto = null;
    public Item buildsFrom1 = null;
    public Item buildsFrom2 = null;
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
