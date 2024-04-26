using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image[] kingdomHealthIcons;
    [SerializeField] private SmoothAnimation smoothAnimation;
    [SerializeField] private int[] health;
    public int[] Health => health;
    private void Start()
    {
        smoothAnimation.FillChanged += SetIconFill;
    }

    public void TakeDamage(int[] damage)
    {
        for (int i = 0; i < health.Length; i++) 
        {
            health[i] = health[i] + damage[i];
            health[i] = Mathf.Clamp(health[i], 0, 100);
        }
    }
    
    public bool DeathCheck()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (health[i] == 0)
            {
                Debug.LogWarning("’п Ќиже нул€, количество дней не будет добавлено, следовательно мы избежим ошибок");
                return true;
            }
        }
        return false;
    }

    public void UpdateHealth(int[] damage)
    {
        for (int i = 0; i < kingdomHealthIcons.Length; ++i)
        {
            if (damage[i] != 0)
            {
                StartCoroutine(smoothAnimation.SmoothFillChange(0, 100, kingdomHealthIcons[i].fillAmount, health[i] / 100f, 
                    ColorChange(damage[i], health[i]/100f, kingdomHealthIcons[i].fillAmount), kingdomHealthIcons[i]));
            }
        }
    }

    private Color ColorChange(int damage, float health, float fill)
    {
        if (Math.Abs((health - fill)) > 0.001f)
        {
            if (damage > 0) return new Color(0.37f, 0.59f, 0.37f);
            else if (damage < 0) return new Color(0.66f, 0.25f, 0.29f);
        }
        return Color.white;
    }

    private void SetIconFill(float currentFill, Image targetObject)
    {
        targetObject.fillAmount = currentFill;
    }
}
