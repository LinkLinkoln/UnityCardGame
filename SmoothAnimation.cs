using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public delegate void FillChangedDelegate(float currentFill, Image target );
public delegate void TransformChangeDelegate(GameObject target);
public class SmoothAnimation : MonoBehaviour
{
    public FillChangedDelegate FillChanged;
    public TransformChangeDelegate TransformDelegate;

    //Енуменатор для плавного заполнения объекта
    public IEnumerator SmoothFillChange(float speed, float duration, float currentFill, float targetFill, Color targetColor, Image target)
    {
        target.color = targetColor;
        while (Math.Abs((currentFill - targetFill)) > 0.001f)
        {
            speed += Time.deltaTime / duration;
            currentFill = Mathf.Lerp(currentFill, targetFill, speed);;
            target.color = Color.Lerp(target.color, Color.white, speed);
            FillChanged?.Invoke(currentFill, target);
            yield return null;
        }
    }
    //Енуменатор для плавного движения и поворота объекта
    public IEnumerator SmoothTransformRotationChange(float speed, float duration, Vector3 startPos, Quaternion startRot,  GameObject target)
    {
        target.GetComponent<Collider2D>().enabled = false;
        while (Vector3.Distance(target.transform.position, startPos) > 0.01 || Quaternion.Angle(target.transform.rotation, startRot) > 0.1)
        {
            speed += Time.deltaTime / duration;
            target.transform.position = Vector3.Lerp(target.transform.position, startPos, speed);
            target.transform.rotation = Quaternion.Lerp(target.transform.rotation, startRot, speed);
            TransformDelegate?.Invoke(target);
            yield return null;
        }
        target.GetComponent<Collider2D>().enabled = true;
    }
}
