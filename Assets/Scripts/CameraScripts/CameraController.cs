using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedefTransform;

    [SerializeField]
    float minY, maxY;
    

    

    

    private void Update()
    {
        transform.position = new Vector3(hedefTransform.position.x,
            Mathf.Clamp(hedefTransform.position.y, minY, maxY),
            transform.position.z);
    }


    



}
