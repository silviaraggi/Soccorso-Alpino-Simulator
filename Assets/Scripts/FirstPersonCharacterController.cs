using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    private Color pointerColor;
    private Color visible = new Color(1, 1, 1, 1);
    private Color invisible = new Color(0, 0, 0, 0);
    private CharacterController _characterController;
    private float cameraXRotation = 0f;
    private Vector3 _velocity;
    private bool _isGrounded;
    public bool isLocked = false;
    private GameObject Light;
    private InventoryUI inventoryui;
    void Start()
    {
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
        if (transform.Find("Spot Light"))
            Light = transform.Find("Spot Light").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
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
            if(Light!=null)
            Light.GetComponent<Transform>().localRotation = _cameraT.localRotation;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = (transform.right * h + transform.forward * v).normalized;
            _characterController.Move(move * _speed * Time.deltaTime);
            //JUMPING
            if (Input.GetKey(KeyCode.Space) && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
            }

            //FALLING
            _velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
    private void UpdateCursor()
    {
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1) )
            Cursor.lockState = CursorLockMode.Locked;
        
        if (Cursor.lockState == CursorLockMode.Locked && (Input.GetKeyDown(KeyCode.Escape)))
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

    private void PlayFootStepAudio()
    {
        if (!_characterController.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        if(!m_AudioSource.isPlaying)
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}
