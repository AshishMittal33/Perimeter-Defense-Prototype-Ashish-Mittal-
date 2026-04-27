using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 100f;
    Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 2f);
        }
    }
}