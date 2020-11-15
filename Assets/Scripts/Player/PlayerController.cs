using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //Inspector Variables
    [Header("Speed Settings : ")]
    [Range(1f, 10f)] [SerializeField] float speed;

    private float offsetSpeedBuff;

    [Header("Physics Settings : ")]
    [SerializeField] Rigidbody m_Rigidbody;

    //Privates variables
    private Vector3 movement;
    private Vector2 movementInput;
    private Vector2 inputDirection;

    //Controlers Actions
    public InputActionsManager controls;

    private void FixedUpdate()
    {
        //Input Move Player
        float h = movementInput.x;
        float v = movementInput.y;

        Vector3 targetInput = new Vector3(h, 0, v);
        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10.0f);

        Move(inputDirection);
       // TurnPlayer();

    }

    private void Move(Vector3 _dir)
    {
        movement.Set(_dir.x, 0.0f, _dir.z);
        movement = movement * (speed + offsetSpeedBuff) * Time.deltaTime;

        m_Rigidbody.MovePosition(transform.position + movement);
    }

    private void TurnPlayer()
    {
        Vector3 lookDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        Vector3 lookRot = Camera.main.transform.TransformDirection(lookDirection);
        lookRot = Vector3.ProjectOnPlane(lookRot, Vector3.up);


        if (lookRot != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookRot);
        }

    }


    public void OnMove(InputValue _inputVector)
    {
        movementInput = _inputVector.Get<Vector2>();
    }
}
