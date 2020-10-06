using System.Collections.Generic;
/*
给定一个无向、连通的树。树中有 N 个标记为 0...N-1 的节点以及 N-1 条边 。

第 i 条边连接节点 edges[i][0] 和 edges[i][1] 。

返回一个表示节点 i 与其他所有节点距离之和的列表 ans。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/sum-of-distances-in-tree
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。*/



/*

树形DP还是难的呀，鬼鬼

首先求一个树中节点总数，后序遍历即可，所以nodeSum能求出来
再次求子树中所有节点距离和，这个也简单，distSum[root]=distSum[item]+nodeSum[root]-1;

到这，我们求的distSums是子树中所有节点到根节点的距离和，题目所求是整个树所有节点，还需要加上非子树节点距离

distSum[i]=distSum[root]-nodeSum[i]+(N-nodeSum[i]);

这个递推关系式是这道题最巧妙的地方，非子树节点距离不需要求，直接加加减减一算就出来了，非常巧妙！
*/
public class Solution
{
    int[] distSum;
    int[] nodeSum;
    List<List<int>> Neighbor;
    public int[] SumOfDistancesInTree(int N, int[][] edges)
    {
        distSum = new int[N];
        nodeSum = new int[N];
        Neighbor = new List<List<int>>();
        for (int i = 0; i < N; i++)
            Neighbor.Add(new List<int>());
        foreach (var item in edges)
        {

            Neighbor[item[0]].Add(item[1]);
            Neighbor[item[1]].Add(item[0]);
        }
        PostOrder(0, -1);
        PreOrder(0, -1);
        return distSum;
    }

    public void PostOrder(int root, int parent)
    {
        List<int> l = Neighbor[root];
        foreach (var item in l)
        {
            if (item == parent) continue;
            PostOrder(item, root);
            nodeSum[root] += nodeSum[item];
            distSum[root] += distSum[item];
        }
        nodeSum[root] += 1;

        distSum[root] += nodeSum[root] - 1;
    }

    public void PreOrder(int root, int parent)
    {
        List<int> l = Neighbor[root];
        foreach (var item in l)
        {
            if (item == parent) continue;
            distSum[item] = distSum[root] - nodeSum[item] + distSum.Length - nodeSum[item];
            PreOrder(item, root);
        }
    }
}