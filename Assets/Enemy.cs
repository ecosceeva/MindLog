
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public AudioClip deathclip;
    public Transform target;
    private NavMeshAgent agent;
    private Rigidbody[] rbs; 

    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        target = FindFirstObjectByType<XROrigin>().Camera.transform;
        DisactivateRagdoll();
    }

    
    void Update()
    {
        agent.SetDestination(target.position);

        if (Vector3.Distance(target.position, transform.position) < 1.5f)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Death()
    {
        ActivateRagdoll();
        agent.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(deathclip);
        Destroy(this);
    }

    void ActivateRagdoll()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = false;
        }
    }

    void DisactivateRagdoll()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }
    }

}
