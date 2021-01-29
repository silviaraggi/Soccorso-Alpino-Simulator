using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private Image _target;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;
    private Interactable _pointedInteractable=null;
    private Grabbable _pointedGrabbable = null;
    private GameObject changeColor = null;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        //if(_grabbedObject == null)
            CheckInteraction();

        /*if (_grabbedObject != null && Input.GetMouseButtonDown(0))
            Drop();*/


        UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            if (_grabbedObject != null && Input.GetMouseButtonDown(0)) { 
                Drop();
                return; 
            }
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            changeColor = hit.transform.gameObject;
            if (_pointingInteractable == null && hit.transform.parent != null)
            {
                (GameObject item1, GameObject changeColor) = FindParentInteractable(hit.transform.gameObject, hit.transform.gameObject);
                if (item1 != null && changeColor != null)
                {
                    _pointingInteractable = item1.transform.GetComponent<Interactable>();
                }
            }
            
            if (_pointingInteractable != _pointedInteractable && _pointedInteractable!= null)
            {
                _pointedInteractable.TurnOff();
            }
            if (_pointingInteractable && (_pointingInteractable.GetAnimatable()||_pointingInteractable.GetCollectable()))
            {
                _pointedInteractable = _pointingInteractable;
                _pointingInteractable.GlowUp(changeColor);
                if(Input.GetMouseButtonDown(0))
                    _pointingInteractable.Interact(gameObject);
            }
            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();

            if (_grabbedObject == null)
            {
                if (_pointingGrabbable)
                {
                    if (_pointedGrabbable != _pointingGrabbable && _pointedGrabbable != null)
                    {
                        _pointedGrabbable.TurnOff();
                    }
                    _pointedGrabbable = _pointingGrabbable;
                    _pointingGrabbable.LightUp(gameObject);
                    if (Input.GetMouseButtonDown(0))
                    {
                        _pointingGrabbable.TurnOff();
                        _pointingGrabbable.Grab(gameObject);
                        Grab(_pointingGrabbable);
                    }
                }
                else
                {
                    if (_pointedGrabbable!=null)
                    {
                        _pointedGrabbable.TurnOff();
                    }
                }
                    
            }

        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
            _pointingGrabbable = null;
        }
    }


    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _target.color = Color.green;
        else if (_pointingGrabbable)
            _target.color = Color.yellow;
        else
            _target.color = Color.red;
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

        _target.enabled = true;
        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);

        _target.enabled = false;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
    public static (GameObject, GameObject) FindParentInteractable(GameObject childObject, GameObject changeColor)
    {
        if (childObject == null)
            return (null, changeColor);
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.GetComponent<Interactable>() == true)
            {
                return (t.parent.gameObject, changeColor);
            }
            t = t.parent.transform;
        }
            return (null,changeColor); 
    }

    public Color GetPointerColor()
    {
        return _target.color;
    }

    public void SetPointerColor(Color colore)
    {
        _target.color = colore;
    }
}