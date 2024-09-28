using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    void Start ()
    {
        // subscribe
        Manager.Input.UserInput -= OnUserInput;
        Manager.Input.UserInput += OnUserInput;
    }

    void OnUserInput() {
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
    }
}
