using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int Speed;
    public Vector3 RandomPos;
    public Vector3 dir;

    private void Start()
    { 
        RandomPos = transform.localPosition;
        dir = RandomPos - transform.localPosition;

        if (Cannon.Round <= 8)
        {
            for (int i = 1; i <= 4; i++)
            {
                if ((Cannon.Round + 4 - i) % 4 == 0)
                {
                    Speed = 2 * (i - 1);
                    return;
                }
            }
        }
        else
        {
            Speed = 2 * (Cannon.Round - 9);
        }
    }
    private void Update()
    {   
        targetMove();
        destroyIt();       
    }

    void targetMove()
    {
        if(Vector3.Distance(transform.localPosition, RandomPos) <= 0.5f)
        {
            RandomPos = new Vector3(0, Random.Range(-6, 6), Random.Range(-15, 15));
            dir = RandomPos - transform.localPosition;
        }
        else
        {
            transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
        }        
    }

    void destroyIt()
    {
        if(Vector3.Distance(transform.localPosition, RandomPos) > 30f)
        {
            Destroy(this.gameObject);
        }
    }
}
