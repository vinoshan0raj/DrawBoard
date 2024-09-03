using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    GameObject trail;
    Plane planeObject;
    Vector3 startPosition;

    void Start()
    {
        planeObject = new Plane(Camera.main.transform.forward * -1 , this.transform.position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (planeObject.Raycast(mouseRay, out distance))
            {
                startPosition = mouseRay.GetPoint(distance);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (planeObject.Raycast(mouseRay, out distance))
            {
                trail.transform.position = mouseRay.GetPoint(distance);
            }
        }
    }
}
