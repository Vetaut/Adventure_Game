using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {

    }

    private void Update()
    {

    }


    public void Move(Vector3 destination, float stoppingDist = 0)
    {
        if (m_agent.stoppingDistance != stoppingDist) m_agent.stoppingDistance = stoppingDist;
        m_agent.destination = destination;
    }

    /*
    [SerializeField] protected CharacterController controller;

    Vector3 m_velocity;

    [SerializeField] protected float m_speed = 6.0f;
    [SerializeField] protected float m_gravity = -9.81f;
    [SerializeField] protected float m_jumpHeight = 3.0f;

    [SerializeField] protected float m_turnSmoothTime = 0.1f;
    protected float m_turnSmoothVelocity;

    [SerializeField] protected Transform m_groundCheck;
    [SerializeField] protected float m_groundDistance;
    [SerializeField] protected LayerMask m_groundMask;
    protected bool m_isGrounded;
    protected bool m_jump;

    protected Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        if (m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }
    }

    protected void Move(Vector3 move, bool crouch, bool jump)
    {
        if (move.magnitude > 1f) move.Normalize();
        checkGroundStatus();
        MoveCharacter(move);

        if(m_isGrounded && m_jump)
        {
            Jump();
        }

        AddGravity();
        controller.Move(m_velocity * Time.deltaTime);

        UpdateAnimator(move);
    }

    protected virtual float findTargetAngle(Vector3 move)
    {
        return 0.0f;
    }

    private void MoveCharacter(Vector3 move)
    {
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = findTargetAngle(move); // Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_turnSmoothVelocity, m_turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * m_speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        m_isGrounded = false;
        m_animator.SetBool("OnGround", m_isGrounded);
        m_animator.SetTrigger("Jump");
        m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2 * m_gravity);
    }

    void AddGravity()
    {
        m_velocity.y += m_gravity * Time.deltaTime;
    }

    void checkGroundStatus()
    {
        m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);
    }

    void UpdateAnimator(Vector3 move)
    {
        if (m_animator) {
            m_animator.SetFloat("Running", move.magnitude);
            m_animator.SetBool("OnGround", m_isGrounded);
        }
    }
    */
}
