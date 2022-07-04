using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    internal class Set
    {
        bool[] boolArr = new bool[1001];
        public Set()
        {

        }

        public Set(params int[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                boolArr[value[i]] = true;
            }
        }

        public void Union(Set s)
        {
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (s.boolArr[i] == true)
                    boolArr[i] = true;
            }
        }

        public void Intersect(Set s)
        {
            for(int i = 0; i < boolArr.Length; i++)
            {
                if (s.boolArr[i] == false || boolArr[i] == false)
                    boolArr[i] = false;
            }
        }

        public bool Subset(Set s)
        {
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (s.boolArr[i] == true)
                    if (boolArr[i] == false)
                        return false;
            }

            return true;
        }

        public bool IsMember(int num)
        {
            if (boolArr[num] == true)
                return true;
            else
                return false;
        }

        public void Insert(int num)
        {
            if (boolArr[num] == false)
                boolArr[num] = true;
        }

        public void Delete(int num)
        {
            if (boolArr[num] == true)
                boolArr[num] = false;
        }

        public override string ToString()
        {
            string msg = "";
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (boolArr[i] == true)
                    msg += i + ", ";
            } return msg;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Set))
                return false;

            Set temp = (Set)obj;
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (this.boolArr[i] != temp.boolArr[i])
                    return false;
            }
            return true;
        }
    }
}
