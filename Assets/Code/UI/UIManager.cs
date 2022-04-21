using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Currency")]
    public TMPro.TMP_Text CurrencyText;

    [Header("Health Bar")]
    public Slider HealthSlider;
    public Image HealthBarFill;
    public Gradient HealthBarGradient;

    [Header("XP Bar")]
    public Slider XPSlider;
    public TMPro.TMP_Text XPLevelText;

    [Header("Inventory")]
    public Sprite SelectedItemSprite;
    public Sprite UnselectedItemSprite;
    public Image[] HUDBackgrounds = new Image[3];
    public Image[] ItemImages = new Image[3];

    [Header("Consumable Reward Popup")]
    public InventoryManager invManager;
    public GameObject CR_Popup;
    public TMPro.TMP_Text CR_PopupText;
    public Image CR_Icon;

    private int? consumableReward = null;


    private decimal m_HealthBuffer = GameManager.GetHealth();
    private readonly decimal m_HealthBufferAmount = 0.5m;

    private decimal m_XPBuffer;
    private readonly decimal m_XPBufferAmount = 0.2m;

    public void ShowConsumableRewardPopup()
    {
        consumableReward = Random.Range(0, invManager.Consumables.Length);

        if (consumableReward == null)
            return;

        CR_PopupText.SetText(invManager.Consumables[(int)consumableReward].iName);
        CR_Icon.sprite = invManager.Consumables[(int)consumableReward].iSprite;

        CR_Popup.SetActive(true);
        GameManager.SetCursor(LockMode.Confined);
        GameManager.CanMoveCamera = false;
        GameManager.CanUseWeapon = false;
    }

    public void CRYes()
    {
        if (consumableReward == null)
            return;

        invManager.SetConsumable((int)consumableReward);
        CRNo();
    }

    public void CRNo()
    {
        CR_Popup.SetActive(false);
        CR_PopupText.SetText("");
        CR_Icon.sprite = null;
        GameManager.SetCursor(LockMode.Lock);
        GameManager.CanMoveCamera = true;
        GameManager.CanUseWeapon = true;
    }

    private void Update()
    {
        // Currency
        CurrencyText.SetText(GameManager.GetCurrency().ToString());

        // Player Health Bar
        if (m_HealthBuffer < GameManager.GetHealth())
            m_HealthBuffer += m_HealthBufferAmount;
        else if (m_HealthBuffer > GameManager.GetHealth())
            m_HealthBuffer -= m_HealthBufferAmount;

        HealthSlider.value = ((float)m_HealthBuffer);
        HealthBarFill.color = HealthBarGradient.Evaluate(HealthSlider.normalizedValue);

        // XP Bar
        int level = (int)GameManager.GetXP() / 100;
        decimal XP = GameManager.GetXP() - (level * 100);

        if (m_XPBuffer < XP)
            m_XPBuffer += m_XPBufferAmount;
        else if (m_XPBuffer > XP)
            m_XPBuffer = 0;

        XPSlider.value = ((float)m_XPBuffer);
        XPLevelText.SetText(level.ToString());
    }

    public void UpdateInventoryUI(InventoryItem[] items, int selectedItemIndex)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                ItemImages[i].sprite = items[i].iSprite;
                ItemImages[i].enabled = true;
            }
            else
            {
                ItemImages[i].sprite = null;
                ItemImages[i].enabled = false;
            }

            if (i == selectedItemIndex)
                HUDBackgrounds[i].sprite = SelectedItemSprite;
            else
                HUDBackgrounds[i].sprite = UnselectedItemSprite;
        }
    }
}
