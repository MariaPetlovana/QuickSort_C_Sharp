using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Worky
{
    public class QuickSort
    {
        private List<int> m_list;
        private int m_size;
        
        private class MyPair
        {
            public int start;
            public int end;
        }
        
        public QuickSort(List<int> l, int _size)
        {
            this.m_list = l;
            this.m_size = _size;

            MSort(0, _size - 1);
        }
        
        private void MSort(int start, int end)
        {
            MyPair m = Partition(start, end);
                        
            if(m.start < end)
            {
                MSort(m.start, end);
            }
            
            if(m.end > start)
            {
                MSort(start, m.end);
            }

            return;               
         }        
        
        private MyPair Partition(int start, int end)
        {
            MyPair Result = new MyPair();
           
            int i = start;
            int j = end;
            int x = (start + end) / 2;
            do
            {                
                while((m_list.ElementAt(i)).CompareTo(m_list.ElementAt(x)) < 0)
                {
                    ++i;                    
                }

                while((m_list.ElementAt(j)).CompareTo(m_list.ElementAt(x)) > 0)
                {
                    --j;
                }
                
                if(i <= j)
                {
                    if(i < j)
                    {
                        int tmp = m_list.ElementAt(i);
                        m_list[i] = m_list.ElementAt(j);
                        m_list[j] = tmp;
                    }
                    
                    ++i;
                    --j;
                }
            }while(i <= j);
            
            Result.start = i;
            Result.end = j;

            return Result;
        }

        public List<int> ReturnList()
        {
            return m_list;
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            a.Insert(0, 5);       
            a.Insert(1, 0);       
            a.Insert(2, 6);       
            a.Insert(3, 3);       
            a.Insert(4, 4);       
        
            QuickSort b = new QuickSort(a, a.Count);
            a = b.ReturnList(); 
        
            foreach(int i in a)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
