using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;
    public int maxNumStars;
    float size = 0.2f;

    Color[] starColors =
    {
        new Color(1f, 0, 0),
        new Color(0.5f, 0.5f, 1f),
        new Color(1f, 1f, 0f),
        new Color(0f, 1f, 1f)
    };

    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for(int i = 0;i < maxNumStars; i++)
        {
            GameObject star = Instantiate(Star);

            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            star.transform.position = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            star.transform.localScale = new Vector2(size, size);

            star.transform.parent = transform;
        }
    }

    
    void Update()
    {
        
    }
}
