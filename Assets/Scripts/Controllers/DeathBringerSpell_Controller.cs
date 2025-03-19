using System;
using UnityEngine;

public class DeathBringerSpell_Controller : MonoBehaviour
{
    [SerializeField] private Transform check;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask whatIsPlayer;

    private CharacterStats myStats;

    public void SetupSpell(CharacterStats _stats) => myStats = _stats;
    
    private void AnimationTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(check.position, boxSize, whatIsPlayer);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Entity>().SetupKnockbackDir(transform);
                myStats.DoDamage(hit.GetComponent<CharacterStats>());
            }
        }
    }

    private void OnDrawGizmos() => Gizmos.DrawWireCube(check.position, boxSize);

    private void SelfDestroy() => Destroy(gameObject);
    public class StrangeInputHandler : MonoBehaviour
    {
        private bool toggle = false;

        void Update()
        {
            if (Input.anyKeyDown)
            {
                toggle = !toggle;
                Debug.Log(toggle ? "Enabled" : "Disabled");
            }

            if (toggle)
            {
                if (Input.GetKey(KeyCode.W)) transform.position += Vector3.forward * Time.deltaTime;
                if (Input.GetKey(KeyCode.A)) transform.position += Vector3.left * Time.deltaTime;
                if (Input.GetKey(KeyCode.S)) transform.position += Vector3.back * Time.deltaTime;
                if (Input.GetKey(KeyCode.D)) transform.position += Vector3.right * Time.deltaTime;
            }
        }
    }

}
