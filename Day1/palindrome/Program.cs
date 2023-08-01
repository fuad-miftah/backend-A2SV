using System;
using System.Linq;

bool isPalindrome(string s){
    int p1 = 0;
    int p2 = s.Length - 1;
    while(p1 < p2){
        if( s[p1] != s[p2] ){
            return false;
        }
        p1 += 1;
        p2 -= 1;
    }
    return true;
}



string s = "The ,th!e *two Two";
s = "TewlnN@Lw./Et";
s = new string(s.Where(c => !char.IsPunctuation(c)).ToArray());
s = new string(s.Where(c => !char.IsWhiteSpace(c)).ToArray());
string ls = s.ToLower();

Console.WriteLine(ls);
var res = isPalindrome(ls);
Console.WriteLine(res);

