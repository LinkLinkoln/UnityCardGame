using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SaveLoad;

public delegate void LoadingSceneDelegate();
public class LoadingScene : MonoBehaviour
{
    [SerializeField] private int targetYear;
    [SerializeField] private int speed;
    [SerializeField] private TextMeshProUGUI yearText;
    [SerializeField] private TextMeshProUGUI yearDescription;
    [SerializeField] private Image NextButton;
    [SerializeField] private Vector3 targetPos;

    private LoadingSceneDelegate loadingSceneDelegate;


    private void Awake()
    {
        loadingSceneDelegate += PlayButton;
        string savePath = Application.persistentDataPath + "/saveData.json";
        string json = File.ReadAllText(savePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
       
        if (File.Exists(savePath))
        {
            targetYear = saveData.CurrentYear;
        }
        StartCoroutine(YearAnimation(targetYear, speed));
    }

    private void OnDisable()
    {
        loadingSceneDelegate -= PlayButton;
    }
    
    public void OpenScene()
    {
        SceneManager.LoadScene("Game");
    }
    private void PlayButton()
    {
        StartCoroutine(ButtonSmoothTransform());
    }
    private IEnumerator ButtonSmoothTransform()
    {
        float objectSpeed = 0;
        while (Vector3.Distance(NextButton.transform.position, targetPos) > 0.01)
        {
            objectSpeed += Time.deltaTime / 10f;
            NextButton.transform.position = Vector3.Lerp(NextButton.transform.position, targetPos, objectSpeed);
            yield return null;
        }
    }
    private IEnumerator YearAnimation(int targetYear, int speed)
    {
        float currentYear = 0;
        while (currentYear != targetYear) 
        {
            currentYear += speed;
            currentYear = Mathf.Clamp(currentYear, 0, targetYear);
            yearText.text = currentYear.ToString();
            yield return new WaitForSeconds(0.002f);
        }

        loadingSceneDelegate?.Invoke();

        while (yearDescription.alpha != 1)
        {
            yearDescription.alpha += 0.01f;
            yield return new WaitForSeconds(0.002f);
        }
    }
}
