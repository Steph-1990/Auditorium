using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEffector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _effector;
    [SerializeField] private GameObject _center;
    [SerializeField] private AreaEffector2D _areaEffector;
    [SerializeField] private Texture2D _cursorMove;
    [SerializeField] private Texture2D _cursorEnlarge;

    private Vector2 _hotSpot;
    private Vector2 _hotSpotCursorMove;
    private Vector2 _hotSpotCursorEnlarge;
    private RaycastHit2D _hit;
    private Ray _ray;
    private CursorMode cursorMode = CursorMode.Auto;
    private Transform _transform;
    private GameObject _effectorActiveMove;
    private GameObject _effectorActiveEnlarge;
    public CircleShape _circleShape;
    float _soustractionY;
    float _soustractionX;
    int _idEffector;

    private void Awake()
    {
        _transform = transform;
        _areaEffector = _effector.GetComponent<AreaEffector2D>();
    }

    private void Start()
    {
        _hotSpotCursorMove = new Vector2(_cursorMove.width / 2, _cursorMove.height / 2); //Par défault le pointeur de ces textures est situé tout en haut à gauche, donc on le replace au centre
        _hotSpotCursorEnlarge = new Vector2(_cursorEnlarge.width / 2, _cursorEnlarge.height / 2);
    }

    void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        _hit = Physics2D.GetRayIntersection(_ray, Mathf.Infinity);  

        DetectClickMouse();
        EffectorMove();
        EffectorEnlarge();
        CursorChange();      
    }

    private void CursorChange()
    {
        if (_hit.collider != null)
        {
            if (_hit.collider.CompareTag("SmallCircle"))
            {
                if (_effectorActiveEnlarge != null)
                {
                    Cursor.SetCursor(_cursorEnlarge, _hotSpotCursorEnlarge, cursorMode); // LE hotspot c'est l'endroit ou le clique est effectif
                }
                else
                {
                    Cursor.SetCursor(_cursorMove, _hotSpotCursorMove, cursorMode);
                }
            }
            else if (_hit.collider.CompareTag("BigCircle"))
            {
                Cursor.SetCursor(_cursorEnlarge, _hotSpotCursorEnlarge, cursorMode);
            }
        }
        else
        {
            if (_effectorActiveEnlarge != null)
            {
                Cursor.SetCursor(_cursorEnlarge, _hotSpotCursorEnlarge, cursorMode);
            }
            else
            {
                Cursor.SetCursor(default, _hotSpot, cursorMode);
            }
        }
    }

    private void DetectClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_hit.collider != null)
            {

                _idEffector = _hit.collider.gameObject.GetInstanceID();

                if (_hit.collider.CompareTag("SmallCircle") && _idEffector == _center.GetInstanceID())
                {
                    _effectorActiveMove = _effector;
                }
                else if (_hit.collider.CompareTag("BigCircle"))
                {
                    _effectorActiveEnlarge = _effector;
                    _soustractionY = _ray.origin.y;
                    _soustractionX = _ray.origin.x;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _effectorActiveMove = null;
            _effectorActiveEnlarge = null;
        }
    }

    private void EffectorMove()
    {
        if (_effectorActiveMove != null)
        {
            _effectorActiveMove.transform.position = (Vector2)_ray.origin;
        }
    }

    private void EffectorEnlarge()
    {
        if (_effectorActiveEnlarge != null)
        {

            float distance = Vector2.Distance(_effectorActiveEnlarge.transform.position, _ray.origin);

            if (distance > 2.5 && distance < 5f)
            {
                _circleShape.Radius = distance;

                _areaEffector.forceMagnitude = (distance / 0.025f) - (2.5f / 0.025f);
            }
        }
    }
}


















/*if (_circleShape.Radius <= 4.95)
                {
                    _circleShape.Radius += 0.05f;
                    float calcul = 100f / 59;
                    _areaEffector.forceMagnitude += calcul;
                }

                else if (_circleShape.Radius >= 2.05)
                {
                    _circleShape.Radius -= 0.05f;
                    float calcul = 100f / 59;
                    _areaEffector.forceMagnitude -= calcul;
                }*/



//Debug.Log("Augmentation Rayon");

/* if (soustractionX < ray.origin.x || soustractionY < ray.origin.y)
 {
     soustractionX = ray.origin.x;
     soustractionY = ray.origin.y;

     if (_circleShape.Radius <= 4.95)
     {
         _circleShape.Radius += 0.05f;
         float calcul = 100f / 59;
         _areaEffector.forceMagnitude += calcul;
     }
     //Debug.Log("Augmentation Rayon");
 }
 else if (soustractionX > ray.origin.x || soustractionY > ray.origin.y)
 {
     soustractionX = ray.origin.x;
     soustractionY = ray.origin.y;

     if (_circleShape.Radius > 2.05)
     {
         _circleShape.Radius -= 0.05f;
         float calcul = 100f / 59;
         _areaEffector.forceMagnitude -= calcul;
     }
     //Debug.Log("Diminution Rayon");
 }*/