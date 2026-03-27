using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private const float InteractRange = 3f;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float baseMouseSpeed = 2f;

    private float yRotation, xRotation;
    private Camera cam;
    private CharacterController ctrl;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = Camera.main;
        ctrl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        bool phoneUp = UIControl.Instance != null && UIControl.Instance.isPhoneUp;

        if (!phoneUp)
        {
            Move();
            Interact();

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                float sense = UIControl.Instance != null ? UIControl.Instance.curSense : 1f;
                yRotation += Input.GetAxisRaw("Mouse X") * baseMouseSpeed * sense;
                xRotation = Mathf.Clamp(xRotation - Input.GetAxisRaw("Mouse Y") * baseMouseSpeed * sense, -80f, 80f);
            }
        }
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        if (UIControl.Instance != null)
            cam.fieldOfView = UIControl.Instance.curFov;
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveVec = (transform.forward * v + transform.right * h).normalized;
        ctrl.Move(moveVec * moveSpeed * Time.deltaTime);
    }

    private void Interact()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        Ray ray = new(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, InteractRange))
            hit.collider.GetComponent<IInteractable>()?.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checker"))
        {
            if (GameManager.Instance.currentStep == GameManager.Step.Corridor)
            {
                GameManager.Instance.currentStep = GameManager.Step.Teleport;
                GameManager.Instance.CloseDoor();
                StartCoroutine(TeleportAfterDelay(1.5f));
                GameManager.Instance.GenerateNextCommand();
            }
        }

        if (other.CompareTag("room"))
        {
            if (GameManager.Instance.currentStep == GameManager.Step.Room)
                GameManager.Instance.CloseDoor();
        }
    }

    private IEnumerator TeleportAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerTeleport();
    }

    private void PlayerTeleport()
    {
        Vector3 div = Vector3.zero, temp;

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

        ctrl.enabled = false;
        transform.position = new Vector3(0, 0.85f, -11) + div;
        ctrl.enabled = true;
    }
}
