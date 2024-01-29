using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
  public void RotatePlayer(LayerMask ground)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit impact;
        if (Physics.Raycast(ray, out impact, 100, ground))
        {
            Vector3 positionShooter = impact.point - transform.position;
            positionShooter.y = transform.position.y;
            CalculateRotation(positionShooter);
        }
    }
}
