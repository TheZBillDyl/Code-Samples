package SearchAlgorithms;

public class homework1 {

	public static void main(String[] args) throws Exception {
		// TODO Auto-generated method stub
		
		//Make the graph for bfs
		BFS bfs = new BFS("map.txt");
		System.out.println("BFS: " + bfs.RunBFS("USA"));
		
		//Make the graph for dfs
		DFS dfs = new DFS("map.txt");
		System.out.println("DFS: " + dfs.RunDFS("USA"));
		
		
	}

}
