using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followspead;
    public float lenght;

    private Vector3 defaultposition;
    private Transform target;

    public bool hasTarget { get { return target != null; } }

    private void Start()
    {
        defaultposition = transform.position;
        target = null;
    }

    private void Update()
    {
        if (hasTarget)
        {
            Vector3 targetTocameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetTocameraDirection * lenght);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followspead * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTranform, float targetLength)
    {
        target = targetTranform;
        lenght = targetLength;
    }

   

    public void GobackToDefault()
    {

        target = null;

        //gerakan ke posisi default
        StartCoroutine(MovePosisition(defaultposition, returnTime));
    }
    private IEnumerator MovePosisition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
