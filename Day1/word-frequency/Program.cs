using System;
using System.Collections.Generic;

Dictionary<string,int> frequency(string s){
    Dictionary<string,int> dic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    string[] words = s.Split(' ');
    foreach(string word in words){
        if(dic.ContainsKey(word)){
            dic[word] += 1;
        }
        else{
            dic.Add(word, 1);
        }
    }
    return dic;
}

string s = "The the two Two";
var res = frequency(s);
foreach(var pair in res){
    Console.WriteLine(pair);
}
