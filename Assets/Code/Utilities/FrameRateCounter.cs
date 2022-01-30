using UnityEngine;

public class FrameRateCounter : MonoBehaviour
{
    private TMPro.TMP_Text m_Text;

    private void Start()
    {
        m_Text = GetComponent<TMPro.TMP_Text>();

        if (m_Text == null)
            Debug.LogError("Error: TMPPro.TMP_Text component not found.\n* This script will only run on an object with a TMPro.TMP_Text component.", gameObject);
    }

    private void Update()
    {
        if (m_Text != null)
        {
            int framerate = (int)(1.0f / Time.smoothDeltaTime);
            m_Text.SetText(framerate.ToString());
        }
    }
}