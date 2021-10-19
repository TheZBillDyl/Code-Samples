#include <iostream>
#include <string>
using namespace std;

#ifndef MYSTRING_H_
#define MYSTRING_H_

class MyString: public string {

public:

	MyString(string str) {
		clear();
		append(str);
	}

	MyString() {
		clear();
	}

	void replaceChar(int pos, char c) {
		if (pos < 0 || pos >= length())
			throw "Invalid Index Access Exception";
		if (at(pos) == c)
			return;
		string str;
		str += c;
		replace(pos, 1, str);
	}

	void swapChar(int i, int j) {
		if (i < 0 || i >= length() || j < 0 || j >= length())
			throw "Invalid Index Access Exception";
		if (i == j)
			return;
		char f = at(i);
		replaceChar(i, at(j));
		replaceChar(j, f);
	}

	void reverse() { // complete this method
	for(int i = 0; i < length() / 2; i++){
	    swapChar(i, length() - i - 1);
	}
	}

	MyString toUpperCase() { // complete this method
	MyString theString = MyString();
	
	for(int i = 0; i < length(); i++){
	    if(int(at(i)) >= 97 && int(at(i)) <= 122){
	        char newC = int(at(i)) - 32;
	        theString += newC;
	    }else {
	        theString += at(i);
	    }
	}
	return theString;
	}

	int compareIgnoreCase(MyString &arg) { // complete this method
    MyString string1 = toUpperCase();
	MyString string2 = MyString(arg).toUpperCase();
	
	//cout<<string1<<endl;
	//cout<<string2<<endl;
	if(string1.compare(string2) < 0){
	    return -1;
	}else if(string1.compare(string2) == 0){
	    return 0;
	}else {
	    return 1;
	}
	}

	void replaceAll(MyString &key, MyString &replacement) { // complete this method
	
	int pos = find(key);
	int offset = replacement.length();
	while (pos >= 0) 
	{
	erase(pos, key.length());
	insert(pos, replacement);
	pos += offset;
	pos = find(key, pos);
	//pos = offset;
	//cout<<find(key,pos)<<endl;
	//pos = -1;
	    
	}
	
	}
};

#endif /* MYSTRING_H_ */