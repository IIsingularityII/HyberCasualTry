using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 _clickScreenPosition;
    private Vector3 _clickPlayerPosition;

    void Start()
    {
        
    }

    void Update()
    {
        MoveForward();
        ManageControl();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickScreenPosition = Input.mousePosition;
            _clickPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - _clickScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;
            Vector3 position = transform.position;
            position.x = _clickPlayerPosition.x + xScreenDifference;
            transform.position = position;
        }
    }
}
