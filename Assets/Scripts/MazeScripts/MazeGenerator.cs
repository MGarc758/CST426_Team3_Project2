using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mazeGameObject;
    
    [SerializeField] private GameObject maze;
    
    [SerializeField] private MazeCell _mazeCellPrefab;

    [SerializeField] private int _mazeWidth;

    [SerializeField] private int _mazeDepth;

    private MazeCell[,] _mazeGrid;
    
    private float _speed = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

        for (int i = 0; i < _mazeWidth; i++)
        {
            for (int j = 0; j < _mazeDepth; j++)
            {
                _mazeGrid[i, j] = Instantiate(_mazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity,mazeGameObject.transform.parent);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);
        
        maze.transform.Translate(200,0,0);
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);
        

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetNextUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetNextUnvisitedCells(MazeCell currentCell)
    {
        int i = (int)currentCell.transform.position.x;
        int j = (int)currentCell.transform.position.z;

        if (i + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[i + 1, j];

            if (cellToRight.IsVistied == false)
            {
                yield return cellToRight;
            }
        }
        
        if (i - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[i - 1, j];

            if (cellToLeft.IsVistied == false)
            {
                yield return cellToLeft;
            }
        }

        if (j + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[i, j + 1];

            if (cellToFront.IsVistied == false)
            {
                yield return cellToFront;
            }
        }
        
        if (j - 1 >= 0)
        {
            var cellToBack = _mazeGrid[i, j - 1];

            if (cellToBack.IsVistied == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        
        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }
}
