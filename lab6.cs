using UnityEngine;
using UnityEngine.SceneManagement;
public class lab6 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]Transform goal;
    float attackDistance = 4;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distToPlayer > attackDistance)
        {
            goal.position = player.transform.position;
            agent.destination = goal.position;
            anim.Play("move");
        }
        else
        {
            agent.isStopped = true;
            anim.Play("atack");
            Invoke("Restart", 0.8f);
        }
    }
}