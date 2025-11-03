using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public int currentCombo = 0;
    public TextMeshProUGUI comboText;

    void Start()
    {
        UpdateComboUI();
    }

    public void IncreaseCombo()
    {
        currentCombo++;
        UpdateComboUI();
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        UpdateComboUI();
    }

    void UpdateComboUI()
    {
        comboText.text = currentCombo > 0 ? $"{currentCombo} Combo!" : "";
    }
}
