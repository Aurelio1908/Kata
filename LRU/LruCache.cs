using System;
using System.Collections.Generic;

namespace LRU
{

   public class LruCache {

    private int _capacity;   
    private Dictionary<int, int> dictionary;


    public LruCache(int capacity) {
        _capacity = capacity;
        dictionary = new Dictionary<int, int>(capacity);
        
    }
    
    public int Get(int key) {
        
    }
    
    public void Put(int key, int value) {
        
    }
  }
}
