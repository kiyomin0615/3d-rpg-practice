using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public Definition.CameraMode mode = Definition.CameraMode.QuaterView;
    [SerializeField]
    public Vector3 offset = new Vector3(0, 6, -5);
    [SerializeField]
    GameObject player = null;

    void Start()
    {
        
    }

    void LateUpdate() {
        if (mode == Definition.CameraMode.QuaterView) {
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform);
        }
    }

    public void SetQuaterView() {
        mode = Definition.CameraMode.QuaterView;
        offset = new Vector3(0, 6, -5);
    }
}
