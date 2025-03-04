using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    public class GraphProblems
    {
        public class Easy
        {
            public static List<List<int>> printGraph(int v, int[][] edges)
            {
                //Dictionary<int, List<int>> map = new();
                List<List<int>> map = new();
                for (int i = 0; i < v; i++)
                {
                    map.Add(new List<int>());
                }
                for (int i = 0; i < edges.Length; i++)
                {
                    int m = edges[i][0];
                    int n = edges[i][1];

                    map[m].Add(n);

                    map[n].Add(m);
                }
                return map;
            }

            public static List<int> BfsOfGraph(List<int>[] adj)
            {
                List<int> ans = new List<int>(adj.Length);
                Queue<int> que = new Queue<int>();
                bool[] vis = new bool[adj.Length];

                que.Enqueue(0);
                ans.Add(0);
                vis[0] = true;
                while (que.Count > 0)
                {
                    // int cnt = que.Count;
                    //for (int i = 0; i < cnt; i++)
                    //{
                    int num = que.Dequeue();
                    //if (!ans.Contains(num))
                    ans.Add(num);
                    for (int i = 0; i < adj[num].Count; i++)
                    {
                        int it = adj[num][i];
                        if (vis[it] == false)
                        {
                            vis[it] = true;
                            que.Enqueue(it);
                        }
                    }
                }
                return ans;
            }

            private static void BfsOfGraphHelper(List<int>[] adj, List<int> ans, int indx)
            {
                if (ans.Count == ans.Capacity) return;
                for (int k = indx; k < adj.Length; k++)
                {
                    //if (!ans.Contains(k))
                    //    ans.Add(k);
                    List<int> lst = adj[k];
                    for (int j = 0; j < lst.Count; j++)
                    {
                        int num = lst[j];
                        if (!ans.Contains(num))
                            ans.Add(num);
                    }
                    for (int j = 0; j < lst.Count; j++)
                    {
                        BfsOfGraphHelper(adj, ans, lst[j]);
                    }
                }
            }
        }
    }
}
