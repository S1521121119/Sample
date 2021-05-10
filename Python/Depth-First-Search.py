def dfs(graph, start):
    ''' 深度優先搜尋法 '''
    visited = []                               # 拜訪過的頂點
    stack = [start]                         # 模擬堆疊
    while stack:        
        node = stack.pop()    
        if node not in visited:                # pop堆疊
            visited.append(node)               # 加入已拜訪行列
            neighbors = graph[node]         # 取得已拜訪節點的相鄰節點     
            neighbors.reverse()      
            for n in neighbors:             # 將相鄰節點放入佇列
                stack.append(n)
    return visited

graph = {'A':['B', 'C', 'D'],
         'B':['A', 'E'],
         'C':['A', 'F'],
         'D':['A', 'G', 'H'],
         'E':['B'],
         'F':['C', 'I', 'J'],
         'G':['D'],
         'H':['D'],
         'I':['F'],
         'J':['F']
        }         
print(dfs(graph,'A'))