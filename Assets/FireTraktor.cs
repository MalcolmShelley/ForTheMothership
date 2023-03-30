using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTraktor : MonoBehaviour
{
    public Transform firepoint;
    public SpriteRenderer gun;
    public SpriteRenderer beamRenderer;
    public int maxAnimals = 1;

    [SerializeField] private LayerMask abductable;
    private ArrayList abductionList = new ArrayList();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && gun.enabled)
        {
            ShootTraktor();
        }
        else
        {
            foreach (Animal animal in abductionList)
            {
                animal.Drop();
            }
            abductionList.Clear();
                
           beamRenderer.enabled = false;
        }
    }

    void ShootTraktor()
    {
        RaycastHit2D _hit = Physics2D.BoxCast(firepoint.position, beamRenderer.bounds.size,  0f, Vector2.down, 100f, abductable);
        beamRenderer.enabled = true;

        int numAnimals = 0;
        while (_hit && numAnimals < maxAnimals)
        {
            _hit.collider.TryGetComponent(out Animal hitAnimal);
            if (hitAnimal)
            {
                hitAnimal.Abduct();
                abductionList.Add(hitAnimal);
                numAnimals += 1;
                _hit = Physics2D.BoxCast(firepoint.position, beamRenderer.bounds.size, 0f, Vector2.down, 100f, abductable);
            }
        }
    }

}