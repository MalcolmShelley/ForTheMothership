using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer gunSprite;
    public LineRenderer lineRenderer;
    public Transform firepoint;
    public Transform gun;
    public Quaternion gunRotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && gunSprite.enabled)
        {
            ShootLaser();
        }
        else
        {
            lineRenderer.enabled = false;
        }

        RotateToMouse();
    }

    void ShootLaser() {
        
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 gunDirection = mousePos - (Vector2)firepoint.position;
        RaycastHit2D _hit = Physics2D.Raycast(firepoint.position, gunDirection.normalized);
        
        if (_hit)
        {
            DrawBeam(firepoint.position, _hit.point);

            // deal damage if possible
            _hit.collider.TryGetComponent(out Enemy hitEnemy);
            if (hitEnemy)
            {
                hitEnemy.TakeDamage(GlobalManager.getLaserDamage());
            }
        }
        else
        {
            DrawBeam(firepoint.position, (Vector2)firepoint.position + mousePos * 50);
        }
    }

    void DrawBeam(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    void RotateToMouse()
    {
        Vector2 gunDirection = cam.ScreenToWorldPoint(Input.mousePosition) - gun.position;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        gunRotation.eulerAngles = new Vector3(0, 0, angle);
        gun.rotation = gunRotation;
    }
}
