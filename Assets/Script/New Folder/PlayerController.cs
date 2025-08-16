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
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();    //hit한 콜라이더 들고 와서
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
                GameManager.Instance.GenerateNextCommand();
                if (GameManager.Instance.isSuccess) ; // When Success
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
        Vector3 div = Vector3.zero, temp = Vector3.zero;

        if (transform.position.x > 6)
        {
            temp = transform.position - new Vector3(9, 0.85f, 2.5f);
            div = new Vector3(-temp.z, 0, temp.x);
            yRotation -= 90;
        }
        else if (transform.position.x < -6)
        {
            temp = transform.position - new Vector3(-9, 0.85f, 2.5f);
            div = new Vector3(temp.z, 0, -temp.x);
            yRotation += 90;
        }
        else if (transform.position.z < -8)
        {
            temp = transform.position - new Vector3(0, 0.85f, -11);
            div = new Vector3(-temp.x, 0, -temp.z);
            yRotation += 180;
        }
        else if (transform.position.z > 8)
        {
            div = transform.position - new Vector3(0, 0.85f, 11);
        }
        transform.position = new Vector3(0, 0.85f, -11) + div;

        Debug.Log("Teleport!");
    }
}
