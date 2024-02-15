using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControl : MonoBehaviour
{
    private int zombie_death_amount;
    public TextMeshProUGUI TextWarningBoss;
    public TextMeshProUGUI TextDeathZombieAmount;
    public void UpdateDeathZombies()
    {
        zombie_death_amount++;
        TextDeathZombieAmount.text = string.Format("x {0}", zombie_death_amount);
    }
    public void AppearBossWarning()
    {
        StartCoroutine(DisappearText(2, TextWarningBoss));
    }
    IEnumerator DisappearText(float time_desappear, TextMeshProUGUI textToDisappear)
    {
        textToDisappear.gameObject.SetActive(true);
        Color text_color = textToDisappear.color;
        text_color.a = 1;
        textToDisappear.color = text_color;
        yield return new WaitForSeconds(1);
        float counter = 0;

        while (textToDisappear.color.a > 0)
        {
            counter += Time.deltaTime / time_desappear;
            text_color.a = Mathf.Lerp(1, 0, counter);
            textToDisappear.color = text_color;
            yield return null;
            if (textToDisappear.color.a <= 0)
            {
                textToDisappear.gameObject.SetActive(false);
            }
        }
    }
}
