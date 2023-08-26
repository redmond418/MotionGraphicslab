using AnnulusGames.LucidTools.Inspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Redmonnd.MotionGraphicsLab
{
    [ExecuteInEditMode]
    public class LineMeshGenerator : MonoBehaviour
    {
        const int LINE_VERTEX_COUNT = 4;
        const int LINE_TRIANGLES_COUNT = 6;

        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private float thickness = 0.5f;
        [SerializeField] private List<Vector2> positions = new() { Vector2.zero, Vector2.right, Vector2.up };
        [SerializeField] private CornerMode cornerMode;
        [SerializeField, ShowIf("IsCornerDivision")] private int cornerDivisionCount;
        private List<Vector3> verticesPosition = new();
        private List<int> triangles = new();
        private Mesh mesh;

        private bool IsCornerDivision => cornerMode == CornerMode.Division;

        private int CornerVertexCount => cornerMode switch
        {
            CornerMode.None => 0,
            CornerMode.Intersection => 2,
            CornerMode.Division => cornerDivisionCount >= 1 ? cornerDivisionCount : 1,
            _ => 0,
        };

        private int CornerTrianglesCount => cornerMode switch
        {
            CornerMode.None => 0,
            CornerMode.Intersection => 6,
            CornerMode.Division => cornerDivisionCount >= 1 ? cornerDivisionCount * 3 : 3,
            _ => 0,
        };

        private void Start()
        {
            MeshInitialize();
        }

        private void MeshInitialize()
        {
            if (meshFilter is null) return;
            mesh = new Mesh();
            meshFilter.mesh = mesh;
        }

        private void Update()
        {
            if (mesh is null) MeshInitialize();
            if (positions.Count < 2) return;
            verticesPosition.Clear();
            triangles.Clear();
            for (int i = 0; i < positions.Count - 1; i++)
            {
                if (positions[i] == positions[i + 1]) continue;
                if(i > 0)
                {
                    for (int j = 0; j < CornerVertexCount; j++)
                    {
                        verticesPosition.Add(Vector3.zero);
                    }
                    for (int j = 0; j < CornerTrianglesCount; j++)
                    {
                        triangles.Add(0);
                    }
                }
                var rightNormal = (positions[i + 1] - positions[i]).normalized;
                rightNormal = new(rightNormal.y, -rightNormal.x);
                int vertexIndex = i * (LINE_VERTEX_COUNT + CornerVertexCount);
                //int triangleIndex = i * (LINE_TRIANGLES_COUNT + CornerTrianglesCount);
                verticesPosition.Add(positions[i] + rightNormal * thickness);
                verticesPosition.Add(positions[i + 1] + rightNormal * thickness);
                verticesPosition.Add(positions[i] - rightNormal * thickness);
                verticesPosition.Add(positions[i + 1] - rightNormal * thickness);
                triangles.Add(vertexIndex + 0);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 3);
                if (i > 0) switch (cornerMode)
                    {
                        case CornerMode.Intersection:
                            if (IsLeftCorner(i, vertexIndex))
                            {
                                GenerateCornerByIntersection(i, vertexIndex - CornerVertexCount - 1, vertexIndex + 2, positions[i],
                                    positions[i] - positions[i - 1], positions[i] - positions[i + 1]);
                            }
                            else
                            {
                                GenerateCornerByIntersection(i, vertexIndex, vertexIndex - CornerVertexCount - 3, positions[i],
                                    positions[i] - positions[i + 1], positions[i] - positions[i - 1]);
                            }
                            break;
                        case CornerMode.Division:
                            break;
                        case CornerMode.None:
                        default:
                            break;
                    }
            }
            mesh.SetVertices(verticesPosition);
            mesh.SetTriangles(triangles, 0);
        }

        private bool IsLeftCorner(int i, int vertexIndex) =>
            Vector3.Cross(positions[i] - positions[i - 1], verticesPosition[vertexIndex + 2] - verticesPosition[vertexIndex - CornerVertexCount - 1]).z *
                                Vector3.Cross(positions[i] - positions[i - 1], verticesPosition[vertexIndex + 3] - verticesPosition[vertexIndex - CornerVertexCount - 1]).z > 0;

        private void GenerateCornerByIntersection(int index, int vertexIndexL, int vertexIndexR, Vector2 center, Vector2 directionL, Vector2 directionR)
        {
            if(directionL == directionR || directionL == -directionR) return;
            Vector2 positionL = verticesPosition[vertexIndexL];
            Vector2 positionR = verticesPosition[vertexIndexR];
            int vertexIndex = (index - 1) * (LINE_VERTEX_COUNT + 2) + LINE_VERTEX_COUNT;
            int triangleIndex = (index - 1) * (LINE_TRIANGLES_COUNT + 6) + LINE_TRIANGLES_COUNT;
            /*float s = ((positionL.y - positionR.y) * directionR.x - (positionL.x - positionR.y) * directionR.y) / 
                (directionL.x * directionR.y - directionL.y * directionR.x);*/
            float x = (directionL.y * directionR.x * positionL.x - directionL.x * directionR.y * positionR.x - 
                directionL.x * directionR.x * (positionL.y - positionR.y)) / (directionL.y * directionR.x - directionL.x * directionR.y);
            float y = directionL.x != 0 ?
                (x - positionL.x) * directionL.y / directionL.x + positionL.y :
                (x - positionR.x) * directionR.y / directionR.x + positionR.y;
            verticesPosition[vertexIndex] = center;
            verticesPosition[vertexIndex + 1] = new(x, y);
            triangles[triangleIndex + 0] = vertexIndex;
            triangles[triangleIndex + 1] = vertexIndexL;
            triangles[triangleIndex + 2] = vertexIndex + 1;
            triangles[triangleIndex + 3] = vertexIndex;
            triangles[triangleIndex + 4] = vertexIndex + 1;
            triangles[triangleIndex + 5] = vertexIndexR;
        }
    }

    public enum CornerMode
    {
        None = 0,
        Intersection = 1,
        Division = 2,
    }
}
