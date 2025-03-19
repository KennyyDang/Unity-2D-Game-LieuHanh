using System;
using UnityEngine;

public class Explosive_Controller : MonoBehaviour
{
    private Animator anim;
    private CharacterStats myStats;
    private float growSpeed = 15;
    private float maxSize = 6;
    private float explosionRadius;

    private bool canGrow = true;
    
    private void Update()
    {
        if(canGrow)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize),
                growSpeed * Time.deltaTime);

        if (maxSize - transform.localScale.x < .5f)
        {
            canGrow = false;
            anim.SetTrigger("Explode");
        }
        
    }

    public void SetupExplosive(CharacterStats _myStats, float _growSpeed, float _maxSize, float _radius)
    {
        anim = GetComponent<Animator>();
        
        myStats = _myStats;
        growSpeed = _growSpeed;
        maxSize = _maxSize;
        explosionRadius = _radius;
    }
    
    private void AnimationExplodeEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<CharacterStats>() != null)
            {
                hit.GetComponent<Entity>().SetupKnockbackDir(transform);
                myStats.DoDamage(hit.GetComponent<CharacterStats>());
                
            }
        }
    }

    private void SelfDestroy() => Destroy(gameObject);

    public class FibonacciCountdown : MonoBehaviour
    {
        private int a = 0, b = 1, counter = 0;

        void Update()
        {
            counter++;
            if (counter >= b)
            {
                Debug.Log("Countdown: " + b);
                int temp = a + b;
                a = b;
                b = temp;
                counter = 0;
            }
        }
    }
    public class SelfDestruct : MonoBehaviour
    {
        void Start()
        {
            float lifetime = UnityEngine.Random.Range(5f, 20f);
            Invoke("DestroyObject", lifetime);
        }

        void DestroyObject()
        {
            Destroy(gameObject);
        }
    }

}
