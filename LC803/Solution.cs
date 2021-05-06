using System;
public class Solution
{
    int[,] dir = new int[4, 2] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
    int rows;
    int cols;
    public int[] HitBricks(int[][] grid, int[][] hits)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        int len = hits.Length;
        int[] res = new int[len];

        int[][] copy = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            copy[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                copy[i][j] = grid[i][j];
            }
        }
        foreach (var item in hits)
        {
            copy[item[0]][item[1]] = 0;
        }

        int total = rows * cols;
        UnionFind uf = new UnionFind(total + 1);
        for (int j = 0; j < cols; j++)
        {
            if (copy[0][j] == 1)
                uf.Union(j, total);
        }
        for (int i = 1; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                if (copy[i][j] == 0) continue;
                if (copy[i - 1][j] == 1)
                    uf.Union((i - 1) * cols + j, i * cols + j);
                // else if (j > 0 && copy[i][j - 1] == 1)
                if (j > 0 && copy[i][j - 1] == 1)
                    uf.Union(i * cols + j - 1, i * cols + j);
            }

        for (int i = len - 1; i >= 0; i--)
        {
            int origin = uf.GetSize(total);
            int x = hits[i][0];
            int y = hits[i][1];
            if (grid[x][y] == 0) continue;
            for (int index = 0; index < 4; index++)
            {
                int a = x + dir[index, 0];
                int b = y + dir[index, 1];
                if (a >= 0 && a < rows && b >= 0 && b < cols && copy[a][b] == 1)
                {
                    uf.Union(a * cols + b, x * cols + y);
                }
            }
            if (x == 0) uf.Union(y, total);
            int cur = uf.GetSize(total);
            res[i] = Math.Max(0, cur - origin - 1);
            copy[x][y] = 1;
        }
        return res;
    }
}

public class UnionFind
{
    int[] parent;
    int[] size;
    int count;

    public UnionFind(int n)
    {
        count = n;
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public void Union(int x, int y)
    {
        int rootx = Find(x);
        int rooty = Find(y);
        if (rootx == rooty) return;
        // if (size[rooty] < size[rootx])
        // {
        //     parent[rooty] = rootx;
        //     size[rootx] += size[rooty];
        // }
        // else
        {
            parent[rootx] = rooty;
            size[rooty] += size[rootx];
        }
        count--;
    }

    public int Find(int x)
    {
        if (x == parent[x]) return x;
        parent[x] = Find(parent[x]);
        return parent[x];
    }

    public int GetCount()
    {
        return count;
    }

    public bool IsConnect(int x, int y)
    {
        return Find(x) == Find(y);
    }

    public int GetSize(int i)
    {
        //此处返回整个连通集的size
        //return size[i];
        return size[Find(i)];
    }
}