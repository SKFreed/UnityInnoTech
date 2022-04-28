using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestCoord : MonoBehaviour
{
    public Transform X0Y0;
    public Transform X1;
    public Transform Y1;

    public List<Point> Points = new List<Point>();

    public float XRange;
    public float YRange;

    public float XPoint;
    public float YPoint;

    private float progress;
    public float speed;

    [Range(0f, 1f)]
    private float tx; 
    [Range(0f, 1f)]
    private float ty;

    private Vector3 begin;
    private Vector3 end;

    private float xx;
    private float yy;
    private int i;


    private void Start()
    {
        xx = 100f / XRange / 100f;
        yy = 100f / YRange / 100f;

        tx = XPoint * xx;
        ty = YPoint * yy;
        i = 0;
        begin = X0Y0.position;
    }

    private void Update()
    {         
        Vector3 X = Coord.GetX(X0Y0.position, X1.position + (X1.position - X0Y0.position), tx);
        Vector3 Y = Coord.GetY(X0Y0.position, Y1.position + (Y1.position - X0Y0.position), ty);
        end = Coord.GetPoint(X, Y);

        transform.position = Vector3.MoveTowards(begin, end, progress);
        progress += speed/1000f;

       if (Vector3.Distance( transform.position, end)<0.02f)
        {
            Debug.Log("Достиг цели");
            begin = end;
            i++;
            progress = 0;
            if (i < Points.Count)
            {
                tx = Points[i].x * xx;
                ty = Points[i].y * yy;
            }            
        }              
    }
    private void OnDrawGizmos()
    {
        int sigmentsNumber = 2;
        for (int i = 0; i < sigmentsNumber; i++)
        {
            float parametr = (float)i / sigmentsNumber;
            Gizmos.DrawLine(X0Y0.position, X1.position);
            Gizmos.DrawLine(X0Y0.position, Y1.position);
        }
    }
}

