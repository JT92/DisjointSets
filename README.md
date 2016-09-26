# DisjointSets
A basic implementation of Disjoint Sets using union by rank and path compresssion Graph Algorithm written in C#.
Note: this is **not** production quality code. Just an excercise in CS Algorithms.

###Description###
**Disjoint-set data structure**, also called a *union–find data structure* or *merge–find set*, is a data structure that keeps track of a set of elements partitioned into a number of disjoint (nonoverlapping) subsets.
The code contains a small example which creates 7 disjoint sets, joins them, and prints them using the find function.
When the find function is invoked, the path compression algorithm is applied.
Path Compression takes chains of nodes which lead to the root, and makes all the individual nodes point to the root.

Great tutorial on Disjoint Sets (in c++): [youtube video](https://www.youtube.com/watch?v=ID00PMy0-vE)

###Use Cases###
* **Kruskals Algorithm** uses disjoint sets
* Also used for finding cycle in an undirected graph
* Union by rank and path compression is most popular implementation


###Complexity###
Space Complexity: **O(n)**
The space complexity is pretty straight forward - if there are n elements the space used will be O(n).

Time Complexity: **O(m)**
For m operations and n elements, the time complexity will be:
O(mα(n)) 
α(n) <= 4 
O(mα(n)) ≃ O(4m)
         = O(m)
         
         
