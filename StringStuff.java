package test;

public class StringStuff {
	
	public static boolean isPalindrome(String str) {
		
		for(int i = 0; i < str.length(); i++) {
			if(str.charAt(i) != str.charAt(str.length() - 1 - i))
				return false;
		}
		return true;
	}
	
	public static String longestPalindromeWithin(String str) {
		
		String longestPalindrome = "";
		for(int i = 0; i < str.length(); i++) {
			for(int j = i; j < str.length()+1; j++) {
				if(isPalindrome(str.substring(i, j)) && str.substring(i, j).length() > longestPalindrome.length())
					longestPalindrome = str.substring(i, j);
			}
		}
		return longestPalindrome;
	}
	
	public static boolean containsAllDigits(String str) {
		boolean[] numChecked = new boolean[10];
		for(int i =0; i < str.length(); i++) {
			if(str.charAt(i) > 47 && str.charAt(i) < 59) {
				int num = str.charAt(i);
				numChecked[num-48] = true;
			}
		}
		for(int i = 0; i < 10; i++)
		{
			if(numChecked[i] == false) {
				return false;
			}
				
		}
		return true;
	}
	
	public static String replaceAll(String text, String key, String replace) {
		String str = "";
		for(int i = 0; i < text.length(); i++){
			String sub = "";
			if(i+key.length() <= text.length()){
				 sub = text.substring(i, i+key.length());
			}
			if(sub.equals(key)){
				str += replace;
				i += key.length()-1;
			}
			else
				str += text.charAt(i);
		}
		return str;
	}
	
	public static String runLengthEncode(String str) {
		String rle = "";
		int counter = 1;
		for(int i = 0; i < str.length() - 1; i++){
			if(str.charAt(i) == str.charAt(i+1))
			counter++;
			else{
				rle += str.charAt(i);
				if(counter > 1){
					rle += counter;
					counter = 1;
				}
			}
		}
		rle += str.charAt(str.length()-1);
		if(counter > 1)
			rle += counter;
		return rle;
	}
}
