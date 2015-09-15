using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{

    Vector3 originalCameraPosition;

    float shakeAmt = 0;
    [SerializeField]
    Camera mainCamera;


    void Start()
    {
        originalCameraPosition = mainCamera.transform.position;
    }


    public void screenShakeOnShoot()
    {

        shakeAmt = Random.Range(0.0f, 0.09f);
        InvokeRepeating("CameraShake", 0, 0.001f);
        Invoke("StopShaking", 0.3f);

    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt;
            pp.x += quakeAmt;
            pp.z = -10;
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

}