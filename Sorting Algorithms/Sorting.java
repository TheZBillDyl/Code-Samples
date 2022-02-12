public class Sorting {

	public static void selectionSort(int[] array, int arrayLen) { // complete this method
		
		
		
		for(int i = 0; i < arrayLen; i++) {
			int minIndex = i;
			for(int j = i; j < arrayLen; j++) {
				if(array[j] < array[minIndex]) {
					//found a smaller number
					minIndex = j;
				}
			}
			
			
			if(i != minIndex) {
				//Swap
				int save = array[i];
				array[i] = array[minIndex];
				array[minIndex] = save;
			}
			
		}
		
	}

	public static void insertionSort(int[] array, int arrayLen) { // complete this method
		
		for(int i = 1; i < arrayLen; i++) {
			int j = i;
			int temp = array[j];
			while(j > 0 && temp < array[j-1]) {
				array[j] = array[j-1];
				j--;
				array[j] = temp;
			}
		}
		
	}
}
