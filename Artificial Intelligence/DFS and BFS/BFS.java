package SearchAlgorithms;

import java.util.LinkedList;
import java.util.Queue;

public class BFS extends Graph {

	public BFS(String filePath) throws Exception {
		readUnweightedGraph(filePath);
	}
	
	public String RunBFS(String goal) {
		long timeOfBFS = System.currentTimeMillis();
		Queue<String> queue =  new LinkedList<String>();
		queue.add(adjList[0].get(0));
		String pathString = "";
		LinkedList<String> visited = new LinkedList<String>();
		
		while(!queue.isEmpty()) {
			String s = queue.poll();
			if(visited.contains(s))
				continue;
			visited.add(s);
			if(s.equals(goal)) {
				System.out.println("BFS Time elapsed: " + (System.currentTimeMillis() - timeOfBFS) + "ms");
				return pathString + goal;
			}
			pathString += s + ", ";
			int index = IndexOfString(s);
			if(index > -1) {
				for(int i = 1; i < adjList[index].size(); i++) {
					queue.add(adjList[index].get(i));
				}
			}
		}
		//Only runs if it failed to find the goal.
		System.out.println("BFS Time elapsed: " + (System.currentTimeMillis() - timeOfBFS) + "ms");
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
