using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlopLegiments : MonoBehaviour
{

    [SerializeField] private LineRenderer line;

    [SerializeField] private List<Transform> points;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = points.Count;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }


    private void OnDrawGizmos()
    {
        line.positionCount = points.Count;
        DrawLine();
    }

    private void DrawLine()
    {
        line.SetPositions(points.Select(p => p.position).ToArray());
    }
}
