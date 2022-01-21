using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMPro.TMP_Text CurrencyText;
    public Slider HealthSlider;
    public Image HealthBarFill;

    public Gradient HealthBarGradient;

    private decimal m_HealthBuffer = GameManager.GetHealth();
    private decimal m_BufferAmount = 0.2m;


    // Update is called once per frame
    void Update()
    {
        if (m_HealthBuffer < GameManager.GetHealth())
            m_HealthBuffer += m_BufferAmount;
        else if (m_HealthBuffer > GameManager.GetHealth())
            m_HealthBuffer -= m_BufferAmount;

        CurrencyText.SetText(GameManager.GetCurrency().ToString());
        HealthSlider.value = ((float)m_HealthBuffer);
        HealthBarFill.color = HealthBarGradient.Evaluate(HealthSlider.normalizedValue);
    }
}
