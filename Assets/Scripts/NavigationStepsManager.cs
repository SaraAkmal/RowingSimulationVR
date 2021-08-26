using UnityEngine;

public class NavigationStepsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private bool[] pointsStates;
    private int index;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;

            if (index == 4)
            {
                if (GetCollisionStates())
                    print("true");
                else
                    print("false");
                index = 0;
            }
        }
    }

    private bool GetCollisionStates()
    {
        for (var i = 0; i < 4; i++)
            if (!pointsStates[i])
                return false;
        return true;
    }

    private enum states
    {
        Point_1,
        Point_2,
        Point_3,
        Point_4
    }
}