using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image targetObject;
    [SerializeField] private LoadingScene scene;
    
    private void Awake()
    {
        StartCoroutine(Fade(0,1));
    }
    public void StartCourutine()
    {
        Debug.Log("Я нажата ");
        StartCoroutine(Fade(1, -1));
    }
    public IEnumerator Fade(int targetColor, int minusOrPlus)
    {
        while (targetObject.color.a != targetColor)
        {
            targetObject.color = new Color(0, 0, 0, targetObject.color.a - (0.005f * minusOrPlus));
            yield return new WaitForSeconds(0.002f);
        }
        Debug.Log($"Я торможу {targetObject.color.a}");
        if (targetObject.color.a == 1)
        {
            scene.OpenScene();
        }
    }
    

}
