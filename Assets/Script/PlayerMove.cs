using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 8f;
    public float mouseX;
    public float mouseY;
    public Camera PlayerCam;

    private bool isPhoneUp;
    private float grav;
    private CharacterController ctrl;
    private Vector3 mov;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        mov = Vector3.zero;
        grav = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) isPhoneUp = isPhoneUp ? false : true;

        if (isPhoneUp) rotSpeed = 0;
        else rotSpeed = 8f;

        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (ctrl.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mov = ctrl.transform.TransformDirection(mov);
        }
        else mov.y -= grav * Time.deltaTime;

        ctrl.Move(mov * Time.deltaTime * moveSpeed);

        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseY = Mathf.Clamp(mouseY, -70, 70);
        PlayerCam.transform.localEulerAngles = new Vector3(mouseY, 0, 0);
    }
}
