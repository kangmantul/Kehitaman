using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    private void Update()
    {
        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }
}
