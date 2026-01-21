using UnityEngine;

public class Limb : MonoBehaviour
{
    public bool fatal = false;
    public void Hit()
    {
       // Limb childlimb = transform.GetChild(0).GetComponentInChildren<Limb>();
       // if (childlimb)
       //     childlimb.Hit();
       // This is for when I will later on create additional limb 3d models, so the ragdolls body parts don't just 
       // disappear on the monsters but will be visibly dropped to the ground

        transform.localScale = Vector3.zero;

       // GameObject spawnedLimb = Instantiate(limbPrefab, transform.parent);
       // spawnedLimb.transform.parent = null;
       // Destroy(spawnedLimb, 10);

        if (fatal)
            GetComponentInParent<Enemy>().Death();

        Destroy(this); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
            Hit();
    }
}
