using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : CharacterMovement
{
    public Transform cam;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_jump)
        {
            m_jump = Input.GetButtonDown("Jump");
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Move(direction, m_jump, false);
        m_jump = false;
    }

    protected override float findTargetAngle(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    }
}
