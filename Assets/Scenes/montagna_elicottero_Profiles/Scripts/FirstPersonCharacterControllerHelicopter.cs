using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstPersonCharacterControllerHelicopter : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;


    private CharacterController _characterController;
    private float cameraXRotation = 0f;
    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _move;
    private Transform _parent;
    private float dist;
    public bool isLocked = false;
    private Color pointerColor;
    private Color visible = new Color(1, 1, 1, 1);
    private Color invisible = new Color(0, 0, 0, 0);
    private GameObject _firstAidKit;
    private GameObject _ferito;
    private GameObject _barella;
    private GameObject _helicopter;
    private int _grabFerito;
    private Vector3 _targetDirection;
    private Quaternion a;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        _move = false;
        _parent = transform.parent;
        _firstAidKit = GameObject.Find("first-aid-kit");
        _ferito = GameObject.Find("ferito");
        _barella = GameObject.Find("barella");
        _ferito.GetComponent<Grabbable>().grab=false;
        _barella.GetComponent<Grabbable>().grab = false;
        _grabFerito = 0;
        _helicopter = GameObject.Find("Helicopter");

    }


    void Update()
    {
        if (!isLocked)
        {
            UpdateCursor();


            if (Cursor.lockState == CursorLockMode.None)
                return;

            //Ground Check
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            if (_isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -2f;
            }

            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            //Compute direction According to Camera Orientation
            transform.Rotate(Vector3.up, mouseX);
            cameraXRotation -= mouseY;
            cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);
            _cameraT.localRotation = Quaternion.Euler(cameraXRotation, 0f, 0f);

            if (_move == false)
            {
                _parent = transform.parent;
                dist = Vector3.Distance(_parent.position, new Vector3(87.69f, 18.63f, 148.78f));
                if (dist <= 1.5f)
                {
                    _move = true;
                }
            }

            if (_move == true)
            {


                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                Vector3 move = (transform.right * h + transform.forward * v).normalized;
                _characterController.Move(move * _speed * Time.deltaTime);
            }

            //JUMPING
            if (Input.GetKey(KeyCode.Space) && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
            }

            //FALLING
            _velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
            if (transform.parent == null) {
                _barella.GetComponent<Grabbable>().grab = true;
            }
            if (_firstAidKit.GetComponent<LightUpInteractable>().GetCollect()) {
                if(_grabFerito!=2)
                    _ferito.GetComponent<LightUpInteractable>().SetInteract(true);
                if(_barella.transform.parent==_helicopter.transform)
                    _barella.transform.parent = null;
                if (1==1){//_ferito.GetComponent<LightUpInteractable>().GetInteract()) {
                    if (Vector3.Distance(_barella.transform.position, _ferito.transform.position) < 3f || _grabFerito>0 )
                    {
                        if (_grabFerito == 0)
                        {
                            _ferito.GetComponent<Grabbable>().grab = true;
                            _grabFerito = 1;

                        }
                        if (Vector3.Distance(_barella.transform.position, _ferito.transform.position) < 0.5f && _ferito.transform.IsChildOf(transform)==false) {
                            Destroy(_ferito.GetComponent<LightUpInteractable>());
                            Destroy(_ferito.GetComponent<PhysicsGrabbable>());
                            Destroy(_ferito.GetComponent<BoxCollider>());
                            Destroy(_ferito.GetComponent<Rigidbody>());
                            _ferito.transform.parent = _barella.transform;
                            _grabFerito = 2;
                            _ferito.transform.localPosition = new Vector3(0.1f, -0.2f, 0.1f);
                            //_ferito.transform.position=_barella.transform.position+ new Vector3(0.1f, -0.2f, 0.1f);
                        }
                        if (_ferito.transform.IsChildOf(transform) && _grabFerito!=2) {
                            _targetDirection = _barella.transform.forward.normalized;
                            Vector3 newDir = Vector3.RotateTowards(_ferito.transform.forward.normalized, _targetDirection, 1f * Time.deltaTime, 0f);
                            _ferito.transform.rotation = Quaternion.LookRotation(newDir);
                            //_ferito.transform.rotation= _barella.transform.rotation;
                        }
                        if (_barella.transform.IsChildOf(transform) && _grabFerito == 2) {
                            _targetDirection = _helicopter.transform.GetChild(4).transform.forward.normalized;
                            //_targetDirection.z = -(_targetDirection.z);
                            //_targetDirection.x = -(_targetDirection.x);
                            Vector3 newDir = Vector3.RotateTowards(_barella.transform.forward.normalized, _targetDirection, 1f * Time.deltaTime, 0f);
                            _barella.transform.rotation = Quaternion.LookRotation(newDir);
                            //Vector3 newDir = Vector3.RotateTowards(_barella.transform.forward, new Vector3(0,90,270).normalized, 0.5f * Time.deltaTime, 0f);
                            //_barella.transform.rotation. = Quaternion.LookRotation(newDir);
                            //_barella.transform.eulerAngles = new Vector3(0, 90, 270);
                        }
                    }
                }
            }
        }
    }

    private void UpdateCursor()
    {
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
            Cursor.lockState = CursorLockMode.Locked;

        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
    public bool GetLocked()
    {
        return isLocked;
    }

    public void SetLocked(bool newLock)
    {
        isLocked = newLock;
    }
    public void HidePointer()
    {
        pointerColor = invisible;
    }
    public void ShowPointer()
    {
        pointerColor = visible;
    }
}

