using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class DraggingController : MonoBehaviour,IDragHandler, IBeginDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    public static DraggingController Instance;

    [Space(2)]
    [Header("Rotation Config")]
    [SerializeField]
    private float rotationSpeed = 20f;
    [SerializeField]
    private Vector3 initalRotation =new Vector3(0, 150, 0);
    [SerializeField]
    private bool lockXRotation = false;
    [SerializeField]
    private bool lockYRotation = false;
    [SerializeField]
    private bool inverseXRotation = false;
    [SerializeField]
    private bool inverseYRotation = false;
    private Quaternion newRotation;
    [SerializeField]
    private float minRotationX = -90;
    [SerializeField]
    private float maxRotationX = 90;

    [Space(2)]
    [Header("Zoom Config")]
    [SerializeField]
    private bool enableZoom = false;
    [SerializeField]
    private float maxZoom = 2;
    [SerializeField]
    private float minZoom = -10;
    [SerializeField]
    private float zoom = 0;


    [Space(2)]
    [Header("Target Config")]
    [SerializeField]
    public Transform _zoomTarget;
    public Transform target;
    private Rigidbody rb;
    private bool hover = false;

    [Space(2)]
    [Header("Drag Config")]
    private float _dragX = 0;
    private float _dragY = 0;
    [SerializeField]
    private float _dragFactor = 40f;
    [SerializeField]
    private bool _useTorque = false;
    private Vector3 initialScale = Vector3.one;

    private void Awake()
    {
        
        Instance = this;
        if(_useTorque)
        {
            rb = target.GetComponent<Rigidbody>();
        }
        initialScale = _zoomTarget.localScale;
        
    }
    private void Update()
    {
        if(hover&& enableZoom)
        {
            zoom += Input.GetAxis("Mouse ScrollWheel");
            if(zoom <= minZoom)
            {
                zoom = minZoom;
            }
            else if(zoom >= maxZoom)
            {
                zoom = maxZoom;
            }
            if (Input.GetAxis("Mouse ScrollWheel")!=0)
            {
                _zoomTarget.localScale = initialScale + Vector3.one * zoom;
            }
        }
       
    }
    private void OnEnable()
    {

        newRotation = Quaternion.Euler(initalRotation);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    
    }
    public void OnDrag(PointerEventData eventData)
    {
       
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            print(eventData.pointerDrag.name);
            return;
        }
        if (target == null) return;
        _dragX += Input.GetAxis("Mouse X") * _dragFactor* (inverseXRotation?-1:1);
        _dragY += Input.GetAxis("Mouse Y") * _dragFactor* (inverseYRotation ?-1:1);
       
        if (_useTorque)
        {
            print($"DragValue:{_dragX}");
            rb.AddTorque(new Vector3(_dragY != 0 && !lockXRotation ? _dragY : 0, _dragX != 0 && !lockYRotation ?_dragX : 0, 0));
        }
        else
        {
            //Vector3 rotation = GetRotation(target);
            //print($"Quater:{Quaternion.Euler(target.eulerAngles)}");
            print($"Euler:{target.transform.localEulerAngles}");
            //print($"Rotation:{target.rotation}");
            if (Mathf.Abs(_dragY)> Mathf.Abs(_dragX))
            {
                
                target.Rotate(new Vector3(_dragY != 0 && !lockXRotation ? _dragY : 0, 0, 0), Space.Self);
                float x = Mathf.Clamp(target.eulerAngles.x, 0, maxRotationX);

              
               // target.eulerAngles=new Vector3(x , target.eulerAngles.y, target.eulerAngles.z);
            }
            else
            {
                target.Rotate(new Vector3(0, _dragX != 0 && !lockYRotation ? _dragX : 0, 0), Space.World);
            }
           
            // target.DORotate(new Vector3(_dragY != 0 ? _dragY : 0, _dragX != 0 ? -_dragX : 0, 0),.1f,RotateMode.Fast);
        }
       
        _dragX = 0;
        _dragY = 0;

    }

    private Vector3 GetRotation(Transform transform)
    {
        Vector3 vector3 = Vector3.zero;
        vector3.x = transform.localEulerAngles.x > 180 ? transform.localEulerAngles.x - 360 : transform.localEulerAngles.x;
        vector3.y = transform.localEulerAngles.y > 180 ? transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;
        vector3.z = transform.localEulerAngles.z > 180 ? transform.localEulerAngles.z - 360 : transform.localEulerAngles.z;
        return vector3;
    }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }
}
