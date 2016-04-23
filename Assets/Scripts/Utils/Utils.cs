using UnityEngine;
using System.Collections;

public class Utils {

	public static string RemoveBarBefQuote(string s) {
        string ret = "";
        for(int i = 0; i < s.Length; i++) {
            if( s[i] == '\\' && i+1 < s.Length && s[i+1] == '\"') {
                ret += '\"';
                i++;
            } else {
                ret += s[i];
            }
        }
        return ret;
    }
}
