using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGravestone : Interactable
{
    private bool HasUsed = false;

    private void Update()
    {
        if (HasUsed) return;
        if (!IsInRange()) return;

        GameManager.AmendCurrency(250, '+');

        HasUsed = true;
    }
}
