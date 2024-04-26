using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    [SerializeField] private Vector3 cardPosition;

    private CardManager cardManager;
    private SmoothAnimation smoothAnimation;
    
    private void Awake()
    {
        smoothAnimation = FindAnyObjectByType<SmoothAnimation>();
        cardManager = FindAnyObjectByType<CardManager>();
    }
    private void Start()
    {
        smoothAnimation.TransformDelegate += Flip;
        StartCoroutine(smoothAnimation.SmoothTransformRotationChange(speed, duration, cardPosition, Quaternion.identity, gameObject));
        transform.Cast<Transform>().ToList().ForEach(child => child.gameObject.SetActive(false));
    }
    private void OnDestroy()
    {
        smoothAnimation.TransformDelegate -= Flip;
    }

    private void Flip(GameObject target)
    {
        if (gameObject.transform.rotation.y >= -0.5f)
        {
            transform.Cast<Transform>().ToList().ForEach(child => child.gameObject.SetActive(true));
            gameObject.GetComponent<Image>().color = Color.white;
            cardManager.StartVisualize();
        }
    }

}
