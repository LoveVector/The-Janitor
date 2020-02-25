using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefineLerp
{
    public static void LerpTransform(this Transform thisObject, Transform thatObject, float t)
    {
        thisObject.position = Vector3.Lerp(thisObject.position, thatObject.position, t);
        thisObject.rotation = Quaternion.Lerp(thisObject.rotation, thatObject.rotation, t);
        thisObject.localScale = Vector3.Lerp(thisObject.localScale, thatObject.localScale, t);
    }
}
public class MainMenuCamera : MonoBehaviour
{
    public Transform[] cameraOptions;
    public float transitionSpeed;
    Transform currentView;
    [SerializeField]
    int viewIndex = 0;

    void Start()
    {
        currentView = cameraOptions[viewIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
             if(viewIndex > -1)
             {
                 currentView = cameraOptions[viewIndex--];
             }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(viewIndex < cameraOptions.Length + 1)
            {
                currentView = cameraOptions[viewIndex++];
            }

        }
    }

    void LateUpdate()
    {
        transform.LerpTransform(currentView.transform, Time.deltaTime);
    }

}
