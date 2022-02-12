package SearchAlgorithms;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

public class Graph {

	public LinkedList<String> adjList[];
	
	public void readUnweightedGraph(String filePath) throws FileNotFoundException {
		Scanner fileReader = new Scanner(new FileInputStream(filePath));
		int sizeOfArray = Integer.parseInt(fileReader.nextLine());
		String currentLine = fileReader.nextLine();
		//Container index is the parent node index
		int containerIndex = 0;
		String[] locations = currentLine.split(" ");
		adjList = new LinkedList[sizeOfArray];
		for(int i = 0; i < sizeOfArray; i++) {
			adjList[i] = new LinkedList<String>();
		}
		//add locations to the parent node
		adjList[containerIndex].add(locations[0]);
		adjList[containerIndex].add(locations[1]);
		while(fileReader.hasNext()) {
			currentLine = fileReader.nextLine();
			locations = currentLine.split(" ");
			//if container doesnt contain the current node, make a new container
			if(!adjList[containerIndex].get(0).equals(locations[0])) {
				adjList[++containerIndex].add(locations[0]);
			}
			//add child node to container
			adjList[containerIndex].add(locations[1]);
		}
		fileReader.close();
	}
}
