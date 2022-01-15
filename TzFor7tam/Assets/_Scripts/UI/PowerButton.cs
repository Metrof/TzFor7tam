using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    float bombColldown = 4f;
    float cooldownDone;
    float cooldownStart;
    Button button;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    public void Reload(float spellCooldown)
    {
        button.interactable = false;
        image.fillAmount = 0;
        cooldownStart = Time.time;
        bombColldown = spellCooldown;
        cooldownDone = spellCooldown + Time.time;
    }
    private void Update()
    {
        if (cooldownDone == 0) return;

        float u = (Time.time - cooldownStart) / bombColldown;
        if (Time.time >= cooldownDone)
        {
            button.interactable = true;
            image.fillAmount = 1;
            cooldownStart = 0;
            return;
        }
        image.fillAmount = u;
    }
}
