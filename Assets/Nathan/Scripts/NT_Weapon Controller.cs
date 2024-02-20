using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NT_WeaponController : MonoBehaviour
{
    //public LineRenderer lineRenderer;
    public Transform playerTransform;
    public float attackAngleThreshold;
    public float attackCooldown = .5f;
    private float lastAttackTime;
    public GameObject LeftAttack;
    public GameObject RightAttack;
    void Start()
    {
        //circleRenderer = GetComponent<LineRenderer>();
        //DrawCircle(60, 5f);
    }

    void Update()
    {
        //UpdateLineRendererPositions(90);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - playerTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            angle = (angle + 360) % 360;
            if (angle > 180) angle -= 360;

            //determining attack direction based on angle
            if (angle > -45 && angle <= 45)
            {
                //attack right
                print("attack right");
                Attack("Right");
            }
            else if (angle > 45 && angle <= 135)
            {
                //attack up
                Debug.Log("Attacking up");
            }
            else if (angle > -135 && angle <= -45)
            {
                //attack down
                Debug.Log("Attacking Down");
            }
            else if ((angle > 135 && angle <= 180) || (angle >= -180 && angle <= -135))
            {
                //attack Left
                print("attack left");
                Attack("Left");
            }
        }
    }

    //attack function
    void Attack (string direction)
    {
        if(direction == "Left")
        {
            LeftAttack.SetActive(true);
        }
        if (direction == "Right")
        {
            RightAttack.SetActive(true);
        }

        lastAttackTime = Time.time;
    }

    //line renderer stuff for super wip this shit blows
    /*void DrawCircleLine(LineRenderer lineRenderer)
    {
        int segments = 100;
        float radius = 5f;

        float angleIncrement = 360f / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleIncrement;
            Vector3 position = playerTransform.position + Quaternion.Euler(0, 0, angle) * Vector3.right * radius;
            lineRenderer.SetPosition(i, position);
        }
    }

    void SetLineRendererPositions(LineRenderer lineRenderer, float rotationOffset, int indexOffset)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = playerTransform.position;
        positions[1] = playerTransform.position + Quaternion.Euler(0, 0, rotationOffset) * Vector3.right;

        lineRenderer.SetPositions(positions);
    }

    void UpdateLineRendererPositions(float angle)
    {
        // Set Line Renderer positions based on the attack direction
        lineRenderer.positionCount = 8; // Set the position count only once

        SetLineRendererPositions(lineRenderer, 45f, 0); // Right line
        SetLineRendererPositions(lineRenderer, 135f, 2); // Up line
        SetLineRendererPositions(lineRenderer, 225f, 4); // Left line
        SetLineRendererPositions(lineRenderer, 315f, 6); // Down line

        // Draw circle line
        DrawCircleLine(lineRenderer);
    }*/
}
