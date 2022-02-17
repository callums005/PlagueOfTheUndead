using System;
using UnityEngine;

public enum CharacterType { Any, Knight, SpellMajor }
public enum WeaponType { Mylee, Spell }
public static class GameManager
{
    public static CharacterType CharType;

    private static int Currency = 50;
    private static readonly decimal  MaxHealth = 100;
    private static decimal Health = 100;
    private static decimal XP = 0;

    public static int GetCurrency()
    {
        return Currency;
    }

    public static void AmendCurrency(int amount, char sign)
    {
        if (sign == '+')
            Currency += amount;
        else if (sign == '-')
            if (Currency - amount >= 0)
                Currency -= amount;
        else
            Debug.LogError("Invalid sign [AmendCurrency(int amount, char sign)");
    }

    public static decimal GetXP()
    {
        return XP;
    }

    public static void AddXP(decimal amount)
    {
        XP += amount;
    }

    public static void SetXP(decimal amount)
    {
        XP = amount;
    }

    public static decimal GetHealth()
    {
        return Health;
    }

    public static void AmendHealth(decimal amount, char sign)
    {
        if (sign == '+')
            if (Health + amount > MaxHealth)
                Health = MaxHealth;
            else
                Health += amount;
        else if (sign == '-')
            if (Health - amount > 0)
                Health -= amount;
            else
                Health = 0;
        else
            Debug.LogError("Invalid sign [AmendHealth(decimal amount, char sign)");
    }

}
