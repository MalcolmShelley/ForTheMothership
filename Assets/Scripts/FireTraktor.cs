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
            beamRenderer.enabled = true;

            // remove abducted animals
            //foreach (Animal animal in abductionList)
            //{
               // if (animal == null)
                //{
                    //abductionList.Remove(animal);
                //}
            //}
            ShootTraktor();
        }
        else
        {
            beamRenderer.enabled = false;

            DropAnimals();
        }
    }

    void ShootTraktor()
    {
        RaycastHit2D[] _hits = Physics2D.BoxCastAll(firepoint.position, beamRenderer.bounds.size, 0f, Vector2.down, 100f, abductable);
        ArrayList missingAnimals = new ArrayList(abductionList);

        foreach (RaycastHit2D hit in _hits)
        {
            if (hit.collider.TryGetComponent(out Animal hitAnimal))
            {
                if (missingAnimals.Contains(hitAnimal))
                {
                    missingAnimals.Remove(hitAnimal);
                }
                else if (abductionList.Count < maxAnimals)
                {
                    hitAnimal.Abduct();
                    abductionList.Add(hitAnimal);
                }
            }
        }

        // remove all if no hit
        if (_hits.Length == 0)
        {
            DropAnimals();
        }

        // remove missing animals if not hit
        foreach (Animal animal in missingAnimals)
        {
            animal.Drop();
            abductionList.Remove(animal);
        }

    }

    void DropAnimals()
    {
        foreach (Animal animal in abductionList)
        {
            animal.Drop();
        }
        abductionList.Clear();
    }

}