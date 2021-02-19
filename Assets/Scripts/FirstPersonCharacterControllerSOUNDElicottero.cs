using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class FirstPersonCharacterControllerSOUNDElicottero : MonoBehaviour
{
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private float m_RunSpeed;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    [SerializeField] public MouseLookModificato m_MouseLook;
    [SerializeField] private bool m_UseFovKick;
    [SerializeField] private FOVKick m_FovKick = new FOVKick();
    [SerializeField] private bool m_UseHeadBob;
    [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
    [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.


    private Camera m_Camera;
    private bool m_Jump;
    private float m_YRotation;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_Jumping;
    private AudioSource m_AudioSource;
    public bool isLocked = false;
    private GameObject Light;
    private Color pointerColor;
    private Color visible = new Color(1, 1, 1, 1);
    private Color invisible = new Color(0, 0, 0, 0);
    public bool canJump;
    private GameObject _firstAidKit;
    private GameObject _ferito;
    private GameObject _barella;
    private Transform _helicopter;
    private int _grabFerito;
    private Vector3 _targetDirection;
    private Quaternion _direction;
    public bool _soccorso;
    public bool _dialogo;
    private bool _kitPreso = false;
    [SerializeField] GameObject inventory;
    private Inventory _inventario;
    [SerializeField] private GameObject _NPC;
    private bool _move;
    private Transform _parent;
    private float dist;
    private CharacterController _characterController;
    // Use this for initialization
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (m_Camera.enabled == true)
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_FovKick.Setup(m_Camera);
        m_HeadBob.Setup(m_Camera, m_StepInterval);
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
        m_Jumping = false;
        m_AudioSource = GetComponent<AudioSource>();
        m_MouseLook.Init(transform, m_Camera.transform);
        if (transform.Find("Spot Light"))
            Light = transform.Find("Spot Light").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        isLocked = true;

        _move = false;
        _parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        _firstAidKit = GameObject.Find("first-aid-kit");
        _ferito = GameObject.Find("ferito");
        _barella = GameObject.Find("barella");
        _ferito.GetComponent<Grabbable>().grab = false;
        _barella.GetComponent<Grabbable>().grab = false;
        _grabFerito = 0;
        _helicopter = GameObject.Find("Helicopter").transform.GetChild(1);
        _soccorso = false;
        _dialogo = false;
        //_ferito.GetComponent<LightUpInteractableHelicopter>().SetInteract(true);
        _inventario = inventory.GetComponent<InventoryUI>().GetInventory();
    }


    // Update is called once per frame
    private void Update()
    {
        _inventario = inventory.GetComponent<InventoryUI>().GetInventory();
        if (!isLocked)
        {

            UpdateCursor();
            if (Cursor.lockState == CursorLockMode.None)
                return;
            RotateView();
            Debug.Log("ok");
            // the jump state needs to read here to make sure it is not missed
            if (!m_Jump && canJump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
            {
                StartCoroutine(m_JumpBob.DoBobCycle());
                PlayLandingSound();
                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = m_CharacterController.isGrounded;
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
                //_characterController.Move(move * m_RunSpeed * Time.deltaTime);
            }
            if (transform.parent == null)
            {
                _barella.GetComponent<Grabbable>().grab = true;
            }
            if (_dialogo == false && _ferito.GetComponent<Interactable>().GetInteract() == true)
            {
                _dialogo = true;
                //_ferito.GetComponent<LightUpInteractableHelicopter>().SetInteract(false);
            }
            if (_firstAidKit.GetComponent<LightUpInteractableHelicopter>().GetCollect())
            {
                if (_kitPreso == false)
                {
                    _inventario.Add(_firstAidKit.GetComponent<LightUpInteractableHelicopter>().bende);
                    _inventario.Add(_firstAidKit.GetComponent<LightUpInteractableHelicopter>().fissaggi);
                    _inventario.Add(_firstAidKit.GetComponent<LightUpInteractableHelicopter>().stecca);
                    _kitPreso = true;
                    _NPC.GetComponent<DialogueTriggerHelicopter>().dialogue = GameObject.Find("DialogoColleghi3");
                }
                if (_soccorso == false && _dialogo == true && _ferito.GetComponent<Interactable>().GetInteract() == true)
                {


                    if (_ferito.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().enabled == true)
                    {
                        _ferito.transform.GetChild(4).GetComponent<SkinnedMeshRenderer>().enabled = false;
                        _ferito.GetComponent<Interactable>().SetInteract(false);
                    }
                    //_ferito.GetComponent<LightUpInteractable>().GetInteract();
                    //Cambio ferito
                }
                if (_soccorso == false && _dialogo == true)
                {
                    if (_ferito.transform.GetChild(2).GetComponent<SkinnedMeshRenderer>().enabled == true)
                    {
                        _ferito.GetComponent<Animator>().SetBool("soccorso", true);
                        _soccorso = true;
                        //_ferito.GetComponent<Interactable>().SetInteract(false);
                    }
                }
                if (_barella.transform.parent == _helicopter.transform)
                    _barella.transform.parent = null;
                if (_soccorso == true)
                {
                    if (Vector3.Distance(_barella.transform.position, _ferito.transform.position) < 3f || _grabFerito > 0)
                    {
                        if (_grabFerito == 0 && _soccorso == true)
                        {
                            _ferito.GetComponent<Grabbable>().grab = true;
                            _grabFerito = 1;

                        }
                        if (_grabFerito == 1 && Vector3.Distance(_barella.transform.position, (_ferito.transform.position + new Vector3(0f, 1f, 0f))) < 1f && _ferito.transform.IsChildOf(transform) == false)
                        {
                            if (_ferito.GetComponent<Interactable>() != null)
                                _ferito.GetComponent<Interactable>().TurnOff();
                            //_ferito.GetComponent<LightUpInteractable>().enabled = false;
                            Destroy(_ferito.GetComponent<Interactable>());
                            //_ferito.GetComponent<PhysicsGrabbable>().grab = false;
                            Destroy(_ferito.GetComponent<PhysicsGrabbable>());
                            //Destroy(_ferito.GetComponent<BoxCollider>());
                            Component[] colliders = _ferito.GetComponents<BoxCollider>() as Component[];
                            foreach (Component collider in colliders)
                                Destroy(collider as BoxCollider);
                            Destroy(_ferito.GetComponent<Rigidbody>());
                            _ferito.transform.parent = _barella.transform;
                            _grabFerito = 2;
                            _ferito.transform.localPosition = new Vector3(1.24f, -0.3f, 0f);
                            _ferito.transform.localEulerAngles = new Vector3(90f, -80f, 10f);
                            _targetDirection = _barella.transform.eulerAngles;
                            _direction = Quaternion.Euler(_barella.transform.eulerAngles);
                            _helicopter.transform.GetComponent<BoxCollider>().enabled = true;
                            _NPC.GetComponent<DialogueTriggerHelicopter>().dialogue = GameObject.Find("DialogoColleghi4");
                            //_ferito.transform.position=_barella.transform.position+ new Vector3(0.1f, -0.2f, 0.1f);
                        }
                        if (_ferito.transform.IsChildOf(transform) && _grabFerito == 1)
                        {
                            Quaternion b = Quaternion.Euler(_barella.transform.eulerAngles - new Vector3(0, 90, -90));
                            Quaternion a = _ferito.transform.rotation;
                            a = Quaternion.Lerp(a, b, Time.deltaTime * 1f);
                            _ferito.transform.rotation = a;
                            /*_targetDirection = _barella.transform.forward.normalized;
                            Vector3 newDir = Vector3.RotateTowards(_ferito.transform.forward.normalized, _targetDirection, 1f * Time.deltaTime, 0f);
                            _ferito.transform.rotation = Quaternion.LookRotation(newDir);*/
                            //_ferito.transform.rotation= _barella.transform.rotation;
                        }
                        if (_barella.transform.IsChildOf(transform) && _grabFerito == 2)
                        {
                            _direction = Quaternion.Euler(_barella.transform.eulerAngles);
                            Quaternion finalDirection = Quaternion.Euler(new Vector3(0, 90, 270));
                            _direction = Quaternion.Lerp(_direction, finalDirection, Time.deltaTime * 1f);
                            _barella.transform.rotation = _direction;
                            //_targetDirection = _helicopter.transform.forward.normalized;
                            //_targetDirection.x = _targetDirection.x - 0.5f;
                            //_targetDirection.y = 0.5f;
                            //_targetDirection = new Vector3(1f, 0f, 0f).normalized;
                            //_targetDirection.z = -(_targetDirection.z);
                            //_targetDirection.x = -(_targetDirection.x);
                            //Vector3 newDir = Vector3.RotateTowards(_barella.transform.forward.normalized, _targetDirection, 1f * Time.deltaTime, 0f);
                            //_barella.transform.rotation = Quaternion.LookRotation(newDir);
                            //Vector3 newDir = Vector3.RotateTowards(_barella.transform.forward, new Vector3(0,90,270).normalized, 0.5f * Time.deltaTime, 0f);
                            //_barella.transform.rotation. = Quaternion.LookRotation(newDir);
                            //_targetDirection = Vector3.Lerp(_targetDirection, new Vector3(0, 90, 270), Time.deltaTime * 0.5f);
                            //_barella.transform.eulerAngles = _targetDirection;
                        }
                    }
                }
            }
            else
            {
                _ferito.GetComponent<LightUpInteractableHelicopter>().SetInteract(false);
            }
        }
    }

    private void UpdateCursor()
    {
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            m_MouseLook.SetCursorLock(true);
        }

        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            m_MouseLook.SetCursorLock(false);
        }
    }

    private void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
    }


    private void FixedUpdate()
    {
        if (!isLocked)
        {
            float speed;
            if (Cursor.lockState == CursorLockMode.None)
                return;
            GetInput(out speed);
            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                               m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = desiredMove.x * speed;
            m_MoveDir.z = desiredMove.z * speed;


            if (m_CharacterController.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;
                    PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                }
            }
            else
            {
                m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
            }
            m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

            ProgressStepCycle(speed);
            UpdateCameraPosition(speed);

            m_MouseLook.UpdateCursorLock();
        }
    }


    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }


    private void ProgressStepCycle(float speed)
    {
        if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
        {
            m_StepCycle += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
                         Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!m_CharacterController.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }


    private void UpdateCameraPosition(float speed)
    {
        Vector3 newCameraPosition;
        if (!m_UseHeadBob)
        {
            return;
        }
        if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
        {
            m_Camera.transform.localPosition =
                m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                  (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
            newCameraPosition = m_Camera.transform.localPosition;
            newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
        }
        else
        {
            newCameraPosition = m_Camera.transform.localPosition;
            newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
        }
        m_Camera.transform.localPosition = newCameraPosition;
    }


    private void GetInput(out float speed)
    {
        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
        // On standalone builds, walk/run speed is modified by a key press.
        // keep track of whether or not the character is walking or running
        m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
        // set the desired speed to be walking or running
        speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
        m_Input = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        // handle speed change to give an fov kick
        // only if the player is going to a run, is running and the fovkick is to be used
        if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
        {
            StopAllCoroutines();
            StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
        }
    }


    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (m_CollisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
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
    public bool GetIsWalking()
    {
        return m_IsWalking;
    }
    public float GetWalkSpeed()
    {
        return m_WalkSpeed;
    }
    public float GetRunSpeed()
    {
        return m_RunSpeed;
    }
}
