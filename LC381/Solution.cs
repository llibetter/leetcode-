using System.Collections.Generic;
using System;
using System.Linq;
/*
381. O(1) 时间插入、删除和获取随机元素 - 允许重复
设计一个支持在平均 时间复杂度 O(1) 下， 执行以下操作的数据结构。

注意: 允许出现重复元素。

insert(val)：向集合中插入元素 val。
remove(val)：当 val 存在时，从集合中移除一个 val。
getRandom：从现有集合中随机获取一个元素。每个元素被返回的概率应该与其在集合中的数量呈线性相关。
示例:

// 初始化一个空的集合。
RandomizedCollection collection = new RandomizedCollection();

// 向集合中插入 1 。返回 true 表示集合不包含 1 。
collection.insert(1);

// 向集合中插入另一个 1 。返回 false 表示集合包含 1 。集合现在包含 [1,1] 。
collection.insert(1);

// 向集合中插入 2 ，返回 true 。集合现在包含 [1,1,2] 。
collection.insert(2);

// getRandom 应当有 2/3 的概率返回 1 ，1/3 的概率返回 2 。
collection.getRandom();

// 从集合中删除 1 ，返回 true 。集合现在包含 [1,2] 。
collection.remove(1);

// getRandom 应有相同概率返回 1 和 2 。
collection.getRandom();
*/


/*
这题如果自己思考，是比较难想到的。但是看了答案的思路，会有豁然开朗的感觉，基本上理清思路后，编码是比较简单的。

下面说说思路：

1、利用List存储插入的数字集合，随机生成索引，即可O1返回随机数

2、此时插入、返回随机数都是O1, 还剩下删除不是，怎么办呢？

3、利用哈希表存储数字索引，删除时把待删除数字和末尾数字交换，直接删除末尾

4、删除时还需要注意一种特殊情况，待删除数字就是末尾数字，下面代码会有注释
*/
public class RandomizedCollection {
    private List<int> list;
    private Dictionary<int,HashSet<int>> dic;
    Random random;
    /** Initialize your data structure here. */
    public RandomizedCollection() {
        list=new List<int>();
        dic=new Dictionary<int,HashSet<int>>();
        random=new Random();
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {
        list.Add(val);
        if(dic.ContainsKey(val))
        {
            dic[val].Add(list.Count-1);
        }
        else
        {
            HashSet<int> hashSet=new HashSet<int>();
            hashSet.Add(list.Count-1);
            dic.Add(val,hashSet);
        }
        return dic[val].Count==1;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        if(!dic.ContainsKey(val)||dic[val].Count==0) return false;
        
        int index1=dic[val].First();
        int index2=list.Count-1;
        int value2=list[index2];
        
        list[index1]=value2;
        list.RemoveAt(list.Count-1);
        dic[val].Remove(index1);
        //考虑index1==index2的情况，需要先Add再Remove，其余情况顺序随意
        dic[value2].Add(index1);
        dic[value2].Remove(index2);
        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {
        return list[random.Next(0,list.Count)];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */