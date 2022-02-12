public class BinarySearchApplications {

	public static int minIndexBinarySearch(int array[], int arrayLength, int key) { // complete this method
		
		//returns the minimum index
		int left = 0;
		int right = arrayLength-1;
		int minIndex = -1;
		
		while(left <= right) {
			
			int mid = (left + right) /  2;
			//System.out.println(mid + " : Left is: " + left + " : Right is: " + right );
			if(array[mid] == key) {
				//System.out.println("found lesser index.");
				minIndex = mid;
				right = mid - 1;
				continue;
			}else if(array[mid] > key) {
				right = mid -1;
			}else {
				left = mid + 1;
			}
		}
		
		return minIndex;
		
		
	}

	public static int maxIndexBinarySearch(int array[], int arrayLength, int key) { // complete this method
		
		//returns the Maximum index
				int left = 0;
				int right = arrayLength-1;
				int maxIndex = -1;
				
				while(left <= right) {
					
					int mid = (left + right) /  2;
					//System.out.println(mid);
					if(array[mid] == key) {
						maxIndex = mid;
						left = mid + 1;
						continue;
					}else if(array[mid] > key) {
						right = mid -1;
					}else {
						left = mid + 1;
					}
				}
				
				return maxIndex;
				
	}

	public static int countNumberOfKeys(int array[], int arrayLength, int key) { // complete this method
		
		//System.out.println("Starting search...");
		int minNumber = minIndexBinarySearch(array, arrayLength, key);
		//System.out.println("Starting search 2...");
		int maxNumber = maxIndexBinarySearch(array, arrayLength, key);
		
		if(minNumber == -1 || maxNumber == -1) {
			return 0;
		}else {
			return maxNumber - minNumber + 1;
		}
		
		
	}

	public static int predecessor(int array[], int arrayLen, int key) { // complete this method
		//returns the the predecessor index
		int left = 0;
		int right = arrayLen-1;
		int preIndex = -1;
		
		while(left <= right) {
			
			int mid = (left + right) /  2;
			//System.out.println(mid);
			if(array[mid] == key) {
				preIndex = mid;
				left = mid + 1;
				continue;
			}else if(array[mid] > key) {
				right = mid -1;
			}else {
				preIndex = mid;
				left = mid + 1;
			}
		}
		
		return preIndex;
		
	}
}
