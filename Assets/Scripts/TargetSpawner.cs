using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public float timer;
    public GameObject target;
    public Vector3 RandomPos;
    // Start is called before the first frame update
    void Start()
    {
        if(Cannon.Round == 0)
        {
            timer = 3f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UI.Count > 1 || Cannon.Lost)
        {
            return;
        }
        if(Cannon.score >= Cannon.MinScore)
        {
            return;
        }
        if(timer <= 0)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
            RandomPos = new Vector3(0f, Random.Range(-5f, 5f), Random.Range(-10f, 10f));
            foreach (var target in targets)
            {
                if(Vector3.Distance(target.transform.position, transform.position + RandomPos) <= 1.5f )
                {
                    return;
                }
            }

            if(targets.Length >= 10)
            {
                return;
            }
            
            GameObject _target = Instantiate(target, transform.position + RandomPos, Quaternion.Euler(0, 0, -90f));
            _target.transform.parent = transform;
            timer = 3f / Cannon.Round;
        }
        timer -= Time.deltaTime;
    }
}
