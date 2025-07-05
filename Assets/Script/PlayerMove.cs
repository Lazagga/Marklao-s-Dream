
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using TMPro;
using System.Collections;
using UnityEngine.Rendering.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 8f;
    public float mouseX;
    public float mouseY;

    public Camera PlayerCam;

    public float Sense;
    public float Fov;

    private bool isPhoneUp;
    private CharacterController ctrl;
    private Vector3 mov;

    public float armlength = 3f;

    private RaycastHit hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        mov = Vector3.zero;
        Sense = 1f;
        Fov = 60f;
        rotSpeed = 8* Sense;
    }

    // Update is called once per frame
    void Update()
    {
        isPhoneUp = UIControl.Instance.isPhoneUp;
        Sense = UIControl.Instance.curSense;
        Fov = UIControl.Instance.curFov;

        if (isPhoneUp) rotSpeed = 0;
        else rotSpeed = 8 * Sense;

        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mov = ctrl.transform.TransformDirection(mov);
        ctrl.Move(mov * Time.deltaTime * moveSpeed);

        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseY = Mathf.Clamp(mouseY, -70, 70);
        PlayerCam.transform.localEulerAngles = new Vector3(mouseY, 0, 0);

        PlayerCam.fieldOfView = Fov;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(PlayerCam.transform.position, transform.forward, out hit, armlength))
            {
                if(hit.transform.tag == "transive")
                {
                    StartCoroutine(OtherDoorOpen(hit));
                }
                if(hit.transform.tag == "door")
                {
                    StartCoroutine(DoorOpen(hit));
                }
            }
        }
    }

    IEnumerator DoorOpen(RaycastHit door)
    {
        door.transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        door.transform.gameObject.SetActive(true);
    }

    IEnumerator OtherDoorOpen(RaycastHit door)
    {
        ctrl.enabled = false;
        door.transform.GetChild(0).gameObject.SetActive(false);
        if (transform.position.z > 8) transform.Translate(0, 0, -21, Space.World);
        else if (transform.position.z < -8) transform.Translate(0, 0, +21, Space.World);
        else if (transform.position.x > 6) transform.Translate(-19, 0, 0, Space.World);
        else if (transform.position.x < -6) transform.Translate(19, 0, 0, Space.World);
        ctrl.enabled = true;
        yield return new WaitForSeconds(2.0f);
        door.transform.GetChild(0).gameObject.SetActive(true);
        
    }
}
