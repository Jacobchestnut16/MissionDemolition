using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileLine : MonoBehaviour
{
    static List<ProjectileLine> projectileLines = new List<ProjectileLine>();
    private const float         DIM_MULT        = 0.75f;
    
    private LineRenderer    _line;
    private Projectile      _projectile;
    private bool            _drawing = true;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 1;
        _line.SetPosition(0, transform.position);
        
        _projectile = GetComponentInParent<Projectile>();

        ADD_LINE(this);
    }

    private void OnDestroy()
    {
        projectileLines.Remove(this);
    }

    static void ADD_LINE(ProjectileLine line)
    {
        Color color;

        foreach (ProjectileLine l in projectileLines)
        {
            color = l._line.startColor;
            color = color * DIM_MULT;
            l._line.startColor = color;
        }
        
        projectileLines.Add(line);
    }

    void FixedUpdate()
    {
        if (_drawing)
        {
            _line.positionCount += 1;
            _line.SetPosition(_line.positionCount - 1, transform.position);

            if (_projectile != null)
            {
                if (!_projectile.awake)
                {
                    _drawing = false;
                    _projectile = null;
                }
            }
        }
    }
}
