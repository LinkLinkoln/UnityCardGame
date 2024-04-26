using Unity.Mathematics;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    private Vector3 difference;
    private Vector2 screenBound;
    
    [SerializeField] private float rotationImpulse;
    [SerializeField] private CardText cardText;

    private SmoothAnimation smoothAnimation;
    private CardManager cardManager;

    private void Awake()
    {
        smoothAnimation = FindAnyObjectByType<SmoothAnimation>();
        cardManager = FindAnyObjectByType<CardManager>();
    }

    private void Start()
    {
        smoothAnimation.TransformDelegate += MoveToStart;
        screenBound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 1.3f, Screen.height / 1.3f));
    }

    private void OnDestroy()
    {
        smoothAnimation.TransformDelegate -= MoveToStart;
    }

    private void OnMouseUp()
    {
        if (transform.position.x > screenBound.x)
        {
            cardManager.UpdateGameValues(0);
            cardManager.UpdateCard(0);
            Debug.Log("right");
        }
        //agree
        else if (transform.position.x < -screenBound.x)
        {
            cardManager.UpdateGameValues(1);
            cardManager.UpdateCard(1);
            Debug.Log("left");
        }
        else
        {
            StartCoroutine(smoothAnimation.SmoothTransformRotationChange(0, 15, startPosition, Quaternion.identity, gameObject));
        }

    }

    //Запускается делегатом в SmoothAnimation после отжимания мыжи
    private void MoveToStart(GameObject target)
    {
        cardText.makeVisible();
    }

    private void OnMouseDown()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        cardText.makeVisible();
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - rotationImpulse * math.atan(transform.position.x));
        transform.position = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}
