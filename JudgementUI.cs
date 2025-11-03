using UnityEngine;
using TMPro;
using System.Collections;

public class JudgementUI : MonoBehaviour
{
    public TextMeshProUGUI judgementText;
    public float displayDuration = 0.5f;

    private Coroutine hideCoroutine;

    public void ShowJudgement(string result)
    {
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        judgementText.text = result;
        judgementText.gameObject.SetActive(true);

        hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        judgementText.gameObject.SetActive(false);
    }
}
