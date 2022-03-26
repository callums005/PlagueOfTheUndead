using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CharacterType { Any, Knight, Mage }
public enum WeaponType { Mylee, Spell }
public enum ConsumableType { Healing, LifeBottle, Rage }

public enum LockMode { Lock, Confined, Unlock }
public static class GameManager
{
    public static void SetCursor(LockMode mode)
    {
        switch (mode)
        {
            case LockMode.Lock:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case LockMode.Confined:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;
            case LockMode.Unlock:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }
    
    public static CharacterType CharType = CharacterType.Knight;
    public static bool CanUseWeapon = true;
    public static bool CanMoveCamera = true;

    private static int Currency = 0;
    private static readonly decimal  MaxHealth = 100;
    private static decimal Health = 100;
    private static decimal XP = 0;

    public static int GetCurrency() { return Currency; }

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

    public static void SetCurrency(int amount)
    {
        Currency = amount;
    }

    public static decimal GetXP() { return XP; }

    public static void AddXP(decimal amount)
    {
        XP += amount;
    }

    public static void SetXP(decimal amount)
    {
        XP = amount;
    }

    public static decimal GetHealth() { return Health; }

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

        if (Health <= 0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

}
