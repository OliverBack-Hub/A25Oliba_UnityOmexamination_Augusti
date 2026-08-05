using UnityEngine;

public class FloorIsLava : MonoBehaviour
{

    private Rigidbody2D rb;

    public int damage = 1;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    }       
}