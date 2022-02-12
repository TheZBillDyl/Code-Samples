package SearchAlgorithms;

import java.util.LinkedList;
import java.util.Stack;

public class DFS extends Graph {

	public DFS(String filePath) throws Exception {
		readUnweightedGraph(filePath);
	}
	
	public String RunDFS(String goal) {
		long timeOfDFS = System.currentTimeMillis();
		Stack<String> stack =  new Stack<String>();
		stack.push(adjList[0].get(0));
		String pathString = "";
		LinkedList<String> visited = new LinkedList<String>();
		
		while(!stack.isEmpty()) {
			String s = stack.pop();
			if(visited.contains(s))
				continue;
			visited.add(s);
			if(s.equals(goal)) {
				System.out.println("DFS Time elapsed: " + (System.currentTimeMillis() - timeOfDFS) + "ms");
				return pathString + goal;
			}
			pathString += s + ", ";
			int index = IndexOfString(s);
			if(index > -1) {
				for(int i = 1; i < adjList[index].size(); i++) {
					stack.push(adjList[index].get(i));
				}
			}
		}
		//Only runs if it failed to find the goal
		System.out.println("DFS Time elapsed: " + (System.currentTimeMillis() - timeOfDFS) + "ms");
		return pathString;
	}
	
	//Retrieves the container index of given string
	int IndexOfString(String target) {
		for(int i = 0; i < adjList.length; i++) {
			if(adjList[i].contains(target) && adjList[i].get(0).equals(target)) {
				return i;
			}
		}
		return -1;
	}
}
