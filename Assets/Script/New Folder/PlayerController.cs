using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private float interactRange = 3f;

    [Header("Movement")]
    public float moveSpeed;
    float h, v;
    public float mouseSpeed;
    float yRotation, xRotation;
    Camera cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = Camera.main;
    }

    void Update()
    {
        Move();
        Rotate();
        Interact();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = transform.forward * v + transform.right * h;

        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checker")
        {
            if (GameManager.Instance.currentStep == GameManager.Step.Corridor)
            {
                GameManager.Instance.currentStep = GameManager.Step.Teleport;
                GameManager.Instance.CloseDoor();
                Invoke("PlayerTeleport", 1.5f);
                if (GameManager.Instance.isSuccess) GameManager.Instance.GenerateNextCommand();
                else; // When Failed
            }
        }

        if (other.gameObject.tag == "room")
        {
            if (GameManager.Instance.currentStep == GameManager.Step.Room)
            {
                GameManager.Instance.CloseDoor();
            }
        }
    }

    public void PlayerTeleport()
    {
        if (transform.position.x > 6)
        {
            transform.Translate(-18, 0, 0, Space.World);
        }
        else if (transform.position.x < -6)
        {
            transform.Translate(18, 0, 0, Space.World);
        }
        else if (transform.position.z < -8)
        {
            transform.Translate(0, 0, 22, Space.World);
        }
        else if (transform.position.z > 8)
        {
            transform.Translate(0, 0, -22, Space.World);
        }

        Debug.Log("Teleport!");
    }
}
