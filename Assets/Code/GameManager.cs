using UnityEngine;


public static class GameManager
{
    private static int Currency = 50;
    private static decimal MaxHealth = 100;
    private static decimal Health = 100;

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

    public static decimal GetHealth()
    {
        return Health;
    }

    public static void AmendHealth(decimal amount, char sign)
    {
        if (sign == '+')
            Health += amount;
        else if (sign == '-')
            if (Health - amount > 0)
                Health -= amount;
            else
                Health = 0;
        else
            Debug.LogError("Invalid sign [AmendHealth(int amount, char sign)");
    }

}
