using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    bool destIsSet = false;
    Vector3 destPosition;

    void Start ()
    {
        // subscribe
        Manager.Input.KeyAction -= OnKeyInput;
        Manager.Input.KeyAction += OnKeyInput;
        Manager.Input.MouseAction -= OnMouseInput;
        Manager.Input.MouseAction += OnMouseInput;
    }

    void Update ()
    {
        MoveToDest();
    }

    void OnKeyInput() {
        if (Input.GetKey(KeyCode.W)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        destIsSet = false;
    }

    void OnMouseInput(Definition.MouseEvent mouseEvent) {
        if (mouseEvent != Definition.MouseEvent.Click) {
            return;
        }

        RaycastHit hitInfo;
        int layerMask = LayerMask.GetMask("Wall");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f , Color.red, 1.0f);
        if (Physics.Raycast(ray, out hitInfo, 100.0f, layerMask)) {
            destPosition = hitInfo.point;
            destIsSet = true;
        }
    }

    void MoveToDest() {
        if (destIsSet) {
            Vector3 dir = destPosition - transform.position;
            if (dir.magnitude < 0.00001f) {
                destIsSet = false;
            }
            else {
                float moveDistance = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDistance;
                // transform.LookAt(destPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            }
        }
    }
}
