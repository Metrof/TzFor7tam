using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCreator : MonoBehaviour
{
    [SerializeField] private GameObject stonePref;

    private Vector2 startPos;
    const float xIndent = 1.55f;
    const float xBias = 0.2f;
    const float yIndent = 1.8f;

    private Vector3[,] indentsPos;
    private Transform _anchor;

    private void Start()
    {
        startPos = new Vector2(-5.4f, 2.25f);
        indentsPos = new Vector3[4, 8];

        ArrangementObs();
    }
    void ArrangementObs()
    {
        if (GameObject.Find("_ObsAnchor") == null)
        {
            GameObject anchorObs = new GameObject("_ObsAnchor");
            _anchor = anchorObs.transform;
        }

        for (int i = 0; i < indentsPos.GetLength(0); i++)
        {
            for (int j = 0; j < indentsPos.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    indentsPos[i, j] = new Vector3(startPos.x, startPos.y, 0);
                } else
                {
                    indentsPos[i, j] = new Vector3(indentsPos[0, 0].x + xIndent * j - xBias * i, indentsPos[0, 0].y - yIndent * i, 0);
                }
            }
        }

        for (int i = 0; i < indentsPos.GetLength(0); i++)
        {
            for (int j = 0; j < indentsPos.GetLength(1); j++)
            {
                Instantiate(stonePref, indentsPos[i, j], Quaternion.identity, _anchor);
            }
        }
    }
}
