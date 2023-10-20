using UnityEditor;
using UnityEngine;

public class MovingTargetArea : MonoBehaviour
{
    public Vector3 endPoint = new Vector3(-47.21f, 2.97f, -4.2f);
    public Vector3 startPoint = new Vector3(-22.26406f, 2.97f, -4.2f);
    public float speed;
    private int num;
    Vector3 RandomPos;
    Vector3 dir;

    private void Start()
    {
        RandomPos = transform.position;
        dir = Vector3.zero;
        transform.position = startPoint;
    }
    // Update is called once per frame
    void Update()
    {
        speed = (Cannon.Round - 4f) / 2;
        if (Cannon.Round >= 5 && Cannon.Round <= 8)
        { 
            Debug.Log(speed);
            
            if (Vector3.Distance(transform.position, startPoint) <= 0.2f)
            {
                num = 1;
            }
            else
            {
                if(Vector3.Distance(transform.position, endPoint) <= 0.2f)
                {
                    num = 0;
                }
            }

            MoveToEnd();
            MoveToStart();
        }
        else
        {
            if(Cannon.Round > 8)
            {
                MoveRandomly();
            }
        }
    }

    void MoveToEnd()
    {
        if(num == 1)
        {
            Vector3 dir = endPoint - transform.position;
            transform.Translate(dir * speed * Time.deltaTime);
        }       
    }

    void MoveToStart()
    {
        if(num == 0)
        {
            Vector3 dir = startPoint - transform.position;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        
    }

    void MoveRandomly()
    {
       
        if (Vector3.Distance(transform.position, RandomPos) <= 0.3f)
        {
            RandomPos = new Vector3(Random.Range(-47.21f, -22.26406f), 2.97f, -4.2f);
            dir = RandomPos - transform.position;
        }       
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
